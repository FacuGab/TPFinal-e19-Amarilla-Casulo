using Dominio;
using Negocio;
using System;
using System.Collections.Generic;
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
        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                carrito = Session["listaCarrito"] as NegocioCarrito;
                if(carrito != null )
                {
                    dgvCarrito.DataSource = carrito.Items;
                    dgvCarrito.DataBind();
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
    }
}