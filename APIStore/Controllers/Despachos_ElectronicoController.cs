﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ModelAPIStore;

namespace APIStore.Controllers
{
    public class Despachos_ElectronicoController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Despachos_Electronico
        public async Task<ActionResult> Index()
        {
            var despachos_Electronico = db.Despachos_Electronico.Include(d => d.Factura);
            return View(await despachos_Electronico.ToListAsync());
        }

        // GET: Despachos_Electronico/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachos_Electronico despachos_Electronico = await db.Despachos_Electronico.FindAsync(id);
            if (despachos_Electronico == null)
            {
                return HttpNotFound();
            }
            return View(despachos_Electronico);
        }

        // GET: Despachos_Electronico/Create
        public ActionResult Create()
        {
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "id_factura");
            return View();
        }

        // POST: Despachos_Electronico/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_despacho,estado,id_factura,fecha_despacho,suspencion,fecha_suspencion")] Despachos_Electronico despachos_Electronico)
        {
            if (ModelState.IsValid)
            {
                db.Despachos_Electronico.Add(despachos_Electronico);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "id_factura", despachos_Electronico.id_factura);
            return View(despachos_Electronico);
        }

        // GET: Despachos_Electronico/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachos_Electronico despachos_Electronico = await db.Despachos_Electronico.FindAsync(id);
            if (despachos_Electronico == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "id_factura", despachos_Electronico.id_factura);
            return View(despachos_Electronico);
        }

        // POST: Despachos_Electronico/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_despacho,estado,id_factura,fecha_despacho,suspencion,fecha_suspencion")] Despachos_Electronico despachos_Electronico)
        {
            if (ModelState.IsValid)
            {
                db.Entry(despachos_Electronico).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_factura = new SelectList(db.Factura, "id_factura", "id_factura", despachos_Electronico.id_factura);
            return View(despachos_Electronico);
        }

        // GET: Despachos_Electronico/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Despachos_Electronico despachos_Electronico = await db.Despachos_Electronico.FindAsync(id);
            if (despachos_Electronico == null)
            {
                return HttpNotFound();
            }
            return View(despachos_Electronico);
        }

        // POST: Despachos_Electronico/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Despachos_Electronico despachos_Electronico = await db.Despachos_Electronico.FindAsync(id);
            db.Despachos_Electronico.Remove(despachos_Electronico);
            await db.SaveChangesAsync();
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
