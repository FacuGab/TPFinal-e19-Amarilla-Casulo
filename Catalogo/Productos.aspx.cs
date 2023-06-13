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
        NegocioArticulo ListaArticulos = null;
        public string Filtro { get; set; } = string.Empty;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(Request.Params["id"] != null) 
                {
                    int idMatch = int.Parse(Request.Params["id"]);
                    ListaArticulos = new NegocioArticulo();

                    repArticulos.DataSource = ListaArticulos.ListarArticulos().FindAll(art => art.Categoria.Id == idMatch);
                    repArticulos.DataBind();
                
                    Filtro = ((List<Articulo>)repArticulos.DataSource)[0].Categoria.Descripcion;
                }
            }
            catch(Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
        }
    }
}