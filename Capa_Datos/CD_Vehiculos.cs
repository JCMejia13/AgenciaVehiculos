using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
    public class CD_Vehiculos
    {
        CD_Conexion db_conexion = new CD_Conexion();

        public DataTable MtMostrar()
        {
            string QryMostrar = "exec usp_vehiculos_mostrar;";
            SqlDataAdapter adapter = new SqlDataAdapter(QryMostrar, db_conexion.MtdAbrirConexion());
            DataTable dtMostrar = new DataTable();
            adapter.Fill(dtMostrar);
            db_conexion.MtdCerrarConexion();
            return dtMostrar;
        }

        public void MtdAgregar(string Marca, string Modelo, int Año, double Precio, string Estado)
        {

            string Usp_crear = "usp_vehiculos_agregar";
            SqlCommand cmd_Insertar = new SqlCommand(Usp_crear, db_conexion.MtdAbrirConexion());
            cmd_Insertar.CommandType = CommandType.StoredProcedure;

            cmd_Insertar.Parameters.AddWithValue("@Marca", Marca);
            cmd_Insertar.Parameters.AddWithValue("@Modelo", Modelo);
            cmd_Insertar.Parameters.AddWithValue("@Año", Año);
            cmd_Insertar.Parameters.AddWithValue("@Precio", Precio);
            cmd_Insertar.Parameters.AddWithValue("@Estado", Estado);
            cmd_Insertar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }

        public void MtdActualizar(int VehiculoID, string Marca, string Modelo, int Año, double Precio, string Estado)
        {


            string vUspActualizar = "usp_vehiculos_editar";
            SqlCommand commActualizar = new SqlCommand(vUspActualizar, db_conexion.MtdAbrirConexion());
            commActualizar.CommandType = CommandType.StoredProcedure;


            commActualizar.Parameters.AddWithValue("@VehiculoID", VehiculoID);
            commActualizar.Parameters.AddWithValue("@Marca", Marca);
            commActualizar.Parameters.AddWithValue("@Modelo", Modelo);
            commActualizar.Parameters.AddWithValue("@Año", Año);
            commActualizar.Parameters.AddWithValue("@Precio", Precio);
            commActualizar.Parameters.AddWithValue("@Estado", Estado);
            commActualizar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();

        }


        public void MtdEliminar(int VehiculoID)
        {

            string UspEliminar = "usp_vehiculos_eliminar";
            SqlCommand commEliminar = new SqlCommand(UspEliminar, db_conexion.MtdAbrirConexion());
            commEliminar.CommandType = CommandType.StoredProcedure;
            commEliminar.Parameters.AddWithValue("@VehiculoID", VehiculoID);
            commEliminar.ExecuteNonQuery();

            db_conexion.MtdCerrarConexion();
        }
    }
}
