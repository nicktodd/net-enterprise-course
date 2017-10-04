using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CompactDiscEntityFramework;

namespace CompactDiscRest.Controllers
{
    public class CompactDiscWizardController : ApiController
    {
        private MusicDbContext db = new MusicDbContext();

        // GET: api/CompactDiscWizard
        public IQueryable<CompactDisc> GetCompactDiscs()
        {
            return db.CompactDiscs;
        }

        // GET: api/CompactDiscWizard/5
        [ResponseType(typeof(CompactDisc))]
        public IHttpActionResult GetCompactDisc(int id)
        {
            CompactDisc compactDisc = db.CompactDiscs.Find(id);
            if (compactDisc == null)
            {
                return NotFound();
            }

            return Ok(compactDisc);
        }

        // PUT: api/CompactDiscWizard/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompactDisc(int id, CompactDisc compactDisc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != compactDisc.id)
            {
                return BadRequest();
            }

            db.Entry(compactDisc).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompactDiscExists(id))
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

        // POST: api/CompactDiscWizard
        [ResponseType(typeof(CompactDisc))]
        public IHttpActionResult PostCompactDisc(CompactDisc compactDisc)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CompactDiscs.Add(compactDisc);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = compactDisc.id }, compactDisc);
        }

        // DELETE: api/CompactDiscWizard/5
        [ResponseType(typeof(CompactDisc))]
        public IHttpActionResult DeleteCompactDisc(int id)
        {
            CompactDisc compactDisc = db.CompactDiscs.Find(id);
            if (compactDisc == null)
            {
                return NotFound();
            }

            db.CompactDiscs.Remove(compactDisc);
            db.SaveChanges();

            return Ok(compactDisc);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompactDiscExists(int id)
        {
            return db.CompactDiscs.Count(e => e.id == id) > 0;
        }
    }
}