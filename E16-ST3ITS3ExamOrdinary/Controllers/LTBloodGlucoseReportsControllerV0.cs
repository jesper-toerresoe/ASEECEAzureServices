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
    /// <summary>
    /// 
    /// </summary>
    public class LTBloodGlucoseReportsControllerV0 : ApiController
    {
        private LTBGMContext db = new LTBGMContext();

        // GET: api/LTBloodGlucoseReports
        public IQueryable<LTBloodGlucoseReport> GetLTBloodGlucoseReports()
        {
            return db.LTBloodGlucoseReports;
        }

        // GET: api/LTBloodGlucoseReports/5
        [ResponseType(typeof(LTBloodGlucoseReport))]
        public async Task<IHttpActionResult> GetLTBloodGlucoseReport(long id)
        {
            LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.FindAsync(id);
            if (lTBloodGlucoseReport == null)
            {
                return NotFound();
            }

            return Ok(lTBloodGlucoseReport);
        }

        // PUT: api/LTBloodGlucoseReports/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutLTBloodGlucoseReport(long id, LTBloodGlucoseReport lTBloodGlucoseReport)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != lTBloodGlucoseReport.LTBloodGlucoseReportId)
            {
                return BadRequest();
            }

            db.Entry(lTBloodGlucoseReport).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LTBloodGlucoseReportExists(id))
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

        // DELETE: api/LTBloodGlucoseReports/5
        [ResponseType(typeof(LTBloodGlucoseReport))]
        public async Task<IHttpActionResult> DeleteLTBloodGlucoseReport(long id)
        {
            LTBloodGlucoseReport lTBloodGlucoseReport = await db.LTBloodGlucoseReports.FindAsync(id);
            if (lTBloodGlucoseReport == null)
            {
                return NotFound();
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