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
        List<string> imagenes = null;

        //TODO: Listar Marcas
        public List<Marca> ListarMarcas()
        {
            datos = new DataAccess();
            try
            {
                //Marca marca;
                marcas = new List<Marca>();

                datos.AbrirConexion();
                datos.SetQuery("SELECT Id, Descripcion FROM MARCAS", "query");
                datos.ReadQuery();

                var aux = datos.Lector;
                while(aux.Read())
                {
                    //marca = new Marca( (int)aux["Id"], aux["Descripcion"].ToString() );
                    marcas.Add( new Marca( (int)aux["Id"], aux["Descripcion"].ToString()) );
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

        //TODO: Listar Fotos Marcas x Id
        //public List<string> ListarImagenesMarcas(int idMarca)
        //{
        //    datos = new DataAccess();
        //    try
        //    {
        //        imagenes = new List<string>();
        //        datos.AbrirConexion();
        //        datos.SetQuery("SELECT UrlImagen FROM IMAGENES WHERE IdMarca = @id", "query");
        //        datos.SetParameters("@id", idMarca);
        //        datos.ReadQuery();

        //        var aux = datos.Lector;
        //        while(aux.Read())
        //        {
        //            imagenes.Add( aux["UrlImagen"].ToString() );
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
