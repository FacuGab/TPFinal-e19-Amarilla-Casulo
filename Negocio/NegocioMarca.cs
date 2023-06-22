using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Dominio;

namespace Negocio
{
    public class NegocioMarca
    {
        DataAccess datos = null;
        List<Marca> marcas = null;

        //TODO: Listar Marcas
        public List<Marca> ListarMarcas()
        {
            datos = new DataAccess();
            try
            {
                //Marca marca;
                marcas = new List<Marca>();

                datos.AbrirConexion();
                datos.SetQuery("SELECT Id, Descripcion, UrlImagen FROM MARCAS", "query");
                datos.ReadQuery();

                var aux = datos.Lector;
                while(aux.Read())
                {
                    marcas.Add( new Marca( (int)aux["Id"], aux["Descripcion"].ToString(), aux["UrlImagen"].ToString() ));
                }
                return marcas;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        private Marca EditarMarca(Marca marca)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT Id, Descripcion, UrlImagen FROM MARCAS WHERE Id = @id", "query");
                datos.SetParameters("@id", marca.Id);
                datos.ReadQuery();

                var aux = datos.Lector;
                while (aux.Read())
                {
                    marca.Id = (int)aux["Id"];
                    marca.Descripcion = aux["Descripcion"].ToString();
                    marca.UrlImagen = aux["UrlImagen"].ToString();
                }
                return marca;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
        private void borrarMarca(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("DELETE FROM MARCAS WHERE Id = @id", "query");
                datos.SetParameters("@id", id);
                datos.ExecuteQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
