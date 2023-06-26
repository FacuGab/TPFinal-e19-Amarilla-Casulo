using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Catalogo
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        private NegocioCarrito carrito;
        private Usuario userControl = null;
        public int itemsCarrito { get; set; }
        public bool Flag { get; set; }
        public Usuario usuario { get { return userControl; } }

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["countCarrito"] != null)
                {
                    lblTotalArticulos.Text = Session["countCarrito"].ToString();
                    Flag = true;
                }
                else
                {
                    Flag = false;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Filtro Rapido
        protected void btnFiltroRapido_Click(object sender, EventArgs e)
        {
            try
            {
                string str = tbFiltroRapido.Text;
                if (!string.IsNullOrWhiteSpace(str))
                    Response.Redirect("Productos.aspx?text=" + str, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Cerrar (en modal)
        protected void btnCerrarModal_Click(object sender, EventArgs e)
        {
            lblUsuarioNoExiste.Visible = false;
        }

        // Boton Ingresar (en modal de ingreso)
        protected void btnIngresar_Click(object sender, EventArgs e)
        {
            try
            {
                string pass = txtClaveLogin.Text;
                string mail = txtMailLogin.Text;

                if( !string.IsNullOrWhiteSpace(pass) && !string.IsNullOrWhiteSpace(mail))
                {
                    NegocioUsuario negocioUsuario = new NegocioUsuario();
                    userControl = negocioUsuario.BuscarUsuario(mail, pass);
                    if (userControl != null)
                    {
                        Session.Add("usuarioActual", userControl);
                    }
                    else
                    {
                        lblUsuarioNoExiste.Visible = true;
                        lblRespuestaLoggin.Text = "Usuario No Encontrado";
                    }
                }
                else
                {
                    lblUsuarioNoExiste.Visible = true;
                    lblRespuestaLoggin.Text = "Campos Incorrectos";
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}