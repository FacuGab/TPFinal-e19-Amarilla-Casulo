using Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (Session["error"] != null)
                {
                    Exception ex = (Exception)Session["error"];
                    string msj = ex.Message;
                    lblMensaje.Text = "ERROR: \n"+msj;
                    lblErrorFuente.Text = "FUENTE: " + ex.Source;
                    lblErrorCompleto.Text = "ERROR COMPLETO: " + ex.ToString();
                }
                else if (Session["MensajeError"] != null)
                {
                    string msj = Session["MensajeError"].ToString();
                    lblMensajeError.Text = "Mensaje: \n" + msj;
                }
            }
            catch
            {
                HelperUsuario.MensajePopUp(this, "Ocurrio un error inesperado\nInforme al equipo de desarrollo");
            }
        }
    }
}