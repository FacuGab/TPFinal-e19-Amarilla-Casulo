using Dominio;
using Helper;
using Negocio;
using System;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace Catalogo
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        NegocioUsuario NuevoUsuario;
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

        //TODO: Crear usuario
        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            NuevoUsuario = new NegocioUsuario();
            string urlRedirect = (((Button)sender).CommandName == "RegistroInicial")? "Default.aspx" : "ListaCarrito.aspx?text=ok&reg=ok";

            //Obs: para validar en back, se puede hacer un metodo aparte que valide todos los imputs usando strin string.IsNullOrWhiteSpace() que verifica que no sean null, vacio o espacio en blanco
            // y usar char.IsLetterOrDigit() char.IsNumber() char.IsControl() para recorrer cada input y ver si cumplen la condicion dependiendo del input y su modo.
            // En front, javascript tiene metodos similares para recorrer strings creo.

            if (txtNombre.Text != "" && txtApellido.Text != "" && txtDni.Text != "" && txtMail.Text != "" && txtPassword.Text != "" && txtDomicilio.Text != "")
            {
                Usuario usuario = new Usuario();
                usuario.Nombre = txtNombre.Text;
                usuario.Apellido = txtApellido.Text;
                usuario.Dni = int.Parse(txtDni.Text);
                usuario.Mail = txtMail.Text;
                usuario.Clave = txtPassword.Text;
                usuario.Direccion = txtDomicilio.Text;
                usuario.Nivel = "C";
                usuario.UrlImgUsuario = "img/usuarios/default.png";

                if(HelperUsuario.ExistUser(usuario)) 
                {
                    HelperUsuario.MensajePopUp(this, "Usuario Existente");
                }
                else
                {
                    int res = NuevoUsuario.AgregarUsuario(usuario);
                    if (res > 0)
                    {
                        HelperUsuario.MensajePopUp(this, "Usuario Registrado Exitosamente");
                        //Response.Redirect(urlRedirect, true);
                        // aca un response a Default.aspx o a ListaCarrito.aspx?text=ok&reg=ok. funciona correcteamente, pero es tan rapido que no muestra el cartel, intente poner un async await pero fallo por completo
                    }
                    else
                        HelperUsuario.MensajePopUp(this, "No se pudo crear el usurio");
                }
            }
            else
            {
                HelperUsuario.MensajePopUp(this, "Campos Incorrectos");
            }
        }
    }
}