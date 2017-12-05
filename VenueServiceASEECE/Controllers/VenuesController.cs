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
using VenueServiceASEECE.Models;

namespace VenueServiceASEECE.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class VenuesController : ApiController
    {
        private VenueServiceASEECEContext db = new VenueServiceASEECEContext();
        /// <summary>
        /// Henter ALLE Venues inkluderet på venueservice.
        /// Hvert Venue omfatter en liste over aktuelle arrangementer på spillestedet.
        /// </summary>
        /// <returns></returns>
        // GET: api/Venues
        public IQueryable<Venue> GetVenues()
        {
            return db.Venues.Include(j => j.CommingEvents);
        }
        /// <summary>
        /// Henter et Venue identificeret med Id fra venueservice.
        /// Et Venue omfatter en liste over aktuelle arrangementer på spillestedet.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Venues/5
        [ResponseType(typeof(Venue))]
        public async Task<IHttpActionResult> GetVenue(int id)
        {
            Venue venue = await db.Venues.Include(v => v.CommingEvents).SingleOrDefaultAsync(p => p.Id == id);
            if (venue == null)
            {
                return NotFound();
            }

            return Ok(venue);
        }
        /// <summary>
        /// Opdatere et givent Venue identificeret med Id. Værdierne fra det medsendte 
        /// Venue DTO opdaterer det udpegede Venue på venueservice, dette omfatter også ændringer og tilføjelser
        /// i listen af Events (CommingEvents). For nye Events i Event listen skal Id være 0 (nul) mens eksiterende Event kan rettes
        /// forudsæt Id for Event IKKE ændres.
        /// Kræver at, Venue der rettes er blevet oprettet (En Venue oprettes med et "POST request").
        /// </summary>
        /// <param name="id"> Eks 3</param>
        /// <param name="venue"></param>
        /// <returns></returns>
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

       /*
       * http://stackoverflow.com/questions/25078798/new-subentity-will-not-save-when-parent-entity-is-saved
       * */
            foreach (var e in venue.CommingEvents)
            {
                db.Entry(e).State = e.Id == 0 ? EntityState.Added : EntityState.Modified;
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
        /// <summary>
        /// Opretter et Venue med eventuelle tilhørende Events.
        /// Venue og tilhørende Events tildeles automatisk et Id.
        /// BEMÆRK: Ved efterfølgende opdateringer af et Venue skal "PUT request" bruges!
        /// </summary>
        /// <param name="venue"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Sletter et givent Venue fremfundet med Id 
        /// Alle tilhørende Event slettes sammen med Venue
        /// </summary>
        /// <param name="id">Venue at slette</param>
        /// <returns>Slette Venue</returns>
        [ResponseType(typeof(Venue))]
        public async Task<IHttpActionResult> DeleteVenue(int id)
        {
            Venue venue = await db.Venues.Include(r => r.CommingEvents).FirstOrDefaultAsync(p => p.Id == id);
            if (venue == null)
            {
                return NotFound();
            }
            List<Event> vlist = new List<Event>();
            foreach (var ev in venue.CommingEvents.ToList())
            {
                
                vlist.Add(ev);
                db.Entry(ev).State = EntityState.Deleted;
                
            }

            db.Entry(venue).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            venue.CommingEvents = vlist;
            return Ok(venue);

            //Venue venue = await db.Venues.FindAsync(id);
            //if (venue == null)
            //{
            //    return NotFound();
            //}

            //db.Venues.Remove(venue);
            //await db.SaveChangesAsync();

            //return Ok(venue);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="disposing"></param>
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