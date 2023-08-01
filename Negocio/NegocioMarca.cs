using System;
using System.Collections.Generic;
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
                    marcas.Add( new Marca( (int)aux["Id"], 
                        aux["Descripcion"].ToString(), 
                        aux["UrlImagen"].ToString() ));
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
        public Marca EditarMarca(Marca marca)
        {
            var marcas = new Marca();
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("UPDATE MARCAS SET Id = @Id,Descripcion = @descripcion, UrlImagen = @urlImagen WHERE Id = @id", "query");
                datos.SetParameters("@Id", marca.Id);
                datos.SetParameters("@descripcion", marca.Descripcion);
                datos.SetParameters("@urlImagen", marca.UrlImagen);
                datos.ExecuteQuery();
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
        public void borrarMarca(int id)
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
        public void AgregarMarca(Marca marca)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("INSERT INTO MARCAS (Id, Descripcion, UrlImagen) VALUES (@Id,@descripcion, @urlImagen)", "query");
                datos.SetParameters("@Id", marca.Id);
                datos.SetParameters("@descripcion", marca.Descripcion);
                datos.SetParameters("@urlImagen", marca.UrlImagen);
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
        public bool ExistMarca(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT Id, Descripcion, UrlImagen FROM MARCAS WHERE Id = @Id", "query");
                datos.SetParameters("@Id", id);
                datos.ReadQuery();
                var aux = datos.Lector;
                if (aux.Read())
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
            }finally
            {
                datos.CerrarConexion();
            }
        }
    }
}
