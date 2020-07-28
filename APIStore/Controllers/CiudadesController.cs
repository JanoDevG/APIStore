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
    public class CiudadesController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Ciudades
        public ActionResult Index()
        {
            List<Ciudades> lis = db.Ciudades.Where(x => x.suspencion == false  | x.suspencion == null).ToList();
            return View(lis);
        }

        // GET: Ciudades/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // GET: Ciudades/Create
        public ActionResult Create()
        {
            ViewBag.id_region = new SelectList(db.Regiones, "id_region", "nombre_region");
            return View();
        }

        // POST: Ciudades/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                Ciudades ci = await db.Ciudades.Where(x => x.id_ciudad == ciudades.id_ciudad).FirstOrDefaultAsync();
                if (ci == null)
                {
                    db.Ciudades.Add(ciudades);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }
            ViewBag.id_region = new SelectList(db.Regiones, "id_region", "nombre_region", ciudades.id_region);
            return View(ciudades);
        }

        // GET: Ciudades/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_region = new SelectList(db.Regiones, "id_region", "nombre_region", ciudades.id_region);
            return View(ciudades);
        }

        // POST: Ciudades/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Ciudades ciudades)
        {
            if (ModelState.IsValid)
            {
                //db.Entry(ciudades).State = EntityState.Modified;
                Ciudades ci = db.Ciudades.Find(ciudades.id_ciudad);
                ci.Direccion = ciudades.Direccion;
                ci.nombre_ciudad = ciudades.nombre_ciudad;
                ci.Regiones = ciudades.Regiones;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_region = new SelectList(db.Regiones, "id_region", "nombre_region", ciudades.id_region);
            return View(ciudades);
        }

        // GET: Ciudades/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            if (ciudades == null)
            {
                return HttpNotFound();
            }
            return View(ciudades);
        }

        // POST: Ciudades/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Ciudades ciudades = await db.Ciudades.FindAsync(id);
            //db.Ciudades.Remove(ciudades);
            ciudades.suspencion = true;
            ciudades.fecha_suspencion = DateTime.Now;
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
