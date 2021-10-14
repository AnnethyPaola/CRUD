using System;
using System.Data;
using System.Data.SqlClient;

namespace CapasDatos
{
    public class CD_Productos
    {
        private CD_Conexion conexion = new CD_Conexion();

        SqlDataReader leer;
        DataTable tabla = new DataTable();
        SqlCommand comando = new SqlCommand();

        public DataTable Mostrar()
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "Select * from productos";
            leer = comando.ExecuteReader();
            tabla.Load(leer);
            conexion.CerrarConexion();
            return tabla;

        }
        public void Insertar(String Nombre, String Descripcion, String Marca, double Precio, int sctok)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "insert into productos values('" + Nombre + "', '" + Descripcion + "', '" + Marca + "', " + Precio + ", " + sctok + ")";
            comando.CommandType = CommandType.Text;
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Editar(String Nombre, String Descripcion, String Marca, double Precio, int sctok, int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "EditarPro";
            comando.CommandType = CommandType.StoredProcedure;
            comando.Parameters.AddWithValue("@Nombre", Nombre);
            comando.Parameters.AddWithValue("@Descripcion", Descripcion);
            comando.Parameters.AddWithValue("@Marca", Marca);
            comando.Parameters.AddWithValue("@Precio", Precio);
            comando.Parameters.AddWithValue("@sctok", sctok);
            comando.Parameters.AddWithValue("@Id", id);
            comando.ExecuteNonQuery();
            comando.Parameters.Clear();
        }

        public void Eliminar(int id)
        {
            comando.Connection = conexion.AbrirConexion();
            comando.CommandText = "eliminarpro";
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@Idpro", id);

            comando.ExecuteNonQuery();

            comando.Parameters.Clear();
        }
    }
}
