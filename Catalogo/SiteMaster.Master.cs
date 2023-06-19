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

        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                // Crear una nueva instancia de Cart si no existe en la sesión
                if (Session["listaCarrito"] == null)
                {
                    Session["listaCarrito"] = new List<CarritoItem>();
                }
            }

        }

        protected void btnFiltroRapido_Click(object sender, EventArgs e)
        {
            Response.Redirect("Productos.aspx?text=" + tbFiltroRapido.Text.ToString(), false);
        }
    }
}