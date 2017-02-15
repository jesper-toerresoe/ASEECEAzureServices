using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using E16_ST3ITS3ExamOrdinary.Models;

namespace E16_ST3ITS3ExamOrdinary.Controllers
{
    public class LTBloodGlucoseReportsController : ApiController
    {
        private LTBGMContext db = new LTBGMContext();
        /// <summary>
        /// Henter ALLE uploaded rapporter for Langtidsblodsukker.
        /// Rapporter omfatter en liste over tilhørende selvhjælpskurser.
        /// </summary>
        /// <returns></returns>
        // GET: api/LTBloodGlucoseReports
        public IQueryable<LTBloodGlucoseReport> GetLTBloodGlucoseReports()
        {
            var ltbgrep = db.LTBloodGlucoseReports.Include(s => s.SelfHelpCourses);
            return ltbgrep;
        }
        /// <summary>
        /// Henter alle uploadede rapporter for Langtidsblodsukker fra et givent lægecenter fremfundet med Id (ReportingClinicName) .
        /// Rapporter omfatter en liste over tilhørende selvhjælpskurser.
        /// </summary>
        /// <param name="Id">Modsvare ReportingClinicName! Ex. CenterVest (Uden blanke tegn!)</param>
        /// <returns></returns>
        // GET: api/LTBloodGlucoseReports/CenterVest
        [ResponseType(typeof(LTBloodGlucoseReport))]
        public async Task<IHttpActionResult> GetLTBloodGlucoseReport(string Id)
        {
            LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.Include(p => p.SelfHelpCourses).FirstOrDefaultAsync(p => p.ReportingClinicName == Id); // Where(p => p.ReportingClinicName == id);

            if (lTBloodGlucoseReport == null)
            {
                return NotFound();
            }

            return Ok(lTBloodGlucoseReport);
        }
        /// <summary>

        /// </summary>
        /// <param name="Id">Modsvare LTBloodGlucoseReportId. Ex 22 </param>
        /// <param name="lTBloodGlucoseReport"></param>
        /// <returns></returns>
        // PUT: api/LTBloodGlucoseReports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLTBloodGlucoseReport(long Id, LTBloodGlucoseReport lTBloodGlucoseReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (Id != lTBloodGlucoseReport.LTBloodGlucoseReportId)
            {
                return BadRequest();
            }

            /*
            * http://stackoverflow.com/questions/25078798/new-subentity-will-not-save-when-parent-entity-is-saved
            * */
            foreach (var e in lTBloodGlucoseReport.SelfHelpCourses)
            {
                db.Entry(e).State = e.SelfHelpCourseID == 0 ? EntityState.Added : EntityState.Modified;
            }

            db.Entry(lTBloodGlucoseReport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LTBloodGlucoseReportExists(Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }
        /// <summary>
        /// Opretter en rapport med eventuelle tilhørende selvhjælpskurser.
        /// Rapport og kurses tildeles automatisk et ID (hhv. LTBloodGlucoseReportId og SelfHelpCourseID
        /// </summary>
        /// <param name="lTBloodGlucoseReport"> Se JSON eller XML eksempel</param>
        /// <returns></returns>
        // POST: api/LTBloodGlucoseReports
        [ResponseType(typeof(LTBloodGlucoseReport))]
        public async Task<IHttpActionResult> PostLTBloodGlucoseReport(LTBloodGlucoseReport lTBloodGlucoseReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.LTBloodGlucoseReports.Add(lTBloodGlucoseReport);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = lTBloodGlucoseReport.LTBloodGlucoseReportId }, lTBloodGlucoseReport);
        }
        /// <summary>
        /// Sletter en given rapport fremfundet med Id (LTBloodGlucoseReportId)
        /// Alle tilhørende selvhjælpskurser slettes sammen med rapporten!
        /// </summary>
        /// <param name="Id">Modsvare LTBloodGlucoseReportId. Ex. 43 </param>
        /// <returns></returns>
        // DELETE: api/LTBloodGlucoseReports/5
        [ResponseType(typeof(LTBloodGlucoseReport))]
        public async Task<IHttpActionResult> DeleteLTBloodGlucoseReport(long Id)
        {
            LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.Include(r => r.SelfHelpCourses).FirstOrDefaultAsync(p => p.LTBloodGlucoseReportId == Id);

            if (lTBloodGlucoseReport == null)
            {
                return NotFound();
            }

            foreach (var shc in lTBloodGlucoseReport.SelfHelpCourses.ToList())
            {
                db.SelfHelpCourses.Remove(shc);
            }
            db.LTBloodGlucoseReports.Remove(lTBloodGlucoseReport);
            await db.SaveChangesAsync();

            return Ok(lTBloodGlucoseReport);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool LTBloodGlucoseReportExists(long id)
        {
            return db.LTBloodGlucoseReports.Count(e => e.LTBloodGlucoseReportId == id) > 0;
        }
    }
}