using System;
using System.Data.SqlClient;
using System.Configuration;

namespace Data
{
    public class DataAccess
    {
        SqlDataReader reader = null;
        SqlCommand cmd = null;
        SqlConnection connection;
        public object OutputParam { get; set; }
        public SqlDataReader Lector { get { return reader; } }

        //TODO: Abrir Conexion
        public void AbrirConexion(string server = "Manulo-PC\\SQLLABO") // "Manulo-PC\\SQLLABO"
        {
            //string path = $"server={server}; database = CATALOGO_E19; integrated security = true";
            string pathProp = ConfigurationManager.ConnectionStrings["stringConnectionDefault"].ToString();
            try
            {
                connection = new SqlConnection(pathProp);
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

        //TODO: Setear Query (Importante)
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

        //TODO: Setear Output Value
        public void SetOutputValue(string nombre, object type)
        {
            try
            {
                SqlParameter param = new SqlParameter(nombre, type);
                cmd.Parameters.Add(param).Direction = System.Data.ParameterDirection.Output;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Get valor de Output param
        public object GetOutputParam(string name)
        {
            try
            {
                return cmd.Parameters[name].Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Ejecutar Scalar (test x ahora)
        public object ExecuteScalar()
        {
            try
            {
                var res = cmd.ExecuteScalar();
                return res;
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

        //TODO: Ejecutar Query sin return
        public void ExecWhitOutParam(string name, object type)
        {
            try
            {
                SqlParameter param = new SqlParameter(name, type);
                cmd.Parameters.Add(param).Direction = System.Data.ParameterDirection.Output;
                cmd.ExecuteNonQuery();
                OutputParam = param.Value;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Quitar Parametros
        public void DisposeParameters()
        {
            try
            {
                cmd?.Parameters.Clear();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}