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
using E15_ST3ProgrammeringReexam.Models;

namespace E15_ST3ProgrammeringReexam.Controllers
{
    public class ReminderDentistExamsController : ApiController
    {
        private E15_ST3ProgrammeringReexamContext db = new E15_ST3ProgrammeringReexamContext();

        // GET: api/ReminderDentistExams
        public IQueryable<ReminderDentistExam> GetReminderDentistExams()
        {
            return db.ReminderDentistExams;
        }

        // GET: api/ReminderDentistExams/5
        [ResponseType(typeof(ReminderDentistExam))]
        public async Task<IHttpActionResult> GetReminderDentistExam(int id)
        {
            ReminderDentistExam reminderDentistExam = await db.ReminderDentistExams.FindAsync(id);
            if (reminderDentistExam == null)
            {
                return NotFound();
            }

            return Ok(reminderDentistExam);
        }

        // PUT: api/ReminderDentistExams/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutReminderDentistExam(int id, ReminderDentistExam reminderDentistExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != reminderDentistExam.Id)
            {
                return BadRequest();
            }

            db.Entry(reminderDentistExam).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ReminderDentistExamExists(id))
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

        // POST: api/ReminderDentistExams
        [ResponseType(typeof(ReminderDentistExam))]
        public async Task<IHttpActionResult> PostReminderDentistExam(ReminderDentistExam reminderDentistExam)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ReminderDentistExams.Add(reminderDentistExam);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = reminderDentistExam.Id }, reminderDentistExam);
        }

        // DELETE: api/ReminderDentistExams/5
        [ResponseType(typeof(ReminderDentistExam))]
        public async Task<IHttpActionResult> DeleteReminderDentistExam(int id)
        {
            ReminderDentistExam reminderDentistExam = await db.ReminderDentistExams.FindAsync(id);
            if (reminderDentistExam == null)
            {
                return NotFound();
            }

            db.ReminderDentistExams.Remove(reminderDentistExam);
            await db.SaveChangesAsync();

            return Ok(reminderDentistExam);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ReminderDentistExamExists(int id)
        {
            return db.ReminderDentistExams.Count(e => e.Id == id) > 0;
        }
    }
}