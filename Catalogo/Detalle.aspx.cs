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
    public partial class Detalle : System.Web.UI.Page
    {
        protected List<string> listImg;
        protected List<Articulo> listArt = null;
        protected Articulo art = null;
        protected int idMatch = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                List<Articulo> articulos = null;
                if (Session["listaPrincipal"]  != null)
                    articulos = (List<Articulo>)Session["listaPrincipal"];

                if (Request.Params["idProd"]  != null && articulos != null) 
                { 
                    NegocioArticulo listaArticulos = new NegocioArticulo();
                    idMatch = int.Parse(Request.Params["idProd"]);
                    listImg = listaArticulos.ListarImagenesArticulos(idMatch);
                    listArt = new List<Articulo>();

                    art = articulos.Find(itm => itm.Id == idMatch);
                    listArt.Add(art);

                    rptDetalleArt.DataSource = listArt;
                    rptDetalleArt.DataBind();
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}