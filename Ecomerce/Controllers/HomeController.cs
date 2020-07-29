using ModelAPIStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ecomerce.Controllers
{
    public class HomeController : Controller
    {
        // GET: Carro
        private APIStoreEntities1 db = new APIStoreEntities1();
        public ActionResult Index(int pagina = 1)
        {
            List<Tipo_Licencias> lis = db.Tipo_Licencias.ToList();
            int mostrar = 2;
            int saltar = (pagina - 1) * mostrar;
            List<Productos> productos = db.Productos
                .OrderBy(x => x.precio)
                .Skip(saltar)
                .Take(mostrar)
                .ToList();
            decimal total = db.Productos.Count();
            decimal paginacion = Math.Ceiling(total / mostrar);
            ViewBag.Paginacion = paginacion;
            ViewBag.pag = pagina;
            return View(productos);
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