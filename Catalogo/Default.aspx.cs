using System;
using Negocio;
using Dominio;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Helper;

namespace Catalogo
{
    public partial class Default : System.Web.UI.Page
    {
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if(!IsPostBack)
                {
                    guardadoExitoso();
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
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //EVENTOS
        //TODO: Metodo de PopUp, 'Guardado Exitoso'
        protected void guardadoExitoso()
        {
            if (Session["MensajeExito"] != null)
            {
                string mensajeExito = Session["MensajeExito"].ToString();
                // Muestra el mensaje de éxito
                HelperUsuario.MensajePopUp(this, mensajeExito);
                // Limpia la variable de sesión para evitar mostrar el mensaje en futuras visitas a la página
                Session.Remove("MensajeExito");
            }
        }
        //TODO: Boton img Categorias
        protected void btnImgCate_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var cate = ((ImageButton)sender).CommandArgument;
                Response.Redirect("Productos.aspx?idCate=" + cate, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        //Boton img Marcas
        protected void btnImgMarca_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                var marca = ((ImageButton)sender).CommandArgument;
                Response.Redirect("Productos.aspx?idMarca=" + marca, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
    }
}