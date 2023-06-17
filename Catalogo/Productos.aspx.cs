﻿using Dominio;
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
        NegocioArticulo negocioArticulos = null;
        public string Filtro { get; set; } = string.Empty; // ver si agregar otro o sacar

        //TODO: LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (IsPostBack == false)
                {
                    List<Articulo> listaMostrar;

                    //Cargamos Filtros y Creamos Lista Principal si no existe, idem lista filtrada
                    cargarFiltros();

                    if (Session["listaPrincipal"] == null)
                        Session.Add("listaPrincipal", new NegocioArticulo().ListarArticulos());

                    if (Session["listaFiltrada"] == null)
                        Session.Add("listaFiltrada", new List<Articulo>());

                    //Vemos si hay y que tipo de parametro por querystring tenemos:
                    if (Request.Params["idCate"] != null)
                    {
                        listaMostrar = filtrarLista(int.Parse(Request.Params["idCate"]), "idCate");
                        Filtro = listaMostrar[0]?.Categoria.Descripcion;
                    }
                    else if (Request.Params["idMarca"] != null)
                    {
                        listaMostrar = filtrarLista(int.Parse(Request.Params["idMarca"]), "idMarca");
                        Filtro = listaMostrar[0]?.Marca.Descripcion;
                    }
                    else if (Request.Params["text"] != null)
                    {
                        listaMostrar = filtrarLista(Request.Params["text"]);
                        Filtro = Request.Params["text"].ToString();
                    }
                    else
                    {
                        // Si no hay ningun filtro en query y no es un PostBack, mostramos lista completa
                        listaMostrar = (List<Articulo>)Session["ListaPrincipal"];
                        Filtro = "";
                    }
                    repArticulos.DataSource = listaMostrar;
                    repArticulos.DataBind();
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
        private List<Articulo> filtrarLista(object param, string tipoParam = null)
        {
            //List<Articulo> listaFiltrada = null;
            try
            {
                //gatillo de seguridad
                if (Session["listaPrincipal"] == null)
                    return null;

                //Asingnamos lista principal a variables
                List<Articulo> listaPrincipal = (List<Articulo>)Session["listaPrincipal"];
                List<Articulo> listaFiltrada = (List<Articulo>)Session["listaFiltrada"];

                // Si es un parametro string, filtramos lista principal y agregamos a session con ese filtro
                if (param is string)
                {
                    string match = param as string;
                    listaFiltrada = listaPrincipal.FindAll(
                        x => (x.Nombre.ToUpperInvariant().Contains(match.ToUpperInvariant()) ||
                        x.Marca.Descripcion.ToUpperInvariant().Contains(match.ToUpperInvariant()))
                        );
                }
                // Si es un parametro entero, filtramos lista principal y agregamos a session con ese filtro
                else if (param is int)
                {
                    int match = (int)param;

                    if (tipoParam == "idCate")
                        listaFiltrada = listaPrincipal.FindAll(art => art.Categoria.Id == match);
                    else if (tipoParam == "idMarca")
                        listaFiltrada = listaPrincipal.FindAll(art => art.Marca.Id == match);
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
            try
            {
                repArticulos.DataSource = filtrarLista(int.Parse( ((Button)sender).CommandArgument ), "idCate");
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Filtro Marca
        protected void btnFiltroMarca_Click(object sender, EventArgs e)
        {
            try
            {
                repArticulos.DataSource = filtrarLista(int.Parse(((Button)sender).CommandArgument), "idMarca");
                repArticulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Filtro
        protected void btnFiltro_Click(object sender, EventArgs e)
        {
            List<Articulo> listaPrincipal = (List<Articulo>)Session["listaPrincipal"];
            try
            {
                repArticulos.DataSource = listaPrincipal.FindAll(x =>
                    x.Categoria.Descripcion.Contains(ddlFiltroCategoria.Text)
                    && x.Marca.Descripcion.Contains(ddlFiltroMarca.Text));
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
                {   
                    List<Articulo> listaArticulos;
                    listaArticulos = (List<Articulo>)Session["listaPrincipal"];

                    List<Articulo> listaFiltrada = new List<Articulo>();
                    listaFiltrada = listaArticulos.OrderByDescending(producto => producto.precio).ToList();

                    repArticulos.DataSource = listaFiltrada;
                    repArticulos.DataBind();
                }
                //List<Articulo> listaFiltrada = (List<Articulo>)Session["listaPrincipal"];
                //repArticulos.DataSource = listaFiltrada.OrderByDescending(producto => producto.precio).ToList();
                //repArticulos.DataBind();

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

        //TODO: Boton Borrar Filtros
        protected void btnBorrarFilros_Click(object sender, EventArgs e)
        {
            //ver si borrar obj listas de art en session o no aca ....
            Session.Remove("listaFiltrada");
            Session.Remove("listaPrincipal");
            Response.Redirect("Productos.aspx", false);
        }
    }
}