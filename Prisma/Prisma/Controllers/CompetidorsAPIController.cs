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
using Prisma.Context;
using Prisma.Models;
using Prisma.ModelsView;

namespace Prisma.Controllers
{
    public class CompetidorsAPIController : ApiController
    {
        private PrismaContext db = new PrismaContext();

        // GET: api/CompetidorsAPI
        public IHttpActionResult GetCompetidors()
        {
            // Find all competidors in DB
            var competidors = db.Competidors.ToList();
            // Create an empty list of CompetidorAPI model
            var competidorsAPI = new List<CompetidorAPI>();
            
            // Create the objects to competidorAPI list
            foreach (var competidor in competidors)
            {
                var competidorAPI = new CompetidorAPI
                {
                    CompetidorID = competidor.CompetidorID,
                    Codigo = competidor.Codigo,
                    Nombre = competidor.Nombre,
                    Calle = competidor.Calle,
                    Latitud = competidor.Latitud,
                    Longitud = competidor.Longitud,
                    Marcador = competidor.Marcador,
                    Observar = competidor.Observar,
                    Marca = competidor.Marca,
                    Zona = competidor.Zona
                };

                // Add the object to list
                competidorsAPI.Add(competidorAPI);
            }

            return Ok(competidorsAPI);
        }

        // GET: api/CompetidorsAPI/5
        [ResponseType(typeof(Competidor))]
        public IHttpActionResult GetCompetidor(int id)
        {
            Competidor competidor = db.Competidors.Find(id);
            if (competidor == null)
            {
                return NotFound();
            }

            return Ok(competidor);
        }

        // PUT: api/CompetidorsAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCompetidor(int id, Competidor competidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != competidor.CompetidorID)
            {
                return BadRequest();
            }

            db.Entry(competidor).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompetidorExists(id))
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

        // POST: api/CompetidorsAPI
        [ResponseType(typeof(Competidor))]
        public IHttpActionResult PostCompetidor(Competidor competidor)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Competidors.Add(competidor);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = competidor.CompetidorID }, competidor);
        }

        // DELETE: api/CompetidorsAPI/5
        [ResponseType(typeof(Competidor))]
        public IHttpActionResult DeleteCompetidor(int id)
        {
            Competidor competidor = db.Competidors.Find(id);
            if (competidor == null)
            {
                return NotFound();
            }

            db.Competidors.Remove(competidor);
            db.SaveChanges();

            return Ok(competidor);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CompetidorExists(int id)
        {
            return db.Competidors.Count(e => e.CompetidorID == id) > 0;
        }
    }
}