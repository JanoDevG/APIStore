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
    public class Tipo_LicenciasController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Tipo_Licencias
        public async Task<ActionResult> Index()
        {
            List<Tipo_Licencias> listaUsu = db.Tipo_Licencias.Where(x => x.suspencion == false).ToList();
            return View(listaUsu);
        }

        // GET: Tipo_Licencias/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Licencias tipo_Licencias = await db.Tipo_Licencias.FindAsync(id);
            if (tipo_Licencias == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Licencias);
        }

        // GET: Tipo_Licencias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Tipo_Licencias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Tipo_Licencias tipo_Licencias)
        {
            if (ModelState.IsValid)
            {
                Tipo_Licencias tip = await db.Tipo_Licencias.Where(x => x.id_licencia == tipo_Licencias.id_licencia).FirstOrDefaultAsync();
                if (tip == null)
                {
                    db.Tipo_Licencias.Add(tipo_Licencias);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            return View(tipo_Licencias);
        }

        // GET: Tipo_Licencias/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Licencias tipo_Licencias = await db.Tipo_Licencias.FindAsync(id);
            if (tipo_Licencias == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Licencias);
        }

        // POST: Tipo_Licencias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Tipo_Licencias tipo_Licencias)
        {
            if (ModelState.IsValid)
            {
                Tipo_Licencias lis = db.Tipo_Licencias.Find(tipo_Licencias.id_licencia);
                lis.nombre_licencia = tipo_Licencias.nombre_licencia;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(tipo_Licencias);
        }

        // GET: Tipo_Licencias/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tipo_Licencias tipo_Licencias = await db.Tipo_Licencias.FindAsync(id);
            if (tipo_Licencias == null)
            {
                return HttpNotFound();
            }
            return View(tipo_Licencias);
        }

        // POST: Tipo_Licencias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Tipo_Licencias tipo_Licencias = await db.Tipo_Licencias.FindAsync(id);
            tipo_Licencias.suspencion = true;
            tipo_Licencias.fecha_suspencion = DateTime.Now;
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
