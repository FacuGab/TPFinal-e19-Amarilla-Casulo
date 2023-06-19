using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Catalogo
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioCarrito carrito;
        protected decimal totalAcumulado = 0;
        public decimal TotalAcumulado
        {
            get { return totalAcumulado; }
            set { totalAcumulado = value; }
        }
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                carrito = Session["listaCarrito"] as NegocioCarrito;
                if (carrito != null && carrito.Items.Count > 0)
                {
                    divCarritoVacio.Visible = false;
                    divCarritoConItems.Visible = true;
                    dgvCarrito.DataSource = carrito.Items;
                    dgvCarrito.DataBind();

                }
                else
                {
                    divCarritoConItems.Visible=false;
                    divCarritoVacio.Visible = true;

                }
            }
        }

        //EVENTOS
        //TODO: Boton Eliminar Fila en Lista Carrito
        protected void btnEliminar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //Apuntamos y capturamos
                int idMatch = int.Parse(((ImageButton)sender).CommandArgument);
                carrito = Session["listaCarrito"] as NegocioCarrito;
                
                //Eliminamos Item del Carrito
                carrito.BorrarItem(idMatch);

                //Rendereamos nuevamente la lista (aca se podria agregar tanto a un rep, un Grid o un obj para un foreach)
                dgvCarrito.DataSource = carrito.Items;
                dgvCarrito.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
            }
        }

        //TODO: Boton Sumar Item a Lista Carrito
        protected void btnSumar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //Apuntamos y capturamos
                int idMatch = int.Parse(((ImageButton)sender).CommandArgument);
                carrito = Session["listaCarrito"] as NegocioCarrito;
                CarritoItem itemMatch = carrito.Items.Find(itm => itm.Id == idMatch);

                //Sumamos a la cantidad anteror
                if(itemMatch != null && itemMatch.Cantidad >= 0) // ver si .Find() no encuentra item, puede que el T defualt de retorno rompa el codigo
                    carrito.ModificarCantidad(idMatch, ++itemMatch.Cantidad);

                //Rendereamos nuevamente la lista
                dgvCarrito.DataSource = carrito.Items;
                dgvCarrito.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Boton Restar Item a Lista Carrito
        protected void btnRestar_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //Apuntamos y capturamos
                int idMatch = int.Parse(((ImageButton)sender).CommandArgument);
                carrito = Session["listaCarrito"] as NegocioCarrito;
                CarritoItem itemMatch = carrito.Items.Find(itm => itm.Id == idMatch);

                //Restamos a la cantidad anteror
                if (itemMatch != null && itemMatch.Cantidad > 0) // ver si .Find() no encuentra item, puede que el T defualt de retorno rompa el codigo
                    carrito.ModificarCantidad(idMatch, --itemMatch.Cantidad);

                //Rendereamos nuevamente la lista
                dgvCarrito.DataSource = carrito.Items;
                dgvCarrito.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //TODO: METODOS
        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            int id = int.Parse(((Button)sender).CommandArgument);

            Response.Redirect("Detalle.aspx?idProd=" + id, false);
        }
        protected void dgvCarrito_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblPrecioTotalPorArticulo = (Label)e.Item.FindControl("lblPrecioTotalPorArticulo");
                decimal precioTotalPorArticulo = Convert.ToDecimal(lblPrecioTotalPorArticulo.Text);
                TotalAcumulado += precioTotalPorArticulo;
                
            }
        }

    }
}