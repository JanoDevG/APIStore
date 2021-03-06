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
    public class FacturasController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Facturas
        public ActionResult Index()
        {
            List<Factura> listaUsu = db.Factura.Where(x => x.suspencion == false  | x.suspencion == null).ToList();
            return View(listaUsu);
        }

        // GET: Facturas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // GET: Facturas/Create
        public ActionResult Create()
        {
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "calle");
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta");
            return View();
        }

        // POST: Facturas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Factura factura)
        {
            if (ModelState.IsValid)
            {
                Factura fac = await db.Factura.Where(x => x.id_factura == factura.id_factura).FirstOrDefaultAsync();
                if (fac == null)
                {
                    db.Factura.Add(factura);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "calle", factura.id_direccion);
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta", factura.id_venta);
            return View(factura);
        }

        // GET: Facturas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "calle", factura.id_direccion);
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta", factura.id_venta);
            return View(factura);
        }

        // POST: Facturas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Factura factura)
        {
            if (ModelState.IsValid)
            {
                Factura fac = db.Factura.Find(factura.id_factura);
                fac.fecha_facturacion = factura.fecha_facturacion;
                fac.iva_actual = factura.iva_actual;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_direccion = new SelectList(db.Direccion, "id_direccion", "calle", factura.id_direccion);
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta", factura.id_venta);
            return View(factura);
        }

        // GET: Facturas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Factura factura = await db.Factura.FindAsync(id);
            if (factura == null)
            {
                return HttpNotFound();
            }
            return View(factura);
        }

        // POST: Facturas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Factura factura = await db.Factura.FindAsync(id);
            factura.suspencion = true;
            factura.fecha_suspencion = DateTime.Now;
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
