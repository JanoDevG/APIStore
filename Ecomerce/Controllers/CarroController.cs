using Ecomerce.Models;
using ModelAPIStore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Ecomerce.Controllers
{
    public class CarroController : Controller
    {
        private APIStoreEntities1 db = new APIStoreEntities1();

        public ActionResult Index()
        {
            return View();
        }
        // GET: Home
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
            return Json(
                new {
                    total,
                    cantidad,
                    elementos = carrito.Elementos.Select(x => new
                    {
                        x.id_producto,
                        x.nombre_producto,
                        x.precio,
                        x.Cantidad,
                        x.SubTotal
                    })
                }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Eliminar(int id_producto)
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
            carrito.Eliminar(id_producto);
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

        public ActionResult Pagar()
        {
            UsuariosViewModel usu = (UsuariosViewModel)Session["Usuario"];
            if (usu == null)
            {
                return Redirect("/Usuarios/Index");
            }
            Factura fac = new Factura();
            fac.fecha_facturacion = DateTime.Now;
            fac.id_factura = ((UsuariosViewModel)Session["Usuario"]).Id;
            Carritos miCarrito = null;

            miCarrito = (Carritos)Session["carrito"];
            if (miCarrito != null)
            {
                ///*Ventas.montotal*/ = (short)miCarrito.Totalizar();
                foreach (var item in miCarrito.Elementos)
                {
                    /*venta.detalleVenta.Add(new DetalleVenta){
                     * cantidad = fac.cantidad,
                     * idprod = det.id,
                     * subtotal = (short det.subtotal)
                     * }*/
                }
            }
            db.Factura.Add(fac);
            db.SaveChanges();
            ViewBag.Mensaje = "Pago hecho con éxito";
            return View();
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