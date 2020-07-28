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
    public class Lenguaje_BackendController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Lenguaje_Backend
        public async Task<ActionResult> Index()
        {
            List<Lenguaje_Backend> listaUsu = db.Lenguaje_Backend.Where(x => x.suspencion == false).ToList();
            return View(listaUsu);
        }

        // GET: Lenguaje_Backend/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenguaje_Backend lenguaje_Backend = await db.Lenguaje_Backend.FindAsync(id);
            if (lenguaje_Backend == null)
            {
                return HttpNotFound();
            }
            return View(lenguaje_Backend);
        }

        // GET: Lenguaje_Backend/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Lenguaje_Backend/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Lenguaje_Backend lenguaje_Backend)
        {
            if (ModelState.IsValid)
            {
                Lenguaje_Backend leg = await db.Lenguaje_Backend.Where(x => x.id_lenguaje == lenguaje_Backend.id_lenguaje).FirstOrDefaultAsync();
                if (leg == null)
                {
                    db.Lenguaje_Backend.Add(lenguaje_Backend);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            return View(lenguaje_Backend);
        }

        // GET: Lenguaje_Backend/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenguaje_Backend lenguaje_Backend = await db.Lenguaje_Backend.FindAsync(id);
            if (lenguaje_Backend == null)
            {
                return HttpNotFound();
            }
            return View(lenguaje_Backend);
        }

        // POST: Lenguaje_Backend/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Lenguaje_Backend lenguaje_Backend)
        {
            if (ModelState.IsValid)
            {
                Lenguaje_Backend leg = db.Lenguaje_Backend.Find(lenguaje_Backend.id_lenguaje);
                leg.description = lenguaje_Backend.description;
                leg.nombre = lenguaje_Backend.nombre;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(lenguaje_Backend);
        }

        // GET: Lenguaje_Backend/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Lenguaje_Backend lenguaje_Backend = await db.Lenguaje_Backend.FindAsync(id);
            if (lenguaje_Backend == null)
            {
                return HttpNotFound();
            }
            return View(lenguaje_Backend);
        }

        // POST: Lenguaje_Backend/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Lenguaje_Backend lenguaje_Backend = await db.Lenguaje_Backend.FindAsync(id);
            lenguaje_Backend.suspencion = true;
            lenguaje_Backend.fecha_suspencion = DateTime.Now;
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
