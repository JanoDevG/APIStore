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
    public class ProductosController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Productos
        public async Task<ActionResult> Index()
        {
            var productos = db.Productos.Include(p => p.Lenguaje_Backend).Include(p => p.Tipo_Licencias);
            return View(await productos.ToListAsync());
        }

        // GET: Productos/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            ViewBag.id_lenguaje = new SelectList(db.Lenguaje_Backend, "id_lenguaje", "nombre");
            ViewBag.id_licencia = new SelectList(db.Tipo_Licencias, "id_licencia", "nombre_licencia");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "id_producto,nombre_producto,id_lenguaje,id_licencia,stock,fecha_creacion,precio,suspencion,fecha_suspencion")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Productos.Add(productos);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_lenguaje = new SelectList(db.Lenguaje_Backend, "id_lenguaje", "nombre", productos.id_lenguaje);
            ViewBag.id_licencia = new SelectList(db.Tipo_Licencias, "id_licencia", "nombre_licencia", productos.id_licencia);
            return View(productos);
        }

        // GET: Productos/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_lenguaje = new SelectList(db.Lenguaje_Backend, "id_lenguaje", "nombre", productos.id_lenguaje);
            ViewBag.id_licencia = new SelectList(db.Tipo_Licencias, "id_licencia", "nombre_licencia", productos.id_licencia);
            return View(productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit([Bind(Include = "id_producto,nombre_producto,id_lenguaje,id_licencia,stock,fecha_creacion,precio,suspencion,fecha_suspencion")] Productos productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(productos).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_lenguaje = new SelectList(db.Lenguaje_Backend, "id_lenguaje", "nombre", productos.id_lenguaje);
            ViewBag.id_licencia = new SelectList(db.Tipo_Licencias, "id_licencia", "nombre_licencia", productos.id_licencia);
            return View(productos);
        }

        // GET: Productos/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Productos productos = await db.Productos.FindAsync(id);
            if (productos == null)
            {
                return HttpNotFound();
            }
            return View(productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Productos productos = await db.Productos.FindAsync(id);
            db.Productos.Remove(productos);
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
