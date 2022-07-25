using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaEntidad;
using CapaDatos;

namespace CapaNegocio
{
    public class C_Negocio
    {
        C_Datos c_Datos = new C_Datos();

        public List<C_Entidad> Listar(string buscar)
        {
            return c_Datos.BuscarContactos(buscar);
        }

        public void InsertContacto(C_Entidad c_Entidad)
        {
            c_Datos.InsertarContacto(c_Entidad);
        }

        public void EditContacto(C_Entidad c_Entidad)
        {
            c_Datos.EditarContacto(c_Entidad);
        }
        public void DeleteContacto(C_Entidad c_Entidad)
        {
            c_Datos.EliminarContacto(c_Entidad);
        }
    }
}
