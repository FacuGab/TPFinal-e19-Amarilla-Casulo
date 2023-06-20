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

                //Calculamos la cantidad de art total
                TotalArticulosCarrito("eliminar", idMatch);
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

                //Calculamos el total $ de nuevo
                totalAcumulado = totalCarrito(carrito.Items);

                //Calculamos el total # art en carrito
                TotalArticulosCarrito("suma");
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

                //Calculamos el total # art en carrito
                TotalArticulosCarrito("resta");
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
                int id = int.Parse(((ImageButton)sender).CommandArgument);
                Response.Redirect("Detalle.aspx?idProd=" + id, false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Eliminar Toda la lista del Carrito
        protected void btnEliminarListaCarrito_Click(object sender, EventArgs e)
        {
            Session.Remove("listaCarrito");
            Session.Remove("countCarrito");
            Response.Redirect("ListaCarrito.aspx", false);
        }

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

        // Calcular total articulos en carrito
        public void TotalArticulosCarrito(string modo, int idMath = 0)
        {
            if (Session["countCarrito"] == null)
                Session.Add("countCarrito", 0);

            //Operamos cantidad: suma, resta, eliminar y guardamos
            int count = (int)Session["countCarrito"];
            if(modo == "suma")
            {
                count++;
            }
            else if(modo == "resta")
            {
                if(count > 0)
                    count--;
            }
            else if(modo == "eliminar")
            {
                if(count > 0)
                {
                    count = 0;
                    var itemList = ((NegocioCarrito)Session["listaCarrito"]).Items;
                    foreach (var item in itemList)
                        count += item.Cantidad;
                }
            }
            Session["countCarrito"] = count;

            //Mostramos valor en nav Master
            Label lblcantidad = (Label)Master.FindControl("lblTotalArticulos");
            if (lblcantidad != null)
            {
                lblcantidad.Text = count.ToString();
                Master.Flag = true;
            }
        }
    }
}