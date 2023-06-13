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
        public Usuario BuscarUsuario(string mail) // se puede buscar por otros campos que tienen qeu ser unicos, DNI, MAIL tienen que ser campos unicos

        {
            Data = new DataAccess();
            try
            {
                Data.AbrirConexion();
                Data.SetQuery("SELECT Id, Nombre, Apellido, DNI, Mail, Clave, Direccion, Nivel, UrlImagen FROM USUARIOS WHERE Mail = @mail", "query");
                Data.SetParameters("@mail", mail);
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

    }
}
