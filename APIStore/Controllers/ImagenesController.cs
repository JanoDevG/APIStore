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
    public class ImagenesController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Imagenes
        public async Task<ActionResult> Index()
        {
            var imagenes = db.Imagenes.Include(i => i.Productos);
            return View(await imagenes.ToListAsync());
        }

        // GET: Imagenes/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = await db.Imagenes.FindAsync(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }

        // GET: Imagenes/Create
        public ActionResult Create()
        {
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto");
            return View();
        }

        // POST: Imagenes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Imagenes imagenes, HttpPostedFileBase imagen)
        {
            string ruta = Server.MapPath("/Content/img");
            if (ModelState.IsValid)
            {
                imagen.SaveAs($"{ruta}/{imagenes.id_imagen}{imagen.FileName}");
                imagenes.url = $"/Content/img/{imagen.FileName}";
                db.Imagenes.Add(imagenes);
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", imagenes.id_producto);
            return View(imagenes);
        }

        // GET: Imagenes/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = await db.Imagenes.FindAsync(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", imagenes.id_producto);
            return View(imagenes);
        }

        // POST: Imagenes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Imagenes imagenes, HttpPostedFileBase imagen)
        {
            string ruta = Server.MapPath("/Content/img");
            if (ModelState.IsValid)
            {
                Imagenes img = db.Imagenes.Find(imagenes.id_imagen);
                img.id_imagen = imagenes.id_imagen;
                if (imagen != null)
                {
                    imagen.SaveAs($"{ruta}/{imagenes.id_imagen}_{imagen.FileName}");
                    img.url = $"/Content/img/{imagen.FileName}";
                }
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.Productos, "id_producto", "nombre_producto", imagenes.id_producto);
            return View(imagenes);
        }

        // GET: Imagenes/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagenes imagenes = await db.Imagenes.FindAsync(id);
            if (imagenes == null)
            {
                return HttpNotFound();
            }
            return View(imagenes);
        }

        // POST: Imagenes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Imagenes imagenes = await db.Imagenes.FindAsync(id);
            db.Imagenes.Remove(imagenes);
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
