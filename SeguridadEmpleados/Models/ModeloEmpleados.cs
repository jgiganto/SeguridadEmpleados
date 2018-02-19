using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SeguridadEmpleados.Models;

namespace SeguridadEmpleados.Models
{

    public class ModeloEmpleados
    {
        ContextoEmpleados contexto;
        public ModeloEmpleados()
        {
            contexto = new ContextoEmpleados();
        }

        public List<EMP> GetEmpleados()
        {
            var consulta = from datos in contexto.EMP
                           select datos;
            if (consulta.Count() == 0)
            {
                return null;
            }
            else
            {
                return consulta.ToList();
            }

        }
    }
}