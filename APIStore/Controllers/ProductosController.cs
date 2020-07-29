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
        public ActionResult Index()
        {
            List<Productos> listaUsu = db.Productos.Where(x => x.suspencion == false  | x.suspencion == null).ToList();
            return View(listaUsu);
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
        public async Task<ActionResult> Create(Productos productos)
        {
                Productos pro = await db.Productos.Where(x => x.id_producto == productos.id_producto).FirstOrDefaultAsync();
                if (pro == null)
                {
                    productos.fecha_creacion = DateTime.Now;
                    db.Productos.Add(productos);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
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
        public async Task<ActionResult> Edit(Productos productos)
        {
            if (ModelState.IsValid)
            {
                Productos pro = db.Productos.Find(productos.id_producto);
                pro.nombre_producto = productos.nombre_producto;
                pro.stock = productos.stock;
                pro.fecha_creacion = productos.fecha_creacion;
                pro.precio = productos.precio;
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
            productos.suspencion = true;
            productos.fecha_creacion = DateTime.Now;
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
