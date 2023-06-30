using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dominio;
using Negocio;

namespace Catalogo
{
    public partial class WebForm4 : System.Web.UI.Page
    {
        
        NegocioArticulo negocioArticulo;
        NegocioCategoria negocioCategoria;
        NegocioMarca negocioMarca;
        Articulo articulo;
        Categoria categoria;
        Marca marca;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                negocioArticulo = new NegocioArticulo();
                negocioCategoria = new NegocioCategoria();
                negocioMarca = new NegocioMarca();
                categoria = new Categoria();
                marca = new Marca();
                try
                {
                    ddlCategoria.DataSource = negocioCategoria.ListarCategorias();
                    ddlCategoria.DataTextField = "Descripcion";
                    ddlCategoria.DataValueField = "Id";
                    ddlCategoria.DataBind();
                    ddlMarca.DataSource = negocioMarca.ListarMarcas();
                    ddlMarca.DataTextField = "Descripcion";
                    ddlMarca.DataValueField = "Id";
                    ddlMarca.DataBind();
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        //Metodo para agregar articulo
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            marca = new Marca();
            marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
            marca.ObtenerMarca(marca.Id);
            categoria = new Categoria();
            categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);
            categoria.ObtenerCategoria(categoria.Id);

            negocioArticulo = new NegocioArticulo();
            articulo = new Articulo();
            articulo.Id = Convert.ToInt32(tbIdArt.Text);
            articulo.Nombre = tbNombreArt.Text;
            articulo.Descripcion = tbDescripArt.Text;
            articulo.ImagenUrl = tbImgArt.Text;
            articulo.precio = Convert.ToDecimal(tbPrecioArt.Text);
            articulo.Marca = marca;
            articulo.Categoria = categoria;
            articulo.Estado = true;
            articulo.Stock = int.Parse(tbStockArt.Text);
            negocioArticulo.crearArticulo(articulo);
            Response.Redirect("Admin.aspx?id=5");
        }

        protected void tbImgArt_TextChanged(object sender, EventArgs e)
        {
            imgNuevoArt.ImageUrl = tbImgArt.Text;
        }
    }
}