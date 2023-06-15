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
        protected List<Articulo> listArt;
        protected int idMatch = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                idMatch = int.Parse(Request.Params["idProd"]);
                NegocioArticulo ListaArticulos = new NegocioArticulo();
                listImg = new List<string>();
                listImg = ListaArticulos.ListarImagenesArticulos(idMatch);

                listArt = new List<Articulo>();
                
                foreach (var item in ListaArticulos.ListarArticulos())
                {
                    if(item.Id == idMatch)
                    {
                        listArt.Add(item);
                    }
                }
                rptDetalleArt.DataSource = listArt;
                rptDetalleArt.DataBind();

            }
            catch (Exception ex)
            {

                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }
            
        }
    }
}