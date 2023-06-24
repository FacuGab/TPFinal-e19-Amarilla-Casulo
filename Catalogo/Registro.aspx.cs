using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioUsuario NuevoUsuario;
        Usuario usuario;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if(Request.QueryString["text"] == "registroCompra")
                {
                    btnRegistro.Visible = false;
                    btnRegistroParaCompra.Visible= true;
                }
                else
                {
                    btnRegistro.Visible = true;
                    btnRegistroParaCompra.Visible = false;
                }
            }
        }
        //crear usuario
        //protected void btnRegistro_Click(object sender, EventArgs e)
        //{

        //    NuevoUsuario = new NegocioUsuario();
        //    if (txtNombre.Text != "" && txtApellido.Text != "" && txtDni.Text != "" && txtMail.Text != "" && txtClave.Text != "" && txtDireccion.Text != "")
        //    {
        //        Usuario usuario = new Usuario();
        //        usuario.Nombre = txtNombre.Text;
        //        usuario.Apellido = txtApellido.Text;
        //        usuario.Dni = int.Parse(txtDni.Text);
        //        usuario.Mail = txtMail.Text;
        //        usuario.Clave = txtClave.Text;
        //        usuario.Direccion = txtDireccion.Text;
        //        usuario.Nivel = 'C';
        //        usuario.UrlImgUsuario = "img/usuarios/default.png";
        //        NuevoUsuario.AgregarUsuario(usuario);
        //        Response.Redirect("Login.aspx");
        //    }
        //    else
        //    {
                
        //    }
        //}
    }
}