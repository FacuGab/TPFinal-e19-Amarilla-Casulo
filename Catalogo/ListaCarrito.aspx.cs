using Dominio;
using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;

namespace Catalogo
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        NegocioCarrito carrito;
        public bool logged = false;
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

                if (!IsPostBack)
                {
                    carrito = Session["listaCarrito"] as NegocioCarrito;
                    var listaItems = carrito?.Items;

                    if (Request.QueryString["text"] == "ok")
                    {
                        CargarPantallaFinalizarCompra(HelperUsuario.IsLogged(Session["usuarioActual"] as Usuario), listaItems);
                    }
                    else
                    {
                        CargarPantallaCarrito(listaItems);
                    }
                }

                // asignamos si exsite un valor total
                if (Session["totalCarrito"] != null)
                {
                    totalAcumulado = (decimal)Session["totalCarrito"];
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
                if (itemMatch != null && itemMatch.Cantidad >= 0) // ver si .Find() no encuentra item, puede que el T defualt de retorno rompa el codigo
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

        //TODO: Boton Confirmar Pedido (Importante)
        protected void btnConfirmarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioPedido pedidoNegocio = new NegocioPedido();
                Usuario usuarioActual = (Usuario)Session["usuarioActual"];

                if (HelperUsuario.IsLogged(usuarioActual))
                {
                    // Cargamos los datos
                    carrito = Session["listaCarrito"] as NegocioCarrito;
                    List<CarritoItem> lista = carrito.Items;

                    // Si lista == null, cortamos
                    if(lista == null)
                    {
                        HelperUsuario.MensajePopUp(this, "No hay articulos en el carrito");
                        return;
                    }

                    // Cargamos el Pedido
                    Pedido pedido = pedidoNegocio.CargarPedido(lista, usuarioActual, totalAcumulado);

                    int resPedido = 0;
                    int resArticulos = 0;

                    // Agregamos el Pedido
                    resPedido = pedidoNegocio.AgregarPedido(pedido, "sp");
                    if (resPedido == 0)
                    {
                        HelperUsuario.MensajePopUp(this, "Ocurrio Un Error al Cargar el Pedido");
                        return;
                    }
                    else
                    {
                        // Agregamos el id del Pedido y cargamos los articulos al Pedido en tabla Pedido_Articulo
                        pedidoNegocio.CargarIdPedido(pedido.totalItems, resPedido);
                        resArticulos = pedidoNegocio.AgregarPedido_articulo(pedido.totalItems);
                    }

                    // Si dan los numeros:
                    if (resArticulos == pedido.totalItems.Count)
                    {
                        //Enviamos mensaje de confirmacion, y mail de confirmacion del pedido

                        EmailService emailService = new EmailService();
                        Usuario user = Session["usuarioActual"] as Usuario;
                        emailService.ArmarCorreo(user.Mail, "HardFish", newHtmlMsj(user));
                        emailService.EnviarCorreo();
                        HelperUsuario.MensajePopUp(this, "Pedido Cargado Correctamente");
                        
                        btnConfirmarPedido.Enabled = false;
                        datosDePago.Visible = true;
                    }
                    else
                    {
                        HelperUsuario.MensajePopUp(this, "Ocurrio Un Error al Cargar el Pedido");
                    }   
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Continuar Compra
        protected void btnContinuarCompra_Click(object sender, EventArgs e)
        {
            Response.Redirect("ListaCarrito.aspx?text=ok", false);
        }

        //METODOS
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
            if (modo == "suma")
            {
                count++;
            }
            else if (modo == "resta")
            {
                if (count > 0)
                    count--;
            }
            else if (modo == "eliminar")
            {
                if (count > 0)
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

        // Cargar Pantalla ("reg == ok", ver de cuales y como cambiar inputs de QueryStrings a metodos de back)
        public void CargarPantallaFinalizarCompra(bool logged, List<CarritoItem> lista)
        {
            if (lista != null && lista.Count > 0)
            {
                //Cambiamos visibilidad de los tags
                divCarritoVacio.Visible = false;
                divCarritoConItems.Visible = false;
                datosDePago.Visible = false;
                divConfirmarPedido.Visible = true;

                if (logged)
                    divRegistroOLoginNecesario.Visible = false;
                else
                    divBtnConfirmarReserva.Visible = false;

                //Rendereamos y calculamos total
                rptCarrito.DataSource = lista;
                rptCarrito.DataBind();
                totalAcumulado = totalCarrito(lista);
            }
            else
            {
                // Carrito Vacio
                //Cambiamos visibilidad de los tags
                divCarritoVacio.Visible = true;
                divCarritoConItems.Visible = false;
                datosDePago.Visible = false;
                divConfirmarPedido.Visible = false;
            }
        }

        // Cargar Pantalla (Carrito default, text == null)
        public void CargarPantallaCarrito(List<CarritoItem> lista)
        {
            if (lista != null && lista.Count > 0)
            {
                divConfirmarPedido.Visible = false;
                divCarritoVacio.Visible = false;
                divCarritoConItems.Visible = true;
                datosDePago.Visible = false;

                dgvCarrito.DataSource = lista;
                dgvCarrito.DataBind();
                totalAcumulado = totalCarrito(lista);
            }
            else
            {
                divConfirmarPedido.Visible = false;
                divCarritoConItems.Visible = false;
                datosDePago.Visible = false;
                divCarritoVacio.Visible = true;
            }
        }

        private string newHtmlMsj(Usuario usuario)
        {
            string html = "<div> " +
                "<h4>HardFish</h4> " +
                "<p>Gracias por su compra, "+usuario.Nombre+"</p> " +
                "<p>El pedido se encuentra en proceso de preparación</p> " +
                "<p>En breve recibirá un mail con la confirmación del pedido</p> " +
                "<p>Saludos</p> "+
                "</div>";
            return html;
        }

    }
}