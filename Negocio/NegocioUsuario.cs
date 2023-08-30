using Data;
using Dominio;
using System;
using System.Collections.Generic;

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
                Data.SetQuery("INSERT INTO USUARIOS (Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen, Activo) VALUES (@Nombre, @Apellido, @DNI, @Mail, @Clave, @Direccion, @Nivel, @UrlImagen, @Activo)", "query");
                Data.SetParameters("@Nombre", usuario.Nombre);
                Data.SetParameters("@Apellido", usuario.Apellido);
                Data.SetParameters("@DNI", usuario.Dni);
                Data.SetParameters("@Mail", usuario.Mail);
                Data.SetParameters("@Clave", usuario.Clave);
                Data.SetParameters("@Direccion", usuario.Direccion);
                Data.SetParameters("@Nivel", usuario.Nivel);
                Data.SetParameters("@UrlImagen", usuario.UrlImgUsuario);
                Data.SetParameters("@Activo", usuario.Activo);
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
        //TODO: Editar Usuario
        public int EditarUsuario(Usuario usuario)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("UPDATE USUARIOS SET Nombre = @Nombre, Apellido = @Apellido, DNI = @DNI, Mail = @Mail, Clave = @Clave, Direccion = @Direccion, Nivel = @Nivel, UrlImagen = @UrlImagen, Activo = @Activo WHERE Id = @Id", "query");
                Data.SetParameters("@Id", usuario.Id);
                Data.SetParameters("@Nombre", usuario.Nombre);
                Data.SetParameters("@Apellido", usuario.Apellido);
                Data.SetParameters("@DNI", usuario.Dni);
                Data.SetParameters("@Mail", usuario.Mail);
                Data.SetParameters("@Clave", usuario.Clave);
                Data.SetParameters("@Direccion", usuario.Direccion);
                Data.SetParameters("@Nivel", usuario.Nivel);
                Data.SetParameters("@UrlImagen", usuario.UrlImgUsuario);
                Data.SetParameters("@Activo", usuario.Activo);
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

        //TODO: Listar Usuarios
        public List<Usuario> ListarUsuarios()
        {
            Data = new DataAccess();
            try
            {
                Usuarios = new List<Usuario>();
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen, Activo FROM USUARIOS", "query");
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
                    Usuario.Activo = (bool)aux["Activo"];
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
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen, Activo FROM USUARIOS WHERE Id = @Id", "query");
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
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen, Activo FROM USUARIOS WHERE Mail = @Mail AND Clave = @Clave", "query");
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
                    Usuario.Activo = (bool)aux["Activo"];
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
        //TODO: Dar de alta usuario
        public int DarAltaUsuario(int match)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("UPDATE USUARIOS SET Activo = 1 WHERE Id = @id", "query");
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
        //TODO:Dar de baja suario
        public int DarBajaUsuario(int match)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("UPDATE USUARIOS SET Activo = 0 WHERE Id = @id", "query");
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
        //TODO: Editar Usuario
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
        public bool existUser(string mail, string clave, int dni)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id FROM USUARIOS WHERE Mail = @Mail AND Clave = @Clave AND DNI = @DNI", "query");
                Data.SetParameters("@Mail", mail);
                Data.SetParameters("@Clave", clave);
                Data.SetParameters("@DNI", dni);
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

        //TODO: Comprobar Id
        public int ComprobarId(int idMatch)
        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("SELECT COUNT(*) FROM USUARIOS WHERE Id = @id", "query");
                Data.SetParameters("@id", idMatch);
                int res = Convert.ToInt32(Data.ExecuteScalar());
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
    