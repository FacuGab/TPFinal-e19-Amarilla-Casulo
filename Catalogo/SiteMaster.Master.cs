using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Catalogo
{
    public partial class SiteMaster : System.Web.UI.MasterPage
    {
        NegocioCarrito carrito;
        public int itemsCarrito { get; set; }
        public bool Flag { get; set; }

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
    }
}