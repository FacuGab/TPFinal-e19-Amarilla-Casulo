using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data;
using Dominio;


namespace Negocio
{
    public class NegocioCategoria
    {
        DataAccess datos = null;
        List<Categoria> categorias = null;

        //TODO: Listar Categorias
        public List<Categoria> ListarCategorias() 
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                //Marca marca;
                categorias = new List<Categoria>();

                datos.AbrirConexion();
                datos.SetQuery("SELECT Id, Descripcion, UrlImagen FROM CATEGORIAS", "query");
                datos.ReadQuery();

                var aux = datos.Lector;
                while (aux.Read())
                {
                    categorias.Add(new Categoria( (int)aux["Id"], aux["Descripcion"].ToString(), aux["UrlImagen"].ToString() ));
                }
                return categorias;
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
