﻿using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI;

namespace Helper
{
    static public class HelperUsuario
    {

        // Mensaje Pop Up
        static public void MensajePopUp(Page page, string mensaje)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alertMenssage", $"alert('{mensaje}');", true);
        }

        // IsLogged(), si el usuario esta logeado (si este existe en session, y registrado)
        static public bool IsLogged(Usuario usuario)
        {
            return usuario != null;
        }

        // IsAdmin(), si el usurio esta logeado y es un admin, tiene que tener nivel 'A' de admin
        static public bool IsAdmin(Usuario usuario)
        {
            if (usuario == null)
                return false;
            else
            {
                if (usuario.Nivel.ToUpperInvariant() == "A")
                    return true;
                else
                    return false;
            }
        }

        // ExistUser(), puede sobrecargarse con el puntero de NegocioUsuario o sin el.
        // devuelve true + un usuario cargado
        // ver cual util pueden ser estos metodos...
        static public bool ExistUser(Usuario usuario, NegocioUsuario negocioUsuario)
        {
            if(usuario == null) 
                return false;

            if (negocioUsuario != null)
            {
                return negocioUsuario.existUser(usuario.Mail, usuario.Clave, usuario);
            }
            else
            {
                negocioUsuario = new NegocioUsuario();
                return negocioUsuario.existUser(usuario.Mail, usuario.Clave, usuario);
            }
        }

        // Solo busca en bd y dice si existe
        static public bool ExistUser(Usuario usuario) 
        {
            if (usuario == null)
                return false;

            NegocioUsuario negocio = new NegocioUsuario();
            return negocio.existUser(usuario.Mail, usuario.Clave, usuario.Dni);
        }
    }
}
