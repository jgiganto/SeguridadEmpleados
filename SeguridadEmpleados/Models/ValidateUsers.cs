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
                if((usuario.APELLIDO==apellido && usuario.EMP_NO == empno) &&
                    (usuario.OFICIO=="PRESIDENTE"||usuario.OFICIO== "DIRECTOR"))
                {
                    this.Role = "AMDMINISTRADOR";
                    return true;
                }
                else
                {
                    return false;
                }
            }
            return false;
        }
    }
}

/*this.Role = "AMDMINISTRADOR";
                        return true;
 if((emp.Exists(z => z.APELLIDO == apellido)==true) && (emp.Exists(z => z.EMP_NO == empno) == true))*/
