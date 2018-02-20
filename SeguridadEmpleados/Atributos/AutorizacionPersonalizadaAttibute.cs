using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using System.Security.Principal;


namespace SeguridadEmpleados.Atributos
{
    public class AutorizacionPersonalizadaAttribute: AuthorizeAttribute
    {
        public override void OnAuthorization
            (AuthorizationContext filterContext)

        {
            base.OnAuthorization(filterContext);
            if (filterContext.HttpContext.Request.IsAuthenticated)
            {
                GenericPrincipal usuario =
                    HttpContext.Current.User as GenericPrincipal;
                if (usuario.IsInRole("ADMINISTRADOR") == false)
                {
                    RouteValueDictionary rutaacceso =
                        new RouteValueDictionary(new
                        {
                            controller = "Validacion",
                            action = "ErrorAcceso"
                        });
                    RedirectToRouteResult direccionacceso =
                        new RedirectToRouteResult(rutaacceso);
                    filterContext.Result = direccionacceso;
                }
            }
            else
            {
                RouteValueDictionary ruta =
                    new RouteValueDictionary(new
                    {
                        controller = "Validacion",
                        action = "Login"
                    });
                RedirectToRouteResult direccionlogin =
                    new RedirectToRouteResult(ruta);
                filterContext.Result = direccionlogin;
            }

        }
    }
}