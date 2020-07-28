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

        [HttpPost]
        public JsonResult Agregar(Productos productos)
        {
            productos = db.Productos.Find(productos.id_producto);
            Carritos carrito = null;
            if (Session["carrito"] == null)
            {
                carrito = new Carritos();
            }
            else
            {
                carrito = (Carritos)Session["carrito"];
            }
            carrito.Agregar(productos);
            Session["carrito"] = carrito;
            int total = carrito.Totalizar();
            return Json(carrito.Elementos.Select(x => new { x.nombre_producto, x.precio, x.Cantidad, x.SubTotal, total }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Traer()
        {
            Carritos carrito = null;
            if (Session["carrito"] == null)
            {
                carrito = new Carritos();
            }
            else
            {
                carrito = (Carritos)Session["carrito"];
            }
            int cantidad = carrito.Contar();
            int total = carrito.Totalizar();
            return Json(carrito.Elementos.Select(x => new
            {
                x.id_producto,
                x.nombre_producto,
                x.precio,
                x.Cantidad,
                x.SubTotal,
                total,
                cantidad
            }), JsonRequestBehavior.AllowGet);
        }

        public JsonResult Eliminar(int id)
        {
            Carritos carrito = null;
            if (Session["carrito"] == null)
            {
                carrito = new Carritos();
            }
            else
            {
                carrito = (Carritos)Session["carrito"];
            }
            carrito.Eliminar(id);
            return Json(new { Mensaje = "Elemento eliminado", Estado = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult Editar(int id, sbyte Cantidad)
        {
            Carritos carrito = null;
            if (Session["carrito"] == null)
            {
                carrito = new Carritos();
            }
            else
            {
                carrito = (Carritos)Session["carrito"];
            }
            carrito.Editar(id, Cantidad);
            return Json(new { Mensaje = "editado con exito", Estado = true });
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