using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.WebSockets;

namespace Catalogo
{
    public partial class test : System.Web.UI.Page
    {
        public List<Articulo> Articulos { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
    }
}