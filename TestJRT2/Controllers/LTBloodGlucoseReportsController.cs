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
using TestJRT2.Models;

namespace TestJRT2.Controllers
{
    public class LTBloodGlucoseReportsController : ApiController
    {
        private LTBGMContext db = new LTBGMContext();
        /// <summary>
        /// Henter alle indrapporterede rapporter for Langtidsblodsukker.
        /// Indeholde også en liste over tilhørende selvhjælpskurser.
        /// </summary>
        /// <returns></returns>
        // GET: api/LTBloodGlucoseReports
        public IQueryable<LTBloodGlucoseReport> GetLTBloodGlucoseReports()
        {
            var ltbgrep = db.LTBloodGlucoseReports.Include(s => s.SelfHelpCourses);
            return ltbgrep;
        }
        /// <summary>
        /// Henter alle indrapporterede rapporter for et givent lægecenter for Langtidsblodsukker.
        /// Indeholde også en liste over tilhørende selvhjælpskurser.
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // GET: api/LTBloodGlucoseReports/5
        [ResponseType(typeof(LTBloodGlucoseReport))]
        public async Task<IHttpActionResult> GetLTBloodGlucoseReport(string Id)
        {
            //LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.FindAsync(id);
            //LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReportsWhere(p => p.ReportingClinicName == id)
            LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.Include(p =>p.SelfHelpCourses).FirstOrDefaultAsync(p => p.ReportingClinicName == Id); // Where(p => p.ReportingClinicName == id);
            

            if (lTBloodGlucoseReport == null)
            {
                return NotFound();
            }

            return Ok(lTBloodGlucoseReport);
        }
        /// <summary>
        /// Retter en given rapport fundet via RepportId. 
        /// Tilføjes et nyt kursus til en rapport, kan det kun ske via denne API funktion.
        /// Et nyt kursus skal have CourseId = 0 og eksisterende kursers CourseId MÅ IKKE ændres
        /// </summary>
        /// <param name="Id"></param>
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
        /// </summary>
        /// <param name="lTBloodGlucoseReport"></param>
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
        /// Slette en given rapport via den ReportId
        /// Alle tilhørende selvhjælpskurser slettes sammen med rapporten!
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        // DELETE: api/LTBloodGlucoseReports/5
        [ResponseType(typeof(LTBloodGlucoseReport))]
        public async Task<IHttpActionResult> DeleteLTBloodGlucoseReport(long Id)
        {


            //LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.FindAsync(id);
            LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.Include(r =>r.SelfHelpCourses).FirstOrDefaultAsync(p => p.LTBloodGlucoseReportId == Id);
           // db.Entry(lTBloodGlucoseReport).Collection(p => p.SelfHelpCourses).Load();

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