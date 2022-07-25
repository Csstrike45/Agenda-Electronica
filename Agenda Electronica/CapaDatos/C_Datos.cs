using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using CapaEntidad;

namespace CapaDatos
{
    public class C_Datos
    {
        SqlConnection connect = new SqlConnection(ConfigurationManager.ConnectionStrings["connection"].ConnectionString);

        public List<C_Entidad> BuscarContactos(string buscar)
        {
            SqlDataReader Leer;
            SqlCommand cmd = new SqlCommand("SP_BUSCAR", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            connect.Open();

            cmd.Parameters.AddWithValue("@BUSCAR", buscar);
            Leer = cmd.ExecuteReader();

            List<C_Entidad> Search = new List<C_Entidad>();
            while (Leer.Read())
            {
                Search.Add(new C_Entidad
                {
                    ID = Leer.GetInt32(0),
                    Nombre = Leer.GetString(1),
                    Apellido = Leer.GetString(2),
                    Direccion = Leer.GetString(3),
                    FechaNacimiento = Leer.GetDateTime(4),
                    Genero = Leer.GetString(5),
                    EstadoCivil = Leer.GetString(6),
                    Movil = Leer.GetString(7),
                    Telefono = Leer.GetString(8),
                    Correo = Leer.GetString(9)
                });
            }
            connect.Close();
            Leer.Close();

            return Search;
        }

        public void InsertarContacto(C_Entidad c_Entidad)
        {
            SqlCommand cmd = new SqlCommand("SP_INSERTAR", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            connect.Open();

            cmd.Parameters.AddWithValue("@NOMBRE", c_Entidad.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", c_Entidad.Apellido);
            cmd.Parameters.AddWithValue("@DIRECCION", c_Entidad.Direccion);
            cmd.Parameters.AddWithValue("@FNACIMIENTO", c_Entidad.FechaNacimiento);
            cmd.Parameters.AddWithValue("@GENERO", c_Entidad.Genero);
            cmd.Parameters.AddWithValue("@ESTADOCIVIL", c_Entidad.EstadoCivil);
            cmd.Parameters.AddWithValue("@MOVIL", c_Entidad.Movil);
            cmd.Parameters.AddWithValue("@TELEFONO", c_Entidad.Telefono);
            cmd.Parameters.AddWithValue("@CORREO", c_Entidad.Correo);

            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void EditarContacto(C_Entidad c_Entidad)
        {
            SqlCommand cmd = new SqlCommand("SP_MODIFICAR", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            connect.Open();

            cmd.Parameters.AddWithValue("@ID", c_Entidad.ID);
            cmd.Parameters.AddWithValue("@NOMBRE", c_Entidad.Nombre);
            cmd.Parameters.AddWithValue("@APELLIDO", c_Entidad.Apellido);
            cmd.Parameters.AddWithValue("@DIRECCION", c_Entidad.Direccion);
            cmd.Parameters.AddWithValue("@FNACIMIENTO", c_Entidad.FechaNacimiento);
            cmd.Parameters.AddWithValue("@GENERO", c_Entidad.Genero);
            cmd.Parameters.AddWithValue("@ESTADOCIVIL", c_Entidad.EstadoCivil);
            cmd.Parameters.AddWithValue("@MOVIL", c_Entidad.Movil);
            cmd.Parameters.AddWithValue("@TELEFONO", c_Entidad.Telefono);
            cmd.Parameters.AddWithValue("@CORREO", c_Entidad.Correo);

            cmd.ExecuteNonQuery();
            connect.Close();
        }

        public void EliminarContacto(C_Entidad c_Entidad)
        {
            SqlCommand cmd = new SqlCommand("SP_ELIMINAR", connect);
            cmd.CommandType = CommandType.StoredProcedure;
            connect.Open();

            cmd.Parameters.AddWithValue("@ID", c_Entidad.ID);
            

            cmd.ExecuteNonQuery();
            connect.Close();    
        }
    }
}
