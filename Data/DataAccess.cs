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

        //TODO: Abrir Conexion
        public void AbrirConexion(string path, string server = ".")
        {
            path = $"server={server}; database = CATALOGO_P3_DB; integrated security = true";
            try
            {
                connection = new SqlConnection(server);
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
    }
}
