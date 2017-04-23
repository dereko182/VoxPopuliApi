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
    public class ControlVotacionsController : ApiController
    {
        private voxpopuliDBEntities db = new voxpopuliDBEntities();

        // GET: api/ControlVotacions
        public IQueryable<ControlVotacion> GetControlVotacion()
        {
            return db.ControlVotacion;
        }

        // GET: api/ControlVotacions/5
        [ResponseType(typeof(ControlVotacion))]
        public IHttpActionResult GetControlVotacion(int id)
        {
            ControlVotacion controlVotacion = db.ControlVotacion.Find(id);
            if (controlVotacion == null)
            {
                return NotFound();
            }

            return Ok(controlVotacion);
        }

        // PUT: api/ControlVotacions/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutControlVotacion(int id, ControlVotacion controlVotacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != controlVotacion.CampaniaId)
            {
                return BadRequest();
            }

            db.Entry(controlVotacion).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ControlVotacionExists(id))
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

        // POST: api/ControlVotacions
        [ResponseType(typeof(ControlVotacion))]
        public IHttpActionResult PostControlVotacion(ControlVotacion controlVotacion)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.ControlVotacion.Add(controlVotacion);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (ControlVotacionExists(controlVotacion.CampaniaId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = controlVotacion.CampaniaId }, controlVotacion);
        }

        // DELETE: api/ControlVotacions/5
        [ResponseType(typeof(ControlVotacion))]
        public IHttpActionResult DeleteControlVotacion(int id)
        {
            ControlVotacion controlVotacion = db.ControlVotacion.Find(id);
            if (controlVotacion == null)
            {
                return NotFound();
            }

            db.ControlVotacion.Remove(controlVotacion);
            db.SaveChanges();

            return Ok(controlVotacion);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ControlVotacionExists(int id)
        {
            return db.ControlVotacion.Count(e => e.CampaniaId == id) > 0;
        }
    }
}