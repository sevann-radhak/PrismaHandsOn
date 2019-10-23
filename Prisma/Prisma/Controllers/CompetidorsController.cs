using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prisma.Context;
using Prisma.Models;

namespace Prisma.Controllers
{
    public class CompetidorsController : Controller
    {
        private PrismaContext db = new PrismaContext();

        // GET: Competidors
        public ActionResult Index()
        {
            var competidors = db.Competidors.Include(c => c.Marca).Include(c => c.Zona);
            return View(competidors.ToList());
        }

        // GET: Competidors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competidor competidor = db.Competidors.Find(id);
            if (competidor == null)
            {
                return HttpNotFound();
            }
            return View(competidor);
        }

        // GET: Competidors/Create
        public ActionResult Create()
        {
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Codigo");
            ViewBag.ZonaID = new SelectList(db.Zonas, "ZonaID", "Codigo");
            return View();
        }

        // POST: Competidors/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CompetidorID,Codigo,Nombre,Calle,Latitud,Longitud,Marcador,Observar,MarcaID,ZonaID")] Competidor competidor)
        {
            if (ModelState.IsValid)
            {
                db.Competidors.Add(competidor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Codigo", competidor.MarcaID);
            ViewBag.ZonaID = new SelectList(db.Zonas, "ZonaID", "Codigo", competidor.ZonaID);
            return View(competidor);
        }

        // GET: Competidors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competidor competidor = db.Competidors.Find(id);
            if (competidor == null)
            {
                return HttpNotFound();
            }
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Codigo", competidor.MarcaID);
            ViewBag.ZonaID = new SelectList(db.Zonas, "ZonaID", "Codigo", competidor.ZonaID);
            return View(competidor);
        }

        // POST: Competidors/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CompetidorID,Codigo,Nombre,Calle,Latitud,Longitud,Marcador,Observar,MarcaID,ZonaID")] Competidor competidor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(competidor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.MarcaID = new SelectList(db.Marcas, "MarcaID", "Codigo", competidor.MarcaID);
            ViewBag.ZonaID = new SelectList(db.Zonas, "ZonaID", "Codigo", competidor.ZonaID);
            return View(competidor);
        }

        // GET: Competidors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Competidor competidor = db.Competidors.Find(id);
            if (competidor == null)
            {
                return HttpNotFound();
            }
            return View(competidor);
        }

        // POST: Competidors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Competidor competidor = db.Competidors.Find(id);
            db.Competidors.Remove(competidor);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
