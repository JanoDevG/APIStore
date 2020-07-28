using System;
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
    public class Detalle_VentasController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Detalle_Ventas
        public async Task<ActionResult> Index()
        {
            var detalle_Ventas = db.Detalle_Ventas.Include(d => d.Productos).Include(d => d.Ventas);
            return View(await detalle_Ventas.ToListAsync());
        }

        // GET: Detalle_Ventas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Ventas detalle_Ventas = await db.Detalle_Ventas.FindAsync(id);
            if (detalle_Ventas == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Ventas);
        }

        // GET: Detalle_Ventas/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto");
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta");
            return View();
        }

        // POST: Detalle_Ventas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_detalle_venta,id_producto,id_venta,suspencion,fecha_suspencion")] Detalle_Ventas detalle_Ventas)
        {
            if (ModelState.IsValid)
            {
                db.Detalle_Ventas.Add(detalle_Ventas);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", detalle_Ventas.id_producto);
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta", detalle_Ventas.id_venta);
            return View(detalle_Ventas);
        }

        // GET: Detalle_Ventas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Ventas detalle_Ventas = await db.Detalle_Ventas.FindAsync(id);
            if (detalle_Ventas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", detalle_Ventas.id_producto);
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta", detalle_Ventas.id_venta);
            return View(detalle_Ventas);
        }

        // POST: Detalle_Ventas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_detalle_venta,id_producto,id_venta,suspencion,fecha_suspencion")] Detalle_Ventas detalle_Ventas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(detalle_Ventas).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", detalle_Ventas.id_producto);
            ViewBag.id_venta = new SelectList(db.Ventas, "id_venta", "id_venta", detalle_Ventas.id_venta);
            return View(detalle_Ventas);
        }

        // GET: Detalle_Ventas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Detalle_Ventas detalle_Ventas = await db.Detalle_Ventas.FindAsync(id);
            if (detalle_Ventas == null)
            {
                return HttpNotFound();
            }
            return View(detalle_Ventas);
        }

        // POST: Detalle_Ventas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Detalle_Ventas detalle_Ventas = await db.Detalle_Ventas.FindAsync(id);
            db.Detalle_Ventas.Remove(detalle_Ventas);
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
