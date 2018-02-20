using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeguridadEmpleados.Atributos;
using SeguridadEmpleados.Models;

namespace SeguridadEmpleados.Controllers
{
    public class ZonaSeguraController : Controller
    {
        // GET: ZonaSegura
        [AutorizacionPersonalizada]
        public ActionResult Index()
        {
            return View();
        }
    }
}