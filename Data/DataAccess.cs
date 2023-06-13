using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace Data
{
    public class DataAccess
    {
        SqlDataReader reader = null;
        SqlCommand cmd = null;
        SqlConnection connection;
        public SqlDataReader Lector { get { return reader; } }

        //TODO: Abrir Conexion
        public void AbrirConexion(string server = ".") //  "Manulo-PC\\SQLLABO"
        {
            string path = $"server={server}; database = CATALOGO_E19; integrated security = true";
            try
            {
                connection = new SqlConnection(path);
                connection.Open();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Cerrar Conexion
        public void CerrarConexion()
        {
            try
            {
                if(reader != null) 
                {
                    reader.Close();
                    reader.Dispose();
                }
                if(cmd != null)
                    cmd.Dispose();

                connection.Close();
                connection.Dispose();
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Setear Query
        public void SetQuery(string query, string tipo)
        {
            // si tipo == 'query', es una consulta normal, si tipo == 'sp', es una consuilta mediante stored procedure
            try
            {
                cmd = new SqlCommand();

                if(tipo == "query")
                    cmd.CommandType = System.Data.CommandType.Text;
                else if(tipo == "sp")
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                cmd.CommandText = query;
                cmd.Connection = connection;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Ejecutar Query
        public int ExecuteQuery()
        {
            try
            {
               return cmd.ExecuteNonQuery();
            }
            catch (SqlException ex) 
            {
                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Leer Datos
        public void ReadQuery()
        {
            try
            {
                reader = cmd.ExecuteReader();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Setear Parametros
        public void SetParameters(string name, object value)
        {
            try
            {
                cmd.Parameters.AddWithValue(name, value);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}