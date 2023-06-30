using Data;
using Dominio;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Messaging;
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
        public int AgregarUsuario(Usuario usuario)
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
                return Data.ExecuteQuery();
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

        //TODO: Actualizar Usuario
        public void ActualizarUsuario(Usuario usuario)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("UPDATE USUARIOS SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Mail = @Mail, Clave = @Clave, Direccion = @Direccion, Nivel = @Nivel, UrlImagen = @UrlImagen WHERE ID=@Id" , "query");
                Data.SetParameters("@Id", usuario.Id);
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
                    Usuario.Nivel = aux["Nivel"].ToString();
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

        //TODO: Buscar Usuario (buscar por Id)
        public Usuario BuscarUsuarioPorId(int id)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen FROM USUARIOS WHERE Id = @Id", "query");
                Data.SetParameters("@Id", id);
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
                    Usuario.Nivel = aux["Nivel"].ToString();
                    Usuario.UrlImgUsuario = aux["UrlImagen"].ToString();
                }
                return Usuario;
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

        //TODO: Buscar Usuario (busca por Clave y Mail)
        public Usuario BuscarUsuario(string mail, string clave)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen FROM USUARIOS WHERE Mail = @Mail AND Clave = @Clave", "query");
                Data.SetParameters("@Mail", mail);
                Data.SetParameters("@Clave", clave);
                Data.ReadQuery();

                var aux = Data.Lector;
                while(aux.Read())
                {
                    Usuario = new Usuario();
                    Usuario.Id = (int)aux["Id"];
                    Usuario.Nombre = aux["Nombre"].ToString();
                    Usuario.Apellido = aux["Apellido"].ToString();
                    Usuario.Dni = (int)aux["DNI"];
                    Usuario.Mail = aux["Mail"].ToString();
                    Usuario.Clave = aux["Clave"].ToString();
                    Usuario.Direccion = aux["Direccion"].ToString();
                    Usuario.Nivel = aux["Nivel"].ToString();
                    Usuario.UrlImgUsuario = aux["UrlImagen"].ToString();
                }
                return Usuario;
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

        //TODO: Eliminar Usuario
        public int EliminarUsuario(int match)
        {
            // se puede buscar por otros campos que tienen qeu ser unicos, DNI, MAIL tienen que ser campos unicos. Por ahora buscar por Id, cambiar despues a distintos metodos de busqueda
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("DELETE FROM USUARIOS WHERE Id = @id", "query");
                Data.SetParameters("@id", match);
                return Data.ExecuteQuery();
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

        //TODO PENDIENTE: Cambiar este metodo para poder buscar Usuarios por distintos campos (DNI, MAIL, CLAVE, NOMBRE .... etc... usar LIKE y otras formas de busqueda)
        public int editarUsuario(int match, Usuario user)
        {
            // se puede buscar por otros campos que tienen qeu ser unicos, DNI, MAIL tienen que ser campos unicos. Por ahora buscar por Id, cambiar despues a distintos metodos de busqueda
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("UPDATE USUARIOS SET Nombre = @nombre, Apellido = @apellido, DNI = @dni, Mail = @mail, Clave = @clave, Direccion = @direccion, Nivel = @nivel, UrlImagen = @urlimagen WHERE Id = @id", "query");
                Data.SetParameters("@id", match);
                return Data.ExecuteQuery();
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

        //TODO: Existe Usuario (con sobrecarga)
        //Busca si existe y ademas carga un ojb User con los datos
        public bool existUser(string mail, string clave, Usuario user)
        {
            // usamos clave y mail para buscar, se pueden usar mas campos unicos como DNI, pero no me parecio pedir el DNI como input en el loggin
            Data = new DataAccess();
            bool flag = false;
            try
            {
                // Ver que query hacer para comprobar si el usuario existe, nos traemos la data por su posible uso
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen FROM USUARIOS WHERE Mail = @Mail AND Clave = @Clave ", "query");
                Data.SetParameters("@Mail", mail);
                Data.SetParameters("@Clave", clave);
                Data.ReadQuery();

                var aux = Data.Lector;
                while(aux.Read())
                {
                    user.Id = (int)aux["Id"];
                    user.Nombre = aux["Nombre"].ToString();
                    user.Apellido = aux["Apellido"].ToString();
                    user.Dni = (int)aux["DNI"];
                    user.Mail = mail;
                    user.Clave = clave;
                    user.Direccion = aux["Direccion"].ToString();
                    user.Nivel = aux["Nivel"].ToString();
                    user.UrlImgUsuario = aux["UrlImagen"]?.ToString();
                    flag = true;
                }
                return flag;
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
        //Solo busca si existe
        public bool existUser(string mail, string clave)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id FROM USUARIOS WHERE Mail = @Mail AND Clave = @Clave ", "query");
                Data.SetParameters("@Mail", mail);
                Data.SetParameters("@Clave", clave);
                Data.ReadQuery();

                bool res = Data.Lector.HasRows;
                return res;
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
    