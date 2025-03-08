using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    internal class CD_Conexion
    {
        private SqlConnection db_conexion = new SqlConnection("Data Source=LAPTOP-CVRIVISB\\SQLEXPRESS;Initial Catalog=db_AgenciaCarros;Integrated Security=True;Encrypt=False");

        public SqlConnection MtdAbrirConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
                db_conexion.Open();
            return db_conexion;
        }

        public SqlConnection MtdCerrarConexion()
        {
            if (db_conexion.State == ConnectionState.Closed)
                db_conexion.Close();
            return db_conexion;
        }
    }
}
