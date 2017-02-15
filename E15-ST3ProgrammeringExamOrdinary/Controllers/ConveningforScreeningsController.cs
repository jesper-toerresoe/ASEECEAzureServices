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
using E15_ST3ProgrammeringExamOrdinary.Models;

namespace E15_ST3ProgrammeringExamOrdinary.Controllers
{
    public class ConveningforScreeningsController : ApiController
    {
        private E15_ST3ProgrammeringExamOrdinaryContext db = new E15_ST3ProgrammeringExamOrdinaryContext();

        // GET: api/ConveningforScreenings
        public IQueryable<ConveningforScreening> GetConveningforScreenings()
        {
            return db.ConveningforScreenings;
        }

        // GET: api/ConveningforScreenings/5
        [ResponseType(typeof(ConveningforScreening))]
        public async Task<IHttpActionResult> GetConveningforScreening(int id)
        {
            ConveningforScreening conveningforScreening = await db.ConveningforScreenings.FindAsync(id);
            if (conveningforScreening == null)
            {
                return NotFound();
            }

            return Ok(conveningforScreening);
        }

        // PUT: api/ConveningforScreenings/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutConveningforScreening(int id, ConveningforScreening conveningforScreening)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != conveningforScreening.Id)
            {
                return BadRequest();
            }

            db.Entry(conveningforScreening).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ConveningforScreeningExists(id))
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

        // POST: api/ConveningforScreenings
        [ResponseType(typeof(ConveningforScreening))]
        public async Task<IHttpActionResult> PostConveningforScreening(ConveningforScreening conveningforScreening)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ConveningforScreenings.Add(conveningforScreening);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = conveningforScreening.Id }, conveningforScreening);
        }

        // DELETE: api/ConveningforScreenings/5
        [ResponseType(typeof(ConveningforScreening))]
        public async Task<IHttpActionResult> DeleteConveningforScreening(int id)
        {
            ConveningforScreening conveningforScreening = await db.ConveningforScreenings.FindAsync(id);
            if (conveningforScreening == null)
            {
                return NotFound();
            }

            db.ConveningforScreenings.Remove(conveningforScreening);
            await db.SaveChangesAsync();

            return Ok(conveningforScreening);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ConveningforScreeningExists(int id)
        {
            return db.ConveningforScreenings.Count(e => e.Id == id) > 0;
        }
    }
}