using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeguridadEmpleados.Models
{
    public class ValidateUsers
    {
        ModeloEmpleados modelo;
        public ValidateUsers()
        {
            modelo = new ModeloEmpleados();
        }
            
        public String Role { get; set; }

        public bool ExisteUsuario(String apellido,int empno)
        {
            List<EMP> emp = modelo.GetEmpleados();
            foreach(var usuario in emp)
            {
                if((usuario.APELLIDO==apellido.ToUpper() && usuario.EMP_NO == empno) &&
                    (usuario.OFICIO=="PRESIDENTE"))
                {
                    this.Role = "PRESIDENTE";
                    return true;
                }
                if ((usuario.APELLIDO == apellido.ToUpper() && usuario.EMP_NO == empno) &&
                   (usuario.OFICIO == "DIRECTOR"))
                {
                    this.Role = "DIRECTOR";
                    return true;
                }
                if ((usuario.APELLIDO == apellido.ToUpper() && usuario.EMP_NO == empno) &&
                   (usuario.OFICIO == "ANALISTA"))
                {
                    this.Role = "ANALISTA";
                    return true;
                }

            }
            return false;
        }
    }
}

/*this.Role = "AMDMINISTRADOR";
                        return true;
 if((emp.Exists(z => z.APELLIDO == apellido)==true) && (emp.Exists(z => z.EMP_NO == empno) == true))*/
