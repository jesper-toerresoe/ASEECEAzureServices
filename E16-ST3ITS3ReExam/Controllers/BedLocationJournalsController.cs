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
using E16_ST3ITS3ReExam.Models;

namespace E16_ST3ITS3ReExam.Controllers
{
    public class BedLocationJournalsController : ApiController
    {
        private BedJournalsContext db = new BedJournalsContext();
        /// <summary>
        /// Henter ALLE uploaded journaler for alle senge på hele hospitalet.
        /// Hver journal omfatter en liste/historik over tidligere placeringer.
        /// </summary>
        /// <returns></returns>
        // GET: api/BedLocationJournals
        public IQueryable<BedLocationJournal> GetBedLocationJournals()
        {
            return db.BedLocationJournals.Include(j => j.FormerBedLocations);
        }
        /// <summary>
        /// Henter sengejournal for en given seng fremfundet med id (BedLocationJournalId).
        /// Journalen omfatter en liste/historik over tidligere placeringer..
        /// </summary>
        /// <param name="id">Modsvare BedLocationJournalId! Ex. 23</param>
        /// <returns></returns>
        // GET: api/BedLocationJournals/5
        [ResponseType(typeof(BedLocationJournal))]
        public async Task<IHttpActionResult> GetBedLocationJournal(long id)
        {
            //BedLocationJournal bedLocationJournal = await db.BedLocationJournals.FindAsync(id);
            BedLocationJournal bedLocationJournal = await db.BedLocationJournals.Include(p => p.FormerBedLocations).FirstOrDefaultAsync(p => p.BedLocationJournalId == id);
            if (bedLocationJournal == null)
            {
                return NotFound();
            }

            return Ok(bedLocationJournal);
        }
        /// <summary>
        /// Ved en ændring af en sengs placering skal dette request bruges.
        /// Kræver at, sengejournalen der rettes er blevet oprettet (En journal oprettes med et "POST request"). 
        /// PUT request opaterer en given sengejournal udpeget med id, hvor id i request path SKAL SVARE til BedLocationJournalId, som  givet i medsendte DTO under payload.
        /// Sengens forrige placering tilføjes i journalens historiske liste, FormerBedLocations.
        /// En tilføjet historisk placering SKAL HAVE FormerBedLocationId sat til værdien 0. FormerBedLocationId bliver tildelt en værdi automatisk.
        /// BEMÆRK Eksisterende historiske placeringer som måtte være i listen MÅ IKKE ændres.
        /// </summary>
        /// <param name="id">Modsvare BedLocationJournalId! Ex. 23 </param>
        /// <param name="bedLocationJournal"></param>
        /// <returns></returns>
        // PUT: api/BedLocationJournals/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBedLocationJournal(long id, BedLocationJournal bedLocationJournal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bedLocationJournal.BedLocationJournalId)
            {
                return BadRequest();
            }

            /*
            * http://stackoverflow.com/questions/25078798/new-subentity-will-not-save-when-parent-entity-is-saved
            * */
            foreach (var f in bedLocationJournal.FormerBedLocations)
            {
                db.Entry(f).State = f.FormerBedLocationId == 0 ? EntityState.Added : EntityState.Modified;
            }
                        
            db.Entry(bedLocationJournal).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BedLocationJournalExists(id))
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
        /// Opretter en sengejournal med eventuelle tilhørende tidliger/historiske placeringer.
        /// Journal og tidligere/historiske placeringer tildeles automatisk et id (hhv. BedLocationJournalId og FormerBedLocationId).
        /// BEMÆRK: Ved efterfølgende opdateringer af en sengejournal skal "PUT request" bruges!
        /// </summary>
        /// <param name="bedLocationJournal">Se JSON eller XML eksempel</param>
        /// <returns>Se JSON eller XML eksempel</returns>
        // POST: api/BedLocationJournals
        [ResponseType(typeof(BedLocationJournal))]
        public async Task<IHttpActionResult> PostBedLocationJournal(BedLocationJournal bedLocationJournal)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.BedLocationJournals.Add(bedLocationJournal);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = bedLocationJournal.BedLocationJournalId }, bedLocationJournal);
        }
        /// <summary>
        /// Sletter en given journal fremfundet med Id (BedLocationJournalId).
        /// Alle tilhørende tidligere/historiske placeringer slettes sammen med journalen!
        /// </summary>
        /// <param name="id">Modsvare BedLocationJournalId. Ex. 43 </param>
        /// <returns>Se JSON eller XML eksempel</returns>
        // DELETE: api/BedLocationJournals/5
        [ResponseType(typeof(BedLocationJournal))]
        public async Task<IHttpActionResult> DeleteBedLocationJournal(long id)
        {
            //BedLocationJournal bedLocationJournal = await db.BedLocationJournals.FindAsync(id);
            BedLocationJournal bedLocationJournal = await db.BedLocationJournals.Include(r => r.FormerBedLocations).FirstOrDefaultAsync(p => p.BedLocationJournalId == id);
            if (bedLocationJournal == null)
            {
                return NotFound();
            }
            List<FormerBedLocation> fblist = new List<FormerBedLocation>();
            foreach (var fbl in bedLocationJournal.FormerBedLocations.ToList())
            {
                //db.FormerBedLocations.Remove(fbl);
                fblist.Add(fbl);
                db.Entry(fbl).State = EntityState.Deleted;
               //bedLocationJournal.FormerBedLocations.Remove(fbl);
            }

            //db.BedLocationJournals.Remove(bedLocationJournal);
            db.Entry(bedLocationJournal).State = EntityState.Deleted;
            await db.SaveChangesAsync();
            bedLocationJournal.FormerBedLocations = fblist;
            return Ok(bedLocationJournal);
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

        private bool BedLocationJournalExists(long id)
        {
            return db.BedLocationJournals.Count(e => e.BedLocationJournalId == id) > 0;
        }
    }
}