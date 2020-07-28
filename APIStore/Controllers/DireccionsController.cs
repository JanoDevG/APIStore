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
    public class DireccionsController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Direccions
        public async Task<ActionResult> Index()
        {
            var direccion = db.Direccion.Include(d => d.Ciudades);
            return View(await direccion.ToListAsync());
        }

        // GET: Direccions/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = await db.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // GET: Direccions/Create
        public ActionResult Create()
        {
            ViewBag.id_ciudad = new SelectList(db.Ciudades, "id_ciudad", "nombre_ciudad");
            return View();
        }

        // POST: Direccions/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_direccion,id_ciudad,calle,numero,detalle_direccion,suspencion,fecha_sspencion")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Direccion.Add(direccion);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_ciudad = new SelectList(db.Ciudades, "id_ciudad", "nombre_ciudad", direccion.id_ciudad);
            return View(direccion);
        }

        // GET: Direccions/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = await db.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_ciudad = new SelectList(db.Ciudades, "id_ciudad", "nombre_ciudad", direccion.id_ciudad);
            return View(direccion);
        }

        // POST: Direccions/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_direccion,id_ciudad,calle,numero,detalle_direccion,suspencion,fecha_sspencion")] Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                db.Entry(direccion).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_ciudad = new SelectList(db.Ciudades, "id_ciudad", "nombre_ciudad", direccion.id_ciudad);
            return View(direccion);
        }

        // GET: Direccions/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Direccion direccion = await db.Direccion.FindAsync(id);
            if (direccion == null)
            {
                return HttpNotFound();
            }
            return View(direccion);
        }

        // POST: Direccions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Direccion direccion = await db.Direccion.FindAsync(id);
            db.Direccion.Remove(direccion);
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
