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
    public class SelfHelpCoursesController : ApiController
    {
        private LTBGMContext db = new LTBGMContext();
        /// <summary>
        /// Hent det hele du
        /// </summary>
        /// <returns></returns>
        // GET: api/SelfHelpCourses
        public IQueryable<SelfHelpCourse> GetSelfHelpCourses()
        {
            return db.SelfHelpCourses;
        }

        // GET: api/SelfHelpCourses/5
        [ResponseType(typeof(SelfHelpCourse))]
        public async Task<IHttpActionResult> GetSelfHelpCourse(long id)
        {
            SelfHelpCourse selfHelpCourse = await db.SelfHelpCourses.FindAsync(id);
            if (selfHelpCourse == null)
            {
                return NotFound();
            }

            return Ok(selfHelpCourse);
        }

        // PUT: api/SelfHelpCourses/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutSelfHelpCourse(long id, SelfHelpCourse selfHelpCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != selfHelpCourse.SelfHelpCourseID)
            {
                return BadRequest();
            }

            db.Entry(selfHelpCourse).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SelfHelpCourseExists(id))
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

        // POST: api/SelfHelpCourses
        [ResponseType(typeof(SelfHelpCourse))]
        public async Task<IHttpActionResult> PostSelfHelpCourse(SelfHelpCourse selfHelpCourse)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.SelfHelpCourses.Add(selfHelpCourse);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = selfHelpCourse.SelfHelpCourseID }, selfHelpCourse);
        }

        // DELETE: api/SelfHelpCourses/5
        [ResponseType(typeof(SelfHelpCourse))]
        public async Task<IHttpActionResult> DeleteSelfHelpCourse(long id)
        {
            SelfHelpCourse selfHelpCourse = await db.SelfHelpCourses.FindAsync(id);
            if (selfHelpCourse == null)
            {
                return NotFound();
            }

            db.SelfHelpCourses.Remove(selfHelpCourse);
            await db.SaveChangesAsync();

            return Ok(selfHelpCourse);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool SelfHelpCourseExists(long id)
        {
            return db.SelfHelpCourses.Count(e => e.SelfHelpCourseID == id) > 0;
        }
    }
}