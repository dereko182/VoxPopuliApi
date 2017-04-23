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
    public class CampaniaDetallesController : ApiController
    {
        private voxpopuliDBEntities db = new voxpopuliDBEntities();

        //// GET: api/CampaniaDetalles
        //public IQueryable<CampaniaDetalle> GetCampaniaDetalle()
        //{
        //    return db.CampaniaDetalle;
        //}
        // GET: api/CampaniaDetalles
        public IQueryable<CampaniaDetalle> GetCampaniaDetalle(int id)
        {
            return db.CampaniaDetalle.Where(w=> w.CampaniaId == id);
        }

        //// GET: api/CampaniaDetalles/5
        //[ResponseType(typeof(CampaniaDetalle))]
        //public IHttpActionResult GetCampaniaDetalle(int id)
        //{
        //    CampaniaDetalle campaniaDetalle = db.CampaniaDetalle.Find(id);
        //    if (campaniaDetalle == null)
        //    {
        //        return NotFound();
        //    }

        //    return Ok(campaniaDetalle);
        //}

        // PUT: api/CampaniaDetalles/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCampaniaDetalle(int id, CampaniaDetalle campaniaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != campaniaDetalle.CampaniaDetalleId)
            {
                return BadRequest();
            }

            db.Entry(campaniaDetalle).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaniaDetalleExists(id))
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

        // POST: api/CampaniaDetalles
        [ResponseType(typeof(CampaniaDetalle))]
        public IHttpActionResult PostCampaniaDetalle(CampaniaDetalle campaniaDetalle)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.CampaniaDetalle.Add(campaniaDetalle);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = campaniaDetalle.CampaniaDetalleId }, campaniaDetalle);
        }

        // DELETE: api/CampaniaDetalles/5
        [ResponseType(typeof(CampaniaDetalle))]
        public IHttpActionResult DeleteCampaniaDetalle(int id)
        {
            CampaniaDetalle campaniaDetalle = db.CampaniaDetalle.Find(id);
            if (campaniaDetalle == null)
            {
                return NotFound();
            }

            db.CampaniaDetalle.Remove(campaniaDetalle);
            db.SaveChanges();

            return Ok(campaniaDetalle);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CampaniaDetalleExists(int id)
        {
            return db.CampaniaDetalle.Count(e => e.CampaniaDetalleId == id) > 0;
        }
    }
}