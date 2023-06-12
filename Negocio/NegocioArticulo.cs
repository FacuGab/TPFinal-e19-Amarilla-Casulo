using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;
using Data;

namespace Negocio
{
    public class NegocioArticulo
    {
        DataAccess datos = null;
        List<Articulo> Articulos = null;

        //TODO: Leer Datos
        public List<Articulo> ReadData()
        {
            datos = new DataAccess();
            Articulos = new List<Articulo>();
            Articulo articulo = new Articulo();

            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                datos.SetQuery("SELECT A.Id, A.Codigo, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS 'Marca', A.IdCategoria, C.Descripcion AS 'Categoria', A.Precio, A.Estado, A.Stock FROM ARTICULOS AS A INNER JOIN MARCAS AS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id", "query"); // query para una consulta normal, sp para un stored procedure
                datos.ReadQuery();
                var aux = datos.Lector;
                while(datos.Lector.Read())
                {
                    articulo = new Articulo();
                    articulo.Id = (int)aux["Id"];
                    articulo.Cod = aux["Codigo"].ToString();
                    articulo.Nombre = aux["Nombre"].ToString();
                    articulo.Descripcion = aux["Descripcion"].ToString();

                    articulo.Marca.Id = (int)aux["IdMarca"];
                    articulo.Marca.Descripcion = aux["Marca"].ToString();

                    articulo.Categoria.Id = (int)aux["IdCategoria"];
                    articulo.Categoria.Descripcion = aux["Categoria"].ToString();

                    articulo.precio = (decimal)aux["Precio"];
                    articulo.Estado = (bool)aux["Estado"];
                    articulo.Stock = (int)aux["Stock"];
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

    }//Fin NegocioArticulo
}
