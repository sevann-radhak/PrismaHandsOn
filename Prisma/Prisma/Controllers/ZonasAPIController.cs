﻿using System;
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

namespace Prisma.Controllers
{
    public class ZonasAPIController : ApiController
    {
        private PrismaContext db = new PrismaContext();

        // GET: api/ZonasAPI
        public IHttpActionResult GetZonas()
        {
            return Ok(db.Zonas.ToList());
        }

        // GET: api/ZonasAPI/5
        [ResponseType(typeof(Zona))]
        public IHttpActionResult GetZona(int id)
        {
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return NotFound();
            }

            return Ok(zona);
        }

        // PUT: api/ZonasAPI/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutZona(int id, Zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != zona.ZonaID)
            {
                return BadRequest();
            }

            db.Entry(zona).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZonaExists(id))
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

        // POST: api/ZonasAPI
        [ResponseType(typeof(Zona))]
        public IHttpActionResult PostZona(Zona zona)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Zonas.Add(zona);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = zona.ZonaID }, zona);
        }

        // DELETE: api/ZonasAPI/5
        [ResponseType(typeof(Zona))]
        public IHttpActionResult DeleteZona(int id)
        {
            Zona zona = db.Zonas.Find(id);
            if (zona == null)
            {
                return NotFound();
            }

            db.Zonas.Remove(zona);
            db.SaveChanges();

            return Ok(zona);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool ZonaExists(int id)
        {
            return db.Zonas.Count(e => e.ZonaID == id) > 0;
        }
    }
}