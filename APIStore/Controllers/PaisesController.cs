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
    public class PaisesController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Paises
        public ActionResult Index()
        {
            List<Paises> listaUsu = db.Paises.Where(x => x.suspencion == false  | x.suspencion == null).ToList();
            return View(listaUsu);
        }

        // GET: Paises/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // GET: Paises/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Paises/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Paises paises)
        {
            if (ModelState.IsValid)
            {
                Paises pa = await db.Paises.Where(x => x.id_pais == paises.id_pais).FirstOrDefaultAsync();
                if (pa == null)
                {
                    db.Paises.Add(paises);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            return View(paises);
        }

        // GET: Paises/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // POST: Paises/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Paises paises)
        {
            if (ModelState.IsValid)
            {
                Paises pa = db.Paises.Find(paises.id_pais);
                pa.nombre_pais = paises.nombre_pais;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(paises);
        }

        // GET: Paises/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Paises paises = await db.Paises.FindAsync(id);
            if (paises == null)
            {
                return HttpNotFound();
            }
            return View(paises);
        }

        // POST: Paises/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Paises paises = await db.Paises.FindAsync(id);
            paises.suspencion = true;
            paises.fecha_suspencion = DateTime.Now;
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
