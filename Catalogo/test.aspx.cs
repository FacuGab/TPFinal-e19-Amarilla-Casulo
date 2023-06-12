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
            NegocioMarca marca = new NegocioMarca();
            NegocioCategoria categoria = new NegocioCategoria();
            NegocioArticulo articulos = new NegocioArticulo();

            dgvGridTest1.DataSource = marca.ListarMarcas();
            dgvGridTest1.DataBind();
            dgvGridTest2.DataSource = categoria.ListarCategorias();
            dgvGridTest2.DataBind();

            Articulos = new List<Articulo>(articulos.ListarArticulos());
            dgvGridTest3.DataSource = Articulos;
            dgvGridTest3.DataBind();
            dgvGridTest4.DataSource = Articulos;
            dgvGridTest4.DataBind();
        }
    }
}