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
            return View(await db.Lenguaje_Backend.ToListAsync());
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
        public async Task<ActionResult> Create([Bind(Include = "id_lenguaje,nombre,description,suspencion,fecha_suspencion")] Lenguaje_Backend lenguaje_Backend)
        {
            if (ModelState.IsValid)
            {
                db.Lenguaje_Backend.Add(lenguaje_Backend);
                await db.SaveChangesAsync();
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
        public async Task<ActionResult> Edit([Bind(Include = "id_lenguaje,nombre,description,suspencion,fecha_suspencion")] Lenguaje_Backend lenguaje_Backend)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lenguaje_Backend).State = EntityState.Modified;
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
            db.Lenguaje_Backend.Remove(lenguaje_Backend);
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
