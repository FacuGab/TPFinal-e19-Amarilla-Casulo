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
        List<string> imagenes = null;
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
                datos.SetQuery("SELECT Id, Descripcion FROM CATEGORIAS", "query");
                datos.ReadQuery();

                var aux = datos.Lector;
                while (aux.Read())
                {
                    //marca = new Marca( (int)aux["Id"], aux["Descripcion"].ToString() );
                    categorias.Add(new Categoria((int)aux["Id"], aux["Descripcion"].ToString()));
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

        //TODO: Listar Imagenes Categorias x Id
        //public List<string> ListarImagenesCategorias(int idCategoria)
        //{
        //    datos = new DataAccess();
        //    try
        //    {
        //        imagenes = new List<string>();
        //        datos.AbrirConexion();
        //        datos.SetQuery("SELECT UrlImagen FROM IMAGENES WHERE IdCategoria = @id", "query");
        //        datos.SetParameters("@id", idCategoria);
        //        datos.ReadQuery();

        //        var aux = datos.Lector;
        //        while (aux.Read())
        //        {
        //            imagenes.Add(aux["UrlImagen"].ToString());
        //        }
        //        return imagenes;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw ex;
        //    }
        //    finally
        //    {
        //        datos.CerrarConexion();
        //    }
        //}
    }
}
