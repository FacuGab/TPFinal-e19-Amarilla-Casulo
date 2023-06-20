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
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            // rompian el codigo estas lineas, las saque. Igual si eran para otra parte vemos como arreglarlo
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