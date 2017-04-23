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
using voxpopuliAPI.Models;

namespace voxpopuliAPI.Controllers
{
    public class CampaniasController : ApiController
    {
        private voxpopuliDBEntities db = new voxpopuliDBEntities();

        // GET: api/Campanias
        public IQueryable<Campania> GetCampania()
        {
            return db.Campania;
        }

        // GET: api/Campanias/5
        [ResponseType(typeof(Campania))]
        public IHttpActionResult GetCampania(int id)
        {
            Campania campania = db.Campania.Find(id);
            if (campania == null)
            {
                return NotFound();
            }

            return Ok(campania);
        }

        // PUT: api/Campanias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampania(int id, Campania campania)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campania.CampaniaId)
            {
                return BadRequest();
            }

            db.Entry(campania).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaniaExists(id))
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

        // POST: api/Campanias
        [ResponseType(typeof(Campania))]
        public IHttpActionResult PostCampania(Campania campania)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Campania.Add(campania);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campania.CampaniaId }, campania);
        }

        // DELETE: api/Campanias/5
        [ResponseType(typeof(Campania))]
        public IHttpActionResult DeleteCampania(int id)
        {
            Campania campania = db.Campania.Find(id);
            if (campania == null)
            {
                return NotFound();
            }

            db.Campania.Remove(campania);
            db.SaveChanges();

            return Ok(campania);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampaniaExists(int id)
        {
            return db.Campania.Count(e => e.CampaniaId == id) > 0;
        }
    }
}