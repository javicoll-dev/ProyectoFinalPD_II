using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Prestamos.DAL;
using Prestamos.Models;

namespace WebApplication5.Controllers
{
    public class PrestamoController : Controller
    {
        private GenerarContext db = new GenerarContext();

        // GET: Prestamo
        public ActionResult Index()
        {
            var prestamos = db.Prestamos.Include(p => p.Clientes);
            return View(prestamos.ToList());
        }

        // GET: Prestamo/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // GET: Prestamo/Create
        public ActionResult Create()
        {
            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nombre");
            return View();
        }

        // POST: Prestamo/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Capital,Interes,Periodo,ClientesId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Prestamos.Add(prestamo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nombre", prestamo.ClientesId);
            return View(prestamo);
        }

        // GET: Prestamo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nombre", prestamo.ClientesId);
            return View(prestamo);
        }

        // POST: Prestamo/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Capital,Interes,Periodo,ClientesId")] Prestamo prestamo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(prestamo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientesId = new SelectList(db.Clientes, "Id", "Nombre", prestamo.ClientesId);
            return View(prestamo);
        }

        // GET: Prestamo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Prestamo prestamo = db.Prestamos.Find(id);
            if (prestamo == null)
            {
                return HttpNotFound();
            }
            return View(prestamo);
        }

        // POST: Prestamo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Prestamo prestamo = db.Prestamos.Find(id);
            db.Prestamos.Remove(prestamo);
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
