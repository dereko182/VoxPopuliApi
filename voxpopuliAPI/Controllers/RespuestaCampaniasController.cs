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
    public class RespuestaCampaniasController : ApiController
    {
        private voxpopuliDBEntities db = new voxpopuliDBEntities();

        // GET: api/RespuestaCampanias
        public IQueryable<RespuestaCampania> GetRespuestaCampania()
        {
            return db.RespuestaCampania;
        }

        //// GET: api/RespuestaCampanias/5
        //[ResponseType(typeof(RespuestaCampania))]
        //public IQueryable<RespuestaCampania> GetRespuestaCampania(int id)
        //{
        //    return db.RespuestaCampania.Where(w => w.CampaniaId == id);
        //}

        // GET: api/RespuestaCampaniaToChart/5
        [ResponseType(typeof(DataSourceChart))]
        public IHttpActionResult GetRespuestaCampania(int id, int id2)
        {
            try
            {
                List<CharData> dataSource = null;
                List<RespuestaCampania> respuestas = db.RespuestaCampania.Where(w => w.CampaniaId == id && w.PreguntaId == id2).ToList();
                dataSource = new List<CharData>();
                int total = respuestas.Count;
                bool explode = false;
                int totalRespuestas = 0;
                decimal Porcentaje = 0;
                foreach (RespuestaCampania item in respuestas)
                {
                    totalRespuestas = respuestas.Where(w => w.PreguntaId == item.PreguntaId).ToList().Where(w => w.RespuestaId == item.RespuestaId).Count();
                    if (dataSource.Where(w => w.Nombre == item.Respuesta.Nombre).Count() == 0)
                    {
                        explode = explode = false ? true : false;
                        Porcentaje = (decimal.Parse(totalRespuestas.ToString()) / decimal.Parse(total.ToString())) * 100;
                        dataSource.Add(new CharData(item.Respuesta.Nombre, Decimal.ToInt32(Porcentaje), explode));
                    }
                }
                return Ok(new DataSourceChart(respuestas.FirstOrDefault().Pregunta.Nombre, dataSource));
            }
            catch (Exception ex)
            {
                return Ok(new DataSourceChart());
            }
        }
        // PUT: api/RespuestaCampanias/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRespuestaCampania(int id, RespuestaCampania respuestaCampania)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != respuestaCampania.CampaniaDetalleId)
            {
                return BadRequest();
            }

            db.Entry(respuestaCampania).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RespuestaCampaniaExists(id))
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

        // POST: api/RespuestaCampanias
        [ResponseType(typeof(RespuestaCampania))]
        public IHttpActionResult PostRespuestaCampania(RespuestaCampania respuestaCampania)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.RespuestaCampania.Add(respuestaCampania);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (RespuestaCampaniaExists(respuestaCampania.CampaniaDetalleId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = respuestaCampania.CampaniaDetalleId }, respuestaCampania);
        }

        // DELETE: api/RespuestaCampanias/5
        [ResponseType(typeof(RespuestaCampania))]
        public IHttpActionResult DeleteRespuestaCampania(int id)
        {
            RespuestaCampania respuestaCampania = db.RespuestaCampania.Find(id);
            if (respuestaCampania == null)
            {
                return NotFound();
            }

            db.RespuestaCampania.Remove(respuestaCampania);
            db.SaveChanges();

            return Ok(respuestaCampania);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool RespuestaCampaniaExists(int id)
        {
            return db.RespuestaCampania.Count(e => e.CampaniaDetalleId == id) > 0;
        }
    }
}