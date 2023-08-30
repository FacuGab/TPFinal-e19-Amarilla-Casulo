using System;
using System.Collections.Generic;
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
        //TODO: Setear Parametros
        public Categoria BuscarCategoria(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT Id, Descripcion, UrlImagen FROM CATEGORIAS WHERE Id = @id", "query");
                datos.SetParameters("@id", id);
                datos.ReadQuery();

                var aux = datos.Lector;
                aux.Read();
                return new Categoria((int)aux["Id"], aux["Descripcion"].ToString(), aux["UrlImagen"].ToString());
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
        public Categoria editarCategoria(Categoria categoria)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("UPDATE CATEGORIAS SET Descripcion = @descripcion, UrlImagen = @urlImagen WHERE Id = @id", "query");
                datos.SetParameters("@descripcion", categoria.Descripcion);
                datos.SetParameters("@urlImagen", categoria.UrlImagen);
                datos.SetParameters("@id", categoria.Id);
                datos.ExecuteQuery();
                return categoria;
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
        public Categoria borrarCategoria(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("DELETE FROM CATEGORIAS WHERE Id = @id", "query");
                datos.SetParameters("@id", id);
                datos.ExecuteQuery();
                return new Categoria();
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
        public Categoria agregarCategoria(Categoria categoria)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("INSERT INTO CATEGORIAS (Id, Descripcion, UrlImagen) VALUES (@Id, @descripcion, @urlImagen)", "query");
                datos.SetParameters("@Id", categoria.Id);
                datos.SetParameters("@descripcion", categoria.Descripcion);
                datos.SetParameters("@urlImagen", categoria.UrlImagen);
                datos.ExecuteQuery();
                return categoria;
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
        public bool existCategoria(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT Id FROM CATEGORIAS WHERE Id = @id", "query");
                datos.SetParameters("@id", id);
                datos.ReadQuery();
                var aux = datos.Lector;
                aux.Read();
                if (aux.HasRows)
                {
                    return true;
                }
                else
                {
                    return false;
                }
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
