using System;
using Negocio;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnImgTest_Click(object sender, ImageClickEventArgs e)
        {
            var id = ((ImageButton)sender).CommandArgument;

            Response.Redirect("Productos.aspx?id="+id, false);
        }
    }
}