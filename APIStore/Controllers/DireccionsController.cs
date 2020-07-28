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
        public ActionResult Index()
        {
            List<Direccion> listaUsu = db.Direccion.Where(x => x.suspencion == false  | x.suspencion == null).ToList();
            return View(listaUsu);
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
        public async Task<ActionResult> Create(Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                Direccion dir = await db.Direccion.Where(x => x.id_direccion == direccion.id_direccion).FirstOrDefaultAsync();
                if (dir == null)
                {
                    db.Direccion.Add(direccion);
                    await db.SaveChangesAsync();
                }
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
        public async Task<ActionResult> Edit(Direccion direccion)
        {
            if (ModelState.IsValid)
            {
                Direccion dir = db.Direccion.Find(direccion.id_direccion);
                dir.calle = direccion.calle;
                dir.detalle_direccion = direccion.detalle_direccion;
                dir.numero = direccion.numero;
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
            direccion.suspencion = true;
            direccion.fecha_sspencion = DateTime.Now;
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
