using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SeguridadEmpleados.Atributos;
using SeguridadEmpleados.Models;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;


namespace SeguridadEmpleados.Controllers
{
    public class ZonaSeguraController : Controller
    {
        ModeloEmpleados modelo;
        public ZonaSeguraController()
        {
            modelo = new ModeloEmpleados();
        }
        // GET: ZonaSegura
        [AutorizacionPersonalizada]
        public ActionResult Index()
        {
            List<EMP> lista = modelo.GetEmpleados();
            return View(lista);
        }
        public ActionResult Edit(int id, String apellido,String oficio,int salario )
        {
            ViewBag.Apellido = apellido;
            ViewBag.Oficio = oficio;
            ViewBag.Salario = salario;
           
            return View();
        }
        [HttpPost]
        public ActionResult Edit(int id,String apellido, String oficio, int salario,String nada)
        {
           

            return View();
        }
    }
}


 
           