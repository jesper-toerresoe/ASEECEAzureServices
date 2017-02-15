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
using F16_ST3P3Opgave.Models;

namespace F16_ST3P3Opgave.Controllers
{
    public class VenuesController : ApiController
    {
        private F16_ST3P3OpgaveContext db = new F16_ST3P3OpgaveContext();

        // GET: api/Venues
        public IQueryable<Venue> GetVenues()
        {
            return db.Venues;
        }

        // GET: api/Venues/5
        [ResponseType(typeof(Venue))]
        public async Task<IHttpActionResult> GetVenue(int id)
        {
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }

            return Ok(venue);
        }

        // PUT: api/Venues/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutVenue(int id, Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != venue.Id)
            {
                return BadRequest();
            }

            db.Entry(venue).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VenueExists(id))
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

        // POST: api/Venues
        [ResponseType(typeof(Venue))]
        public async Task<IHttpActionResult> PostVenue(Venue venue)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Venues.Add(venue);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = venue.Id }, venue);
        }

        // DELETE: api/Venues/5
        [ResponseType(typeof(Venue))]
        public async Task<IHttpActionResult> DeleteVenue(int id)
        {
            Venue venue = await db.Venues.FindAsync(id);
            if (venue == null)
            {
                return NotFound();
            }

            db.Venues.Remove(venue);
            await db.SaveChangesAsync();

            return Ok(venue);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool VenueExists(int id)
        {
            return db.Venues.Count(e => e.Id == id) > 0;
        }
    }
}