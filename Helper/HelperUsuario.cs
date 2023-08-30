using Dominio;
using Negocio;
using System.Web.UI;

namespace Helper
{
    static public class HelperUsuario
    {
        /// <summary>
        /// Suelta un mensaje de alerta en la pagina, pop-up
        /// </summary>
        /// <param name="page">Page actual</param>
        /// <param name="mensaje">mensaje a mostrar</param>
        // Mensaje Pop Up
        static public void MensajePopUp(Page page, string mensaje)
        {
            ScriptManager.RegisterStartupScript(page, page.GetType(), "alertMenssage", $"alert('{mensaje}');", true);
        }

        static public void MensajePopUp(MasterPage master, string mensaje)
        {
            ScriptManager.RegisterStartupScript(master, master.GetType(), "alertMenssage", $"alert('{mensaje}');", true);
        }

        //static public void MensajePopUp(MasterPage master, string mensaje, string url)
        //{
        //    ScriptManager.RegisterStartupScript(master, master.GetType(), "alertMenssage", $"alert('{mensaje}'); window.location.href = '{url}';", true);
        //}
        /// <summary>
        /// Verifica si el usuario esta logeado
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true si usuario es != de null, false si usuario es == null</returns>
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

        /// <summary>
        /// Busca en la bd si existe el usuario en la BD
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>true si se encuntra un registro en la BD, false si no</returns>
        // Solo busca en bd y dice si existe
        static public bool ExistUser(Usuario usuario) 
        {
            if (usuario == null)
                return false;

            NegocioUsuario negocio = new NegocioUsuario();
            return negocio.existUser(usuario.Mail, usuario.Clave, usuario.Dni);
        }
        //valido si el id de una marca esta registrado en la base de datos
        static public bool ExistMarca(int id)
        {
            NegocioMarca negocio = new NegocioMarca();
            return negocio.ExistMarca(id);
        }
        //Valido si el id de una categoria esta registrado en la base de datos
        static public bool ExistCategoria(int id)
        {
            NegocioCategoria negocio = new NegocioCategoria();
            return negocio.existCategoria(id);
        }
        static public void MostrarConfirmacionBorrado(Page page, string mensaje, string funcionConfirmacion)
        {
            string script = $"if (confirm('{mensaje}')) {{ {funcionConfirmacion} }}";
            ScriptManager.RegisterStartupScript(page, page.GetType(), "confirmDialog", script, true);
        }
    }
}
