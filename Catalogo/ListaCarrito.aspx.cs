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
            try
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
                        totalAcumulado = totalCarrito(carrito.Items);
                    }
                    else
                    {
                        divCarritoConItems.Visible = false;
                        divCarritoVacio.Visible = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
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

                //Rendereamos nuevamente la lista
                dgvCarrito.DataSource = carrito.Items;
                dgvCarrito.DataBind();

                //Calculamos el total de nuevo
                totalAcumulado = totalCarrito(carrito.Items);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
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

                //Calculamos el total de nuevo
                totalAcumulado = totalCarrito(carrito.Items);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
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

                //Calculamos el total de nuevo
                totalAcumulado = totalCarrito(carrito.Items);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton ir a Detalle articulo
        protected void btnDetalles_Click(object sender, EventArgs e)
        {
            try
            {
                int id = int.Parse(((Button)sender).CommandArgument);
                Response.Redirect("Detalle.aspx?idProd=" + id, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Evento GrdiView (calculo totales)
        // no encontre forma de utilizarlo y que muestre bien los datos, siempre o se crasheaba o se pisaban los valores entre si
        //protected void dgvCarrito_ItemDataBound(object sender, RepeaterItemEventArgs e)
        //{
        //    //try
        //    //{
        //    //    if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        //    //    {
        //    //        Label lblPrecioTotalPorArticulo = (Label)e.Item.FindControl("lblPrecioTotalPorArticulo");
        //    //        Label lblTotalPorArticulo = (Label)e.Item.FindControl("lblCantidad");
        //    //        decimal precioTotalPorArticulo = Convert.ToDecimal(lblPrecioTotalPorArticulo.Text);
        //    //        decimal cantidadPorArticulo = Convert.ToDecimal(lblTotalPorArticulo.Text);
        //    //        Total_x_Item = precioTotalPorArticulo * cantidadPorArticulo;
        //    //    }
        //    //}
        //    //catch (Exception ex)
        //    //{
        //    //    Session.Add("error", ex);
        //    //    Response.Redirect("Error.aspx", false);
        //    //}
        //}

        //TODO: METODOS
        // Calcular Totales
        public decimal totalCarrito(List<CarritoItem> lista)
        {
            decimal total = 0.00M;
            //Si no existe (ver si la logica esta correcta)
            if (lista == null)
                return 0.00M;

            //Creamos un decimal para retener total (ver si crea un decimal realmente)
            if (Session["totalCarrito"] == null)
                Session.Add("totalCarrito", 0.00M);

            //Acumular el valor
            foreach (CarritoItem item in lista) 
            {
                if (total >= 0)
                    total += (item.precio * item.Cantidad);
            }

            // re-guardamos el valor (mepa que un tipo decimal no puede funcionar como puntero)
            Session["totalCarrito"] = total;
            return total;
        }
    }
}