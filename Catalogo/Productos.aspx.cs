using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
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
                if (IsPostBack == false)
                {
                    cargarFiltros();

                    // Fijarse si cargar la lista aca sin los activos
                    // Esta logica hay que cambiarla mas adelante
                    if (Request.Params["idCate"] != null)
                    {
                        //int idMatch = int.Parse(Request.Params["idCate"]);
                        //ListaArticulos = new NegocioArticulo();
                        //Session.Add("listaPrincipal", ListaArticulos.ListarArticulos());
                        //repArticulos.DataSource = ListaArticulos.ListarArticulos().FindAll(art => art.Categoria.Id == idMatch);

                        repArticulos.DataSource = filtrarLista(int.Parse(Request.Params["idCate"]), "idCate");
                        repArticulos.DataBind();
                        Filtro = ((List<Articulo>)repArticulos.DataSource)[0].Categoria.Descripcion;
                    }
                    if (Request.Params["idMarca"] != null)
                    {
                        int idMatch = int.Parse(Request.Params["idMarca"]);
                        ListaArticulos = new NegocioArticulo();
                        Session.Add("listaPrincipal", ListaArticulos.ListarArticulos());

                        repArticulos.DataSource = ListaArticulos.ListarArticulos().FindAll(art => art.Marca.Id == idMatch);
                        repArticulos.DataBind();

                        Filtro = ((List<Articulo>)repArticulos.DataSource)[0].Marca.Descripcion;
                    }
                    if (Request.Params["text"] != null)
                    {
                        string Match = Request.Params["text"];
                        ListaArticulos = new NegocioArticulo();
                        List<Articulo> listaFiltrada = new List<Articulo>();
                        listaFiltrada = ListaArticulos.ListarArticulos().FindAll(
                        x => (x.Nombre.ToUpperInvariant().Contains(Match.ToUpperInvariant()) ||
                        x.Marca.Descripcion.ToUpperInvariant().Contains(Match.ToUpperInvariant())));
                        Session.Add("listaFiltrada", listaFiltrada);

                        repArticulos.DataSource = listaFiltrada;
                        repArticulos.DataBind();
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        // ### METODOS ###
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

        //TODO: Filtrar Lista
        private List<Articulo> filtrarLista(object param, string tipoParam)
        {
            List<Articulo> listaFiltrada = null;
            try
            {
                if (param == null)
                    return null;
                else
                    ListaArticulos = new NegocioArticulo();

                if (param is string)
                {
                    string match = param as string;
                    listaFiltrada = ListaArticulos.ListarArticulos().FindAll(
                        x => (x.Nombre.ToUpperInvariant().Contains(match.ToUpperInvariant()) ||
                        x.Marca.Descripcion.ToUpperInvariant().Contains(match.ToUpperInvariant()))
                        );
                    Session.Add("listaFiltrada", listaFiltrada);
                }
                else if(param is int) 
                {
                    int match = (int)param;
                    if(tipoParam == "idCate")
                    {
                        listaFiltrada = ListaArticulos.ListarArticulos().FindAll(art => art.Categoria.Id == match);
                        Session.Add("listaFiltrada", listaFiltrada);
                    }
                    else if(tipoParam == "idMarca")
                    {
                        listaFiltrada = ListaArticulos.ListarArticulos().FindAll(art => art.Marca.Id == match);
                        Session.Add("listaFiltrada", listaFiltrada);
                    }
                }
                return listaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // ### EVENTOS ###
        //TODO: Filtro Caegorias
        protected void btnFiltroCate_Click(object sender, EventArgs e)
        {
            int idMatch = int.Parse(((Button)sender).CommandArgument);
            Response.Redirect("Productos.aspx?idCate=" + idMatch, false);
        }

        //TODO: Filtro Marca
        protected void btnFiltroMarca_Click(object sender, EventArgs e)
        {
            int idMatch = int.Parse(((Button)sender).CommandArgument);
            Response.Redirect("Productos.aspx?idMarca=" + idMatch, false);
        }

        //TODO: Boton Filtro
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Articulo> listaArticulos;
            listaArticulos = (List<Articulo>)Session["listaPrincipal"];
            List<Articulo> listaFiltrada = new List<Articulo>();

            try
            {
                listaFiltrada.AddRange(listaArticulos.FindAll(x =>
                x.Categoria.Descripcion.Contains(ddlFiltroCategoria.Text)
                && x.Marca.Descripcion.Contains(ddlFiltroMarca.Text)));
                repArticulos.DataSource = listaFiltrada;
                repArticulos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }

        //TODO: Boton Filtro Precio dsc
        protected void btnFiltroPrecioDesc_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Params["text"] != null)
                {
                    List<Articulo> listaArticulos;
                    listaArticulos = (List<Articulo>)Session["listaFiltrada"];

                    List<Articulo> listaFiltrada = new List<Articulo>();
                    listaFiltrada = listaArticulos.OrderByDescending(producto => producto.precio).ToList();

                    repArticulos.DataSource = listaFiltrada;
                    repArticulos.DataBind();
                }
                else
                {   // porque repite el codigo en el else si no tenemos parametro ¿?
                    List<Articulo> listaArticulos;
                    listaArticulos = (List<Articulo>)Session["listaPrincipal"];

                    List<Articulo> listaFiltrada = new List<Articulo>();
                    listaFiltrada = listaArticulos.OrderByDescending(producto => producto.precio).ToList();

                    repArticulos.DataSource = listaFiltrada;
                    repArticulos.DataBind();
                }

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        //TODO: Boton Filtro Precio asc
        protected void btnFiltroPrecioAsc_Click(object sender, EventArgs e)
        {
            try
            {
                if (Request.Params["text"] != null)
                {
                    List<Articulo> listaArticulos;
                    listaArticulos = (List<Articulo>)Session["listaFiltrada"];
                    List<Articulo> listaFiltrada = new List<Articulo>();
                    listaFiltrada = listaArticulos.OrderBy(producto => producto.precio).ToList();
                    repArticulos.DataSource = listaFiltrada;
                    repArticulos.DataBind();
                }
                else
                {
                    List<Articulo> listaArticulos;
                    listaArticulos = (List<Articulo>)Session["listaPrincipal"];
                    List<Articulo> listaFiltrada = new List<Articulo>();
                    listaFiltrada = listaArticulos.OrderBy(producto => producto.precio).ToList();
                    repArticulos.DataSource = listaFiltrada;
                    repArticulos.DataBind();
                }
            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        //TODO: Boton Ir a Detalle Articulo
        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);

            Response.Redirect("Detalle.aspx?idProd=" + id, false);
        }
    }
}