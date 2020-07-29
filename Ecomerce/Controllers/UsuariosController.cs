using Ecomerce.Models;
using ModelAPIStore;
using System.Data.Entity;
using System.Linq;
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

        public ActionResult Login(string email, string password)
        {
            var usuarios = db.Usuarios.Where(x => x.correo == email && x.password == password).FirstOrDefault();
            if (usuarios != null)
            {
                UsuariosViewModel vm = new UsuariosViewModel();
                vm.Id = usuarios.id_usuario;
                vm.Nombre = usuarios.nombre_usuario;
                Session["Usuario"] = vm;
                return Redirect("/Home/Index");
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
        public ActionResult Registrar(string email, string nombre, string rut, string apellido, string password, string rePassword)
        {
            if (password != rePassword)
            {
                ViewBag.Mensaje = "Las cotraseñas deben coincidir. Verifique para reintentar";
                return View("Registro");
            }
            Usuarios usu = null;
            usu = db.Usuarios.Where(x => x.correo == email).FirstOrDefault();
            if (usu != null)
            {
                ViewBag.Mensaje = "Usuario ya existe";
                return View("Registro");
            }
            else
            {
                usu = new Usuarios();
                usu.nombre_usuario = nombre;
                usu.apellido_usuario = apellido;
                usu.rut_usuario = rut;
                usu.correo = email;
                usu.password = password;
                db.Usuarios.Add(usu);
                db.SaveChanges();
            }
            ViewBag.Mensaje = "Usuario creado con éxito";
            return View("Index");
        }

        public ActionResult Cerrar()
        {
            Session["Usuario"] = null;
            ViewBag.Mensaje = "Sesión cerrada";
            return View("/Home/Index");
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