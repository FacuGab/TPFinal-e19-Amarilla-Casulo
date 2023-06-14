using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Data;
using System.Globalization;

namespace Negocio
{
    public class NegocioArticulo
    {
        DataAccess datos = null;
        List<Articulo> Articulos = null;
        List<string> imagenes = null;

        //TODO: Listar Articulos
        public List<Articulo> ListarArticulos()
        {
            datos = new DataAccess();
            Articulos = new List<Articulo>();
            Articulo articulo;

            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                datos.SetQuery("SELECT A.Id, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS 'Marca', A.IdCategoria, C.Descripcion AS 'Categoria', A.Precio, A.Estado, A.Stock, A.ImagenUrl FROM ARTICULOS AS A INNER JOIN MARCAS AS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id", "query");
                datos.ReadQuery();
                var aux = datos.Lector;
                while (datos.Lector.Read())
                {
                    articulo = new Articulo();
                    articulo.Id = (int)aux["Id"];
                    //articulo.Cod = aux["Codigo"].ToString();
                    articulo.Nombre = aux["Nombre"].ToString();
                    articulo.Descripcion = aux["Descripcion"].ToString();

                    articulo.Marca.Id = (int)aux["IdMarca"];
                    articulo.Marca.Descripcion = aux["Marca"].ToString();

                    articulo.Categoria.Id = (int)aux["IdCategoria"];
                    articulo.Categoria.Descripcion = aux["Categoria"].ToString();

                    articulo.precio = (decimal)aux["Precio"];
                    articulo.Estado = (bool)aux["Estado"];
                    articulo.Stock = (int)aux["Stock"];
                    articulo.ImagenUrl = aux["ImagenUrl"].ToString();

                    Articulos.Add(articulo);
                }
                return Articulos;
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

        //TODO: Listar Imagenes Articulos x Id
        public List<string> ListarImagenesArticulos(int idArticulo)
        {
            datos = new DataAccess();
            try
            {
                imagenes = new List<string>();
                datos.AbrirConexion();
                datos.SetQuery("SELECT UrlImagen FROM IMAGENES WHERE @id = IdArticulo", "query");
                datos.SetParameters("@id", idArticulo);
                datos.ReadQuery();

                var aux = datos.Lector;
                while (aux.Read())
                {
                    imagenes.Add(aux["UrlImagen"].ToString());
                }
                return imagenes;
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


        //TODO: Listar categorias
        //TODO: Listar Articulos
    }//Fin NegocioArticulo
}
