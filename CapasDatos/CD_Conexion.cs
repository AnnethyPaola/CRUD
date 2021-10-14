using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace CapasDatos
{
    class CD_Conexion
    {
        private SqlConnection Conexion = new SqlConnection("Server=(local);DATABASE= bd;Integrated Security=true");

        public SqlConnection AbrirConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Open();
            return Conexion;
        }
         public SqlConnection CerrarConexion()
        {
            if (Conexion.State == ConnectionState.Closed)
                Conexion.Close();
            return Conexion;
        }

    }
}
