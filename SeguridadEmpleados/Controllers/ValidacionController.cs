using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using SeguridadEmpleados.Models;

namespace SeguridadEmpleados.Controllers
{
    public class ValidacionController : Controller
    {
        // GET: Validacion
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(String apellido, int empno)
        {
            ValidateUsers validacion = new ValidateUsers();
            if(validacion.ExisteUsuario(apellido,empno))
            {
                FormsAuthenticationTicket ticket =
                    new FormsAuthenticationTicket(1, apellido, DateTime.Now,
                    DateTime.Now.AddSeconds(30), true, validacion.Role,
                    FormsAuthentication.FormsCookiePath);

                String ticketcifrado = FormsAuthentication.Encrypt(ticket);

                HttpCookie cookie = new HttpCookie("cookieusuario", ticketcifrado);
                Response.Cookies.Add(cookie);
                return RedirectToAction("Index", "Administracion");
            }
            else
            {
                ViewBag.Mensaje = "Usuario o PW incorrectos";
            }
            return View();
             
        }
        public ActionResult ErrorAcceso()
        {
            return View();
        }

    }
}