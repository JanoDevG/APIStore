using Ecomerce.Models;
using ModelAPIStore;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ecomerce.Controllers
{
    public class UsuariosController : Controller
    {
        private readonly APIStoreEntities1 db = new APIStoreEntities1();
        // GET: Usuarios
        public ActionResult Index()
        {
            return View();
        }

        public async System.Threading.Tasks.Task<ActionResult> LoginAsync(string email, string password)
        {
            var cuenta = await db.Cuentas.Where(x => x.correo == email && x.password == password).FirstOrDefaultAsync();
            if (cuenta == null)
            {
                if (cuenta != null)
                {
                    UsuariosViewModel mod = new UsuariosViewModel();
                    mod.Id = cuenta.id_cuenta;
                    //mod.Nombre = //usuario.nombre;
                }
                Session["Usuario"] = cuenta;
                return Redirect("Home/Index");
            }
            else
            {
                ViewBag.Mensaje = "Datos incorrecto, verifique para reintentar";
                return View("Index");
            }
            
        }

        public ActionResult Registro()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Registrar(string email, string apodo, string password, string rePassword)
        {
            if (password != rePassword)
            {
                ViewBag.Mensaje = "Las contraseñas no coinciden, reintente";
                return View("Registro");
            }
            Cuentas usu = null;
            usu = db.Cuentas.Where(x => x.correo == email).FirstOrDefault();
            if (usu != null)
            {
                ViewBag.Mensaje = "Registro exitoso";
                return View("Index");
            }
            else
            {
                new Usuarios();
                Cuentas cu = new Cuentas();
                cu.password = password;
                cu.correo = email;
            }
            ViewBag.Mensaje = "Usuario creado con éxito";
            return View("Index");
            
        }

        public ActionResult Cerrar()
        {
            Session["Usuario"] = null;
            ViewBag.Mensaje = "Sesión cerrada";
            return View("Index");
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