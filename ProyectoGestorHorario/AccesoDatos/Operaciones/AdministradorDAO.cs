using AccesoDatos.Context;
using AccesoDatos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoDatos.Operaciones
{
    public  class AdministradorDAO
    {
        SistemaContext contexto = new SistemaContext();

        public string login(string correo, string contrasenia)
        {
            Administrador admin = contexto.Administradors.Where(a => a.Correo == correo && a.Contrasenia == contrasenia).FirstOrDefault();
            if(admin == null)
            {
                return null;
            }
            return admin.Correo;
        }

    }
}
