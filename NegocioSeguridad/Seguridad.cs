using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using NegocioUsuario;

namespace NegocioSeguridad
{
    public static class Seguridad
    {
        public static bool SesionActiva(object user)
        {
            Usuario Acceso = user != null ? (Usuario)user : null;
            if (Acceso == null || Acceso.Id==0)
            {
                return false;
            }
            else
            {
                return true;
            }

        }
    }
}
