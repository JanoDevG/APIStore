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
    public class CuentasController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        // GET: Cuentas
        public ActionResult Index()
        {
            List<Cuentas> lis = db.Cuentas.Where(x => x.suspencion == false  | x.suspencion == null).ToList();
            return View(lis);
        }

        // GET: Cuentas/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = await db.Cuentas.FindAsync(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // GET: Cuentas/Create
        public ActionResult Create()
        {
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario");
            return View();
        }

        // POST: Cuentas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                Cuentas ci = await db.Cuentas.Where(x => x.id_cuenta == cuentas.id_cuenta).FirstOrDefaultAsync();
                cuentas.fecha_creacion = DateTime.Now;
                if (ci == null)
                {
                    db.Cuentas.Add(cuentas);
                    await db.SaveChangesAsync();
                }
                return RedirectToAction("Index");
            }

            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", cuentas.id_usuario);
            return View(cuentas);
        }

        // GET: Cuentas/Edit/5
        public async Task<ActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = await db.Cuentas.FindAsync(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", cuentas.id_usuario);
            return View(cuentas);
        }

        // POST: Cuentas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que quiere enlazarse. Para obtener 
        // más detalles, vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Cuentas cuentas)
        {
            if (ModelState.IsValid)
            {
                Cuentas cu = await db.Cuentas.FindAsync(cuentas.id_cuenta);
                cu.correo = cuentas.correo;
                cu.password = cuentas.password;
                await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            ViewBag.id_usuario = new SelectList(db.Usuarios, "id_usuario", "nombre_usuario", cuentas.id_usuario);
            return View(cuentas);
        }

        // GET: Cuentas/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cuentas cuentas = await db.Cuentas.FindAsync(id);
            if (cuentas == null)
            {
                return HttpNotFound();
            }
            return View(cuentas);
        }

        // POST: Cuentas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteConfirmed(int id)
        {
            Cuentas cuentas = await db.Cuentas.FindAsync(id);
            cuentas.suspencion = true;
            cuentas.fecha_suspencion = DateTime.Now;
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
