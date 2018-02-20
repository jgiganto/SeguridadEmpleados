using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Security.Principal;

namespace SeguridadEmpleados
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        public void Application_PostAuthenticateRequest(object sender, EventArgs e)
        {
            HttpCookie cookie = Request.Cookies["cookieusuario"];
            if (cookie != null)
            {
                String datoscookie = cookie.Value;
                FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(datoscookie);
                String nombreusuario = ticket.Name;
                String grupousuario = ticket.UserData;
                GenericIdentity identidad = new GenericIdentity(nombreusuario);
                GenericPrincipal usuario =  
                    new GenericPrincipal(identidad, new string[] { grupousuario });
                HttpContext.Current.User = usuario;
            }
        }
    }
}
