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
            try
            {
                if(!IsPostBack)
                {
                    NegocioCategoria categoria = new NegocioCategoria();
                    List<Categoria> categorias = categoria.ListarCategorias();
                    rptCategorias.DataSource = categorias;
                    rptCategorias.DataBind();

                    NegocioMarca marca = new NegocioMarca();
                    List<Marca> marcas = marca.ListarMarcas();
                    rptMarcas.DataSource = marcas;
                    rptMarcas.DataBind();

                }
            }
            catch (Exception)
            {

                throw;
            }
        }

        protected void btnImgCate_Click(object sender, ImageClickEventArgs e)
        {
            var cate = ((ImageButton)sender).CommandArgument;

            Response.Redirect("Productos.aspx?idCate="+ cate, false);
        }
        protected void btnImgMarca_Click(object sender, ImageClickEventArgs e)
        {
            var marca = ((ImageButton)sender).CommandArgument;

            Response.Redirect("Productos.aspx?idMarca=" + marca, false);
        }
    }
}