using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using CapasDatos;

namespace CapaNegocio
{
    public class CN_Productos
    {
        private CD_Productos objectoCD = new CD_Productos();

        public DataTable MostrarProd()
        {
            DataTable tabla = new DataTable();
            tabla = objectoCD.Mostrar();
            return tabla;
        }

        public void  InsertarMod(String Nombre, String Descripcion, String Marca, String Precio, String sctok)
        {
            objectoCD.Insertar(Nombre, Descripcion, Marca, Convert.ToDouble(Precio), Convert.ToInt32(sctok));
        }

        public void EditarMod(String Nombre, String Descripcion, String Marca, String Precio, String sctok, String id)
        {
            objectoCD.Editar(Nombre, Descripcion, Marca, Convert.ToDouble(Precio), Convert.ToInt32(sctok),Convert.ToInt32(id));
        }

        public void EliminarMod(String id)
        {
            objectoCD.Eliminar(Convert.ToInt32(id));
        }
    }
}
