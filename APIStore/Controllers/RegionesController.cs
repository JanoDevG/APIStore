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
    public class RegionesController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Regiones
        public async Task<ActionResult> Index()
        {
            List<Regiones> listaUsu = db.Regiones.Where(x => x.suspencion == false).ToList();
            return View(listaUsu);
        }

        // GET: Regiones/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = await db.Regiones.FindAsync(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // GET: Regiones/Create
        public ActionResult Create()
        {
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais");
            return View();
        }

        // POST: Regiones/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                Regiones reg = await db.Regiones.Where(x => x.id_region == regiones.id_region).FirstOrDefaultAsync();
                if (reg == null)
                {
                    db.Regiones.Add(regiones);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", regiones.id_pais);
            return View(regiones);
        }

        // GET: Regiones/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = await db.Regiones.FindAsync(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", regiones.id_pais);
            return View(regiones);
        }

        // POST: Regiones/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Regiones regiones)
        {
            if (ModelState.IsValid)
            {
                Regiones reg = db.Regiones.Find(regiones.id_region);
                reg.nombre_region = regiones.nombre_region;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_pais = new SelectList(db.Paises, "id_pais", "nombre_pais", regiones.id_pais);
            return View(regiones);
        }

        // GET: Regiones/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Regiones regiones = await db.Regiones.FindAsync(id);
            if (regiones == null)
            {
                return HttpNotFound();
            }
            return View(regiones);
        }

        // POST: Regiones/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Regiones regiones = await db.Regiones.FindAsync(id);
            regiones.suspencion = true;
            regiones.fecha_suspencion = DateTime.Now;
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
