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
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioCarrito carrito;
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                carrito = new NegocioCarrito();
                carrito = Session["listaCarrito"] as NegocioCarrito;
                if(carrito != null )
                {
                    dgvCarrito.DataSource = carrito.Items;
                    dgvCarrito.DataBind();
                }
            }
        }
    }
}