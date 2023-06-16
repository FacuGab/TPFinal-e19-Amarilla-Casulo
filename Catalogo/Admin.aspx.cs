using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Catalogo
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        List<Articulo> articuloList;
        NegocioArticulo NegocioArticulo;
        List<Categoria> categoriaList;
        NegocioCategoria NegocioCategoria;
        List<Marca> MarcaList;
        NegocioMarca NegocioMarca;
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if(Request.QueryString["id"] != null)
                {
                    switch (int.Parse(Request.QueryString["id"]))
                    {
                        case 1:
                            CargarMarcas();
                            break;
                        case 2:
                            CargarCategorias();
                            break;
                        case 3:
                            CargarArticulos();
                            break;
                    }
                }
            }
        }

        private void CargarArticulos()
        {
            articuloList = new List<Articulo>();
            NegocioArticulo = new NegocioArticulo();
            articuloList = NegocioArticulo.ListarArticulos();
            dgvAdmin.DataSource = articuloList;
            dgvAdmin.DataBind();
        }
        private void CargarCategorias()
        {
            categoriaList = new List<Categoria>();
            NegocioCategoria = new NegocioCategoria();
            categoriaList = NegocioCategoria.ListarCategorias();
            dgvAdminCate.DataSource = categoriaList;
            dgvAdminCate.DataBind();
        }
        private void CargarMarcas()
        {
            MarcaList = new List<Marca>();
            NegocioMarca = new NegocioMarca();
            MarcaList = NegocioMarca.ListarMarcas();
            dgvAdminMarca.DataSource = MarcaList;
            dgvAdminMarca.DataBind();
        }

        protected void ibtEliminar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtEditar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtBaja_Click(object sender, ImageClickEventArgs e)
        {

        }
    }
}