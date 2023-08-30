using System;
using System.Collections.Generic;
using Dominio;
using Data;
using System.Data.SqlTypes;

namespace Negocio
{
    public class NegocioArticulo
    {
        DataAccess datos = null;
        List<Articulo> Articulos = null;
        List<string> imagenes = null;
        Articulo articulo;
        public List<Categoria> categorias;
        public List<Marca> marcas;
        public List<int> idMarcas;

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
                datos.SetQuery("SELECT UrlImagen FROM IMAGENES WHERE IdArticulo = @id", "query");
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
        
        //TODO: Listar Articulo por id
        public List<Articulo> ListarArticulo(int idArticulo)
        {
            datos = new DataAccess();
            Articulos = new List<Articulo>();
            try
            {
                articulo = new Articulo();
                datos.AbrirConexion();
                datos.SetQuery("SELECT A.Id, A.Nombre, A.Descripcion, A.IdMarca, M.Descripcion AS 'Marca', A.IdCategoria, C.Descripcion AS 'Categoria', A.Precio, A.Estado, A.Stock, A.ImagenUrl FROM ARTICULOS AS A INNER JOIN MARCAS AS M ON A.IdMarca = M.Id INNER JOIN CATEGORIAS AS C ON A.IdCategoria = C.Id WHERE A.Id = @id", "query");
                datos.SetParameters("@id", idArticulo);
                datos.ReadQuery();
                var aux = datos.Lector;
                while (datos.Lector.Read())
                {
                    articulo = new Articulo();
                    articulo.Id = (int)aux["Id"];
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

        //TODO: ELiminar Articulo
        public int eliminarArticulo(int idArticulo)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("DELETE FROM ARTICULOS WHERE Id = @id", "query");
                datos.SetParameters("@id", idArticulo);
                return datos.ExecuteQuery();
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

        //TODO: Crear Articulo
        public int crearArticulo(Articulo articulo)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("INSERT INTO ARTICULOS (ID,Nombre,Descripcion,IdMarca,IdCategoria,Precio,Estado,Stock,ImagenUrl) VALUES (@Id,@nombre,@descripcion,@idMarca,@idCategoria,@precio,@estado,@stock,@imagenUrl)", "query");
                datos.SetParameters("@Id", articulo.Id);
                datos.SetParameters("@nombre", articulo.Nombre);
                datos.SetParameters("@descripcion", articulo.Descripcion);
                datos.SetParameters("@idMarca", articulo.Marca.Id);
                datos.SetParameters("@idCategoria", articulo.Categoria.Id);
                datos.SetParameters("@precio", articulo.precio);
                datos.SetParameters("@estado", articulo.Estado);
                datos.SetParameters("@stock", articulo.Stock);
                datos.SetParameters("@imagenUrl", articulo.ImagenUrl);
                return datos.ExecuteQuery();
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

        //TODO: Editar Articulo
        public int editarArticulo(Articulo articulo)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("UPDATE ARTICULOS SET Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, Precio = @precio, Estado = @estado, Stock = @stock, ImagenUrl = @imagenUrl WHERE Id = @id", "query");
                datos.SetParameters("@id", articulo.Id);
                datos.SetParameters("@nombre", articulo.Nombre);
                datos.SetParameters("@descripcion", articulo.Descripcion);
                datos.SetParameters("@idMarca", articulo.Marca.Id);
                datos.SetParameters("@idCategoria", articulo.Categoria.Id);
                datos.SetParameters("@precio", articulo.precio);
                datos.SetParameters("@estado", articulo.Estado);
                datos.SetParameters("@stock", articulo.Stock);
                datos.SetParameters("@imagenUrl", articulo.ImagenUrl);
                return datos.ExecuteQuery();
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

        //TODO: Dar Alta/Baja ARTICULO, error el nombre
        public int DarAltaBajaUsuario(int id, bool estado)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("UPDATE ARTICULOS SET Estado = @estado WHERE Id = @id", "query");
                SqlBoolean sqlBoolEstado = estado;
                datos.SetParameters("@estado", sqlBoolEstado);
                datos.SetParameters("@id", id);
                return datos.ExecuteQuery();
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

        //TODO: Listar Articulos dropdowlist
        public List<int> ListarIdArticulos()
        {
            datos = new DataAccess();
            try
            {
                idMarcas = new List<int>();
                int id = 0;
                datos.AbrirConexion();
                datos.SetQuery("SELECT Id FROM ARTICULOS", "query");
                datos.ReadQuery();
                while(datos.Lector.Read())
                {
                    id = Convert.ToInt32(datos.Lector["Id"]);
                    idMarcas.Add(id);
                }
                return idMarcas;
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        //TODO: Comprobar si Existe ID
        public int ComprobarId(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT COUNT(*) FROM ARTICULOS WHERE Id = @id", "query");
                datos.SetParameters("@id", id);
                int res = Convert.ToInt32(datos.ExecuteScalar());
                return res;
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
