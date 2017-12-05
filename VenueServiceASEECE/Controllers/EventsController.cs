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
using System.Web.Http.Results;
using System.Web.Http.Description;
using VenueServiceASEECE.Models;

namespace VenueServiceASEECE.Controllers
{
    public class EventsController : ApiController
    {
        private VenueServiceASEECEContext db = new VenueServiceASEECEContext();
        /// <summary>
        /// Henter alle Events registreret på VenueServiceASEECE uagtet tilhørsforhold
        /// til et Venue
        /// </summary>
        /// <returns></returns>
        // GET: api/Events
        public IQueryable<Event> GetEvents()
        {
            return db.Events;
        }
        /// <summary>
        /// Henter det med ID specificerede Event og kun dette Event!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // GET: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> GetEvent(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            return Ok(@event);
        }
        /// <summary>
        /// Opdater det med ID specificerede Event og kun dette Event!
        /// Hvis Event skal flyttes til andet Venue skal Event slettes med DELETE fra VeneueServiceASEECE
        /// Derefter tilknyttes Event det ønskede Venue og dette venue skal opdateres med PUT.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="event"></param>
        /// <returns></returns>
        // PUT: api/Events/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutEvent(int id, Event @event)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != @event.Id)
            {
                return BadRequest();
            }

            db.Entry(@event).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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
        /// Opret Event er kun muligt sammen med oprettelse elller ændring af Venue
        /// </summary>
        /// <returns>HTTP Code 400</returns>
        [ResponseType(typeof(void))]
        public  StatusCodeResult PostEvent(/*Event @event*/)
        {
            return StatusCode(HttpStatusCode.BadRequest);
            //return this.BadRequest();

            //if (!ModelState.IsValid)
            //{
            //    return BadRequest(ModelState);
            //}

            //db.Events.Add(@event);
            //await db.SaveChangesAsync();

            //return CreatedAtRoute("DefaultApi", new { id = @event.Id }, @event);
        }

        /// <summary>
        /// Sletter det med Id angivet Event og KUN dette"
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/Events/5
        [ResponseType(typeof(Event))]
        public async Task<IHttpActionResult> DeleteEvent(int id)
        {
            Event @event = await db.Events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            db.Events.Remove(@event);
            await db.SaveChangesAsync();

            return Ok(@event);
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

        private bool EventExists(int id)
        {
            return db.Events.Count(e => e.Id == id) > 0;
        }
    }
}