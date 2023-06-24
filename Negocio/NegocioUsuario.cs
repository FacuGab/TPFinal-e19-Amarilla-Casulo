using Data;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioUsuario
    {
        DataAccess Data;
        List<Usuario> Usuarios;
        Usuario Usuario;

        //TODO: Agregar Usuario
        public void AgregarUsuario(Usuario usuario)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("INSERT INTO USUARIOS (Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen) VALUES (@Nombre, @Apellido, @DNI, @Mail, @Clave, @Direccion, @Nivel, @UrlImagen)", "nonquery");
                Data.SetParameters("@Nombre", usuario.Nombre);
                Data.SetParameters("@Apellido", usuario.Apellido);
                Data.SetParameters("@DNI", usuario.Dni);
                Data.SetParameters("@Mail", usuario.Mail);
                Data.SetParameters("@Clave", usuario.Clave);
                Data.SetParameters("@Direccion", usuario.Direccion);
                Data.SetParameters("@Nivel", usuario.Nivel);
                Data.SetParameters("@UrlImagen", usuario.UrlImgUsuario);
                Data.ExecuteQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CerrarConexion();
            }
        }

        //TODO: Listar Usuarios
        public List<Usuario> ListarUsuarios()
        {
            Data = new DataAccess();
            try
            {
                Usuarios = new List<Usuario>();
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen FROM USUARIOS", "query");
                Data.ReadQuery();

                var aux = Data.Lector;
                while (aux.Read()) 
                {
                    Usuario = new Usuario();
                    Usuario.Id = (int)aux["Id"];
                    Usuario.Nombre = aux["Nombre"].ToString();
                    Usuario.Apellido = aux["Apellido"].ToString();
                    Usuario.Dni = (int)aux["DNI"];
                    Usuario.Mail = aux["Mail"].ToString();
                    Usuario.Clave = aux["Clave"].ToString();
                    Usuario.Direccion = aux["Direccion"].ToString();
                    Usuario.Nivel = Convert.ToChar(aux["Nivel"]);
                    Usuario.UrlImgUsuario = aux["UrlImagen"].ToString();
                    Usuarios.Add(Usuario);
                }
                return Usuarios;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally 
            { 
                Data.CerrarConexion();
            }
        }

        //TODO: Buscar Usuario
        public Usuario BuscarUsuario(int match)
        {
            // se puede buscar por otros campos que tienen qeu ser unicos, DNI, MAIL tienen que ser campos unicos. Por ahora buscar por Id, cambiar despues a distintos metodos de busqueda
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen FROM USUARIOS WHERE Id = @id", "query");
                Data.SetParameters("@id", match);
                Data.ReadQuery();

                var aux = Data.Lector;
                if(aux.Read())
                {
                    Usuario = new Usuario();
                    Usuario.Id = (int)aux["Id"];
                    Usuario.Nombre = aux["Nombre"].ToString();
                    Usuario.Apellido = aux["Apellido"].ToString();
                    Usuario.Dni = (int)aux["DNI"];
                    Usuario.Mail = aux["Mail"].ToString();
                    Usuario.Clave = aux["Clave"].ToString();
                    Usuario.Direccion = aux["Direccion"].ToString();
                    Usuario.Nivel = Convert.ToChar(aux["Nivel"]);
                    Usuario.UrlImgUsuario = aux["UrlImagen"].ToString();
                    return Usuario;
                }
                return null;
            }   
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CerrarConexion();
            }
        }
        public Usuario EliminarUsuario(int match)
        {
            // se puede buscar por otros campos que tienen qeu ser unicos, DNI, MAIL tienen que ser campos unicos. Por ahora buscar por Id, cambiar despues a distintos metodos de busqueda
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("DELETE FROM USUARIOS WHERE Id = @id", "query");
                Data.SetParameters("@id", match);
                Data.ReadQuery();

                var aux = Data.Lector;
                if (aux.Read())
                {
                    Usuario = new Usuario();
                    Usuario.Id = (int)aux["Id"];
                    Usuario.Nombre = aux["Nombre"].ToString();
                    Usuario.Apellido = aux["Apellido"].ToString();
                    Usuario.Dni = (int)aux["DNI"];
                    Usuario.Mail = aux["Mail"].ToString();
                    Usuario.Clave = aux["Clave"].ToString();
                    Usuario.Direccion = aux["Direccion"].ToString();
                    Usuario.Nivel = Convert.ToChar(aux["Nivel"]);
                    Usuario.UrlImgUsuario = aux["UrlImagen"].ToString();
                    return Usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CerrarConexion();
            }
        }
        public Usuario editarUsuario(int match)
        {
            // se puede buscar por otros campos que tienen qeu ser unicos, DNI, MAIL tienen que ser campos unicos. Por ahora buscar por Id, cambiar despues a distintos metodos de busqueda
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("UPDATE USUARIOS SET Nombre = @nombre, Apellido = @apellido, DNI = @dni, Mail = @mail, Clave = @clave, Direccion = @direccion, Nivel = @nivel, UrlImagen = @urlimagen WHERE Id = @id", "query");
                Data.SetParameters("@id", match);
                Data.ReadQuery();

                var aux = Data.Lector;
                if (aux.Read())
                {
                    Usuario = new Usuario();
                    Usuario.Id = (int)aux["Id"];
                    Usuario.Nombre = aux["Nombre"].ToString();
                    Usuario.Apellido = aux["Apellido"].ToString();
                    Usuario.Dni = (int)aux["DNI"];
                    Usuario.Mail = aux["Mail"].ToString();
                    Usuario.Clave = aux["Clave"].ToString();
                    Usuario.Direccion = aux["Direccion"].ToString();
                    Usuario.Nivel = Convert.ToChar(aux["Nivel"]);
                    Usuario.UrlImgUsuario = aux["UrlImagen"].ToString();
                    return Usuario;
                }
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                Data.CerrarConexion();
            }
        }

    }
}
    