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
    public partial class Productos : System.Web.UI.Page
    {
        NegocioCategoria NegocioCategoria;
        NegocioMarca NegocioMarca;
        NegocioArticulo ListaArticulos = null;
        public string Filtro { get; set; } = string.Empty; // ver si agregar otro o sacar

        //TODO: LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                cargarFiltros();
                if (Request.Params["idCate"] != null)
                {
                    int idMatch = int.Parse(Request.Params["idCate"]);
                    ListaArticulos = new NegocioArticulo();

                    repArticulos.DataSource = ListaArticulos.ListarArticulos().FindAll(art => art.Categoria.Id == idMatch);
                    repArticulos.DataBind();

                    Filtro = ((List<Articulo>)repArticulos.DataSource)[0].Categoria.Descripcion;
                }
                if (Request.Params["idMarca"] != null)
                {
                    int idMatch = int.Parse(Request.Params["idMarca"]);
                    ListaArticulos = new NegocioArticulo();

                    repArticulos.DataSource = ListaArticulos.ListarArticulos().FindAll(art => art.Marca.Id == idMatch);
                    repArticulos.DataBind();

                    Filtro = ((List<Articulo>)repArticulos.DataSource)[0].Marca.Descripcion;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //METODOS
        //TODO: Carga de Filtros
        private void cargarFiltros()
        {
            NegocioMarca = new NegocioMarca();
            NegocioCategoria = new NegocioCategoria();
            
            ddlFiltroMarca.DataSource = NegocioMarca.ListarMarcas();
            ddlFiltroMarca.DataBind();
            ddlFiltroMarca.DataValueField = "Id";
            ddlFiltroMarca.DataTextField = "Descripcion";
            ddlFiltroCategoria.DataSource = NegocioCategoria.ListarCategorias();
            ddlFiltroCategoria.DataBind();
            ddlFiltroCategoria.DataValueField = "Id";
            ddlFiltroCategoria.DataTextField = "Descripcion";

            rptMarcas.DataSource = NegocioMarca.ListarMarcas();
            rptMarcas.DataBind();
            rptCategorias.DataSource = NegocioCategoria.ListarCategorias();
            rptCategorias.DataBind();

        }
    }
}