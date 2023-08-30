using Dominio;
using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;


namespace Catalogo
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        List<Usuario> usuarioList;
        NegocioUsuario NegocioUsuario;
        List<Articulo> articuloList;
        NegocioArticulo NegocioArticulo;
        List<Categoria> categoriaList;
        NegocioCategoria NegocioCategoria;
        List<Marca> MarcaList;
        NegocioMarca NegocioMarca;
        List<Pedido> PedidoList;
        NegocioPedido NegocioPedido;
        List<CarritoItem> Pedido_articulos;
        Usuario usuario;
        Articulo articulo;
        Categoria categoria;
        Marca marca;

        // LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            sectionModificarUsuario.Visible = false;
            SectionCrearArt.Visible = false;

            try
            {
                if (!IsPostBack)
                {
                    //Damos mensaje si es que hay alguno
                    mensajes();

                    //Validamos si el usuario es Admin
                    Usuario admin = Session["usuarioActual"] as Usuario;
                    if (!HelperUsuario.IsAdmin(admin))
                    {
                        Session["MensajeError"] = "No tiene las credenciales para entrar o No te encuentras logeado";
                        Response.Redirect("Error.aspx", false);
                        return;
                    }

                    //Validamos si hay un id en la url para renderear la pagina (no usar asi de ser posible)
                    if (Request.QueryString["id"] != null)
                    {
                        switch (int.Parse(Request.QueryString["id"]))
                        {
                            case 1:
                                CargarPedidos();
                                break;
                            case 2:
                                CargarPedidos();
                                break;
                            case 3:
                                guardadoExitoso();
                                CargarMarcas();
                                break;
                            case 4:
                                guardadoExitoso();
                                CargarCategorias();
                                break;
                            case 5:
                                CargarArticulos();
                                break;
                            case 6:
                                CargarUsuario();
                                break;
                            case 7:
                                CargaDdl();
                                SectionCrearArt.Visible = true;
                                tituloEditarArticulo.Visible = false;
                                divEstadisticas.Visible = false;
                                lblAdministracionArticulos.Visible = true;
                                lblAdministracionUsuarios.Visible = false;
                                btnAgregar.Text = "Crear Articulo";
                                btnEliminarArticulo.Visible = false;
                                break;
                            case 8:
                                divEstadisticas.Visible = false;
                                cargarNuevaCategoria();
                                break;
                            case 9:
                                divEstadisticas.Visible = false;
                                cargarNuevaMarca();
                                break;
                        }
                    }
                    else
                    {
                        CargarListaPanelAdmin();
                    }
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

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


        //############################## METODOS ##############################
        #region METODOS
        // METODOS USUARIO
        // TODO: Cargar Usuario en Admin
        private void CargarUsuario()
        {
            NegocioUsuario = new NegocioUsuario();
            usuarioList = NegocioUsuario.ListarUsuarios();
            dgvAdminUsuario.DataSource = usuarioList;
            dgvAdminUsuario.DataBind();
            ddlAgregarArticuloPedido_Articulos.Visible = false;
            divEstadisticas.Visible = false;
            lblAdministracionUsuarios.Visible = true;
            filtrosUsuarios.Visible = true;
        }

        // TODO: Cargar Usuario para Editar en Admin
        private void CargarUsuarioParaEditar(int idMatch)
        {
            NegocioUsuario = new NegocioUsuario();
            usuario = NegocioUsuario.BuscarUsuarioPorId(idMatch);
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Mail;
            txtClave.Text = usuario.Clave;
            txtDni.Text = usuario.Dni.ToString();
            txtDomicilio.Text = usuario.Direccion;
            ddlTipoUsuario.SelectedValue = usuario.Nivel.ToString();
            txtId.Text = usuario.Id.ToString();
        }


        // METDOS ARTICULOS
        // TODO: Cargar Articulos en Admin
        private void CargarArticulos()
        {
            try
            {
                FiltrosArticulos.Visible = true;
                divEstadisticas.Visible = false;

                //Cargar filtros
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

                //Cargar Articulos
                NegocioArticulo = new NegocioArticulo();
                Session.Add("listaPrincipal", NegocioArticulo.ListarArticulos()); //guardamos/pisamos lista principal para su uso en filtro

                lblAdministracionArticulos.Visible = true;
                articuloList = NegocioArticulo.ListarArticulos();
                dgvAdmin.DataSource = articuloList;
                dgvAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Filtrar Lista
        private List<Articulo> filtrarLista(object param, string tipoParam = null)
        {
            try
            {
                //gatillo de seguridad
                if (Session["listaPrincipal"] == null)
                    return null;
                if (Session["listaFiltrada"] == null)
                    Session.Add("listaFiltrada", new List<Articulo>());

                //Asingnamos listas a variables
                List<Articulo> listaPrincipal = (List<Articulo>)Session["listaPrincipal"];
                List<Articulo> listaFiltrada = (List<Articulo>)Session["listaFiltrada"];

                // Si es un parametro string, filtramos lista principal y agregamos con ese filtro
                if (param is string)
                {
                    string match = param as string;

                    if (tipoParam == "estado")
                    {
                        if (match == "Activo")
                            listaFiltrada = listaPrincipal.FindAll(art => art.Estado == true);
                        else if (match == "Inactivo")
                            listaFiltrada = listaPrincipal.FindAll(art => art.Estado == false);
                    }
                    else
                    {
                        listaFiltrada = listaPrincipal.FindAll(
                            x => (x.Nombre.ToUpperInvariant().Contains(match.ToUpperInvariant()) ||
                            x.Marca.Descripcion.ToUpperInvariant().Contains(match.ToUpperInvariant()))
                            );
                    }
                }
                // Si es un parametro entero, filtramos lista principal y agregamos con ese filtro
                else if (param is int)
                {
                    int match = (int)param;

                    if (tipoParam == "idCate")
                        listaFiltrada = listaPrincipal.FindAll(art => art.Categoria.Id == match);
                    else if (tipoParam == "idMarca")
                        listaFiltrada = listaPrincipal.FindAll(art => art.Marca.Id == match);
                }

                // Guardamos la lista filtrada en session
                Session["listaFiltrada"] = listaFiltrada;
                return listaFiltrada;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Filtro Caegorias
        protected void btnFiltroCate_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAdmin.DataSource = filtrarLista(int.Parse(((Button)sender).CommandArgument), "idCate");
                dgvAdmin.DataBind();
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
                dgvAdmin.DataSource = filtrarLista(int.Parse(((Button)sender).CommandArgument), "idMarca");
                dgvAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Filtro Estado Alta
        protected void btnFiltroEstadoAlta_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAdmin.DataSource = filtrarLista(((Button)sender).CommandArgument, "estado");
                dgvAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Filtro Estado Baja
        protected void btnFiltroEstadoBaja_Click(object sender, EventArgs e)
        {
            try
            {
                dgvAdmin.DataSource = filtrarLista(((Button)sender).CommandArgument, "estado");
                dgvAdmin.DataBind();
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
            try
            {
                List<Articulo> listaArticulos;
                List<Articulo> listaFiltrada;

                if (Session["listaFiltrada"] == null)
                    Session.Add("listaFiltrada", new List<Articulo>());

                listaArticulos = (List<Articulo>)Session["listaPrincipal"];
                if (listaArticulos == null) return;

                listaFiltrada = listaArticulos.FindAll(x =>
                    x.Categoria.Descripcion.Contains(ddlFiltroCategoria.Text)
                    && x.Marca.Descripcion.Contains(ddlFiltroMarca.Text));

                Session["listaFiltrada"] = listaFiltrada;
                dgvAdmin.DataSource = listaFiltrada;
                dgvAdmin.DataBind();
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
                //cargamos lista de articulos
                List<Articulo> listaArticulos;
                if (Session["listaFiltrada"] == null)
                    listaArticulos = (List<Articulo>)Session["listaPrincipal"];
                else
                    listaArticulos = (List<Articulo>)Session["listaFiltrada"];

                //rendereamos la lista ordenada y rendereamos
                dgvAdmin.DataSource = listaArticulos?.OrderByDescending(Productos => Productos.precio).ToList();
                dgvAdmin.DataBind();

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
                //cargamos lista de articulos (ver si no da errores)
                List<Articulo> listaArticulos;
                if (Session["listaFiltrada"] == null)
                    listaArticulos = (List<Articulo>)Session["listaPrincipal"];
                else
                    listaArticulos = (List<Articulo>)Session["listaFiltrada"];

                //rendereamos la lista ordenada
                dgvAdmin.DataSource = listaArticulos?.OrderBy(Productos => Productos.precio).ToList();
                dgvAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx");
            }

        }

        //TODO: Boton Borrar Filtros
        protected void btnBorrarFilros_Click(object sender, EventArgs e)
        {
            //ver si borrar obj listas de art en session o no aca ....
            Session.Remove("listaFiltrada");
            //Session.Remove("listaPrincipal"); //mmm ver si hace falta esta linea o no
            Response.Redirect("Admin.aspx?id=5", false);
        }

        // METDOS CATEGORIA Y MARCAS
        // TODO: Cargar Categorias en Admin
        private void CargarCategorias()
        {
            divEstadisticas.Visible = false;
            dgvAdminCrearCate.Visible = true;
            NegocioCategoria = new NegocioCategoria();
            categoriaList = NegocioCategoria.ListarCategorias();
            dgvAdminCateTitle.Visible = true;
            dgvAdminCate.DataSource = categoriaList;
            dgvAdminCate.DataBind();
        }
        // TODO: Cargar Marcas en Admin
        private void CargarMarcas()
        {
            divEstadisticas.Visible = false;
            NegocioMarca = new NegocioMarca();
            MarcaList = NegocioMarca.ListarMarcas();
            dgvAdminMarca.DataSource = MarcaList;
            dgvAdminMarca.DataBind();
            titleMarcas.Visible = true;
            sectionAgregarMarca.Visible = true;
        }


        // METDOS PEDIDOS
        // TODO: Cargar Pedidos en Admin
        private void CargarPedidos()
        {
            divEstadisticas.Visible = false;
            NegocioPedido = new NegocioPedido();
            PedidoList = NegocioPedido.ListarPedidos();
            dgvAdminPedidos.DataSource = PedidoList;
            dgvAdminPedidos.DataBind();
            dgvAdminPedidos.Visible = true;
            dgvAdminUsuario.Visible = false;
            lblAdministracionPedidos.Visible = true;
            filtrosPedidos.Visible = true;
            divEstadisticas.Visible = false;
        }

        // TODO: Cargar Pedidos en Admin con Filtro
        private void CargarPedidos(string filtro)
        {
            NegocioPedido = new NegocioPedido();
            PedidoList = NegocioPedido.ListarPedidos(filtro);
            dgvAdminPedidos.DataSource = PedidoList;
            dgvAdminPedidos.DataBind();
            dgvAdminPedidos.Visible = true;
            lblAdministracionPedidos.Visible = true;
            filtrosPedidos.Visible = true;
            divEstadisticas.Visible = false;
        }

        // TODO: Cargar Pedido en form de actualizacion
        private void CargarPedidoEnForm(Pedido pedido)
        {
            if (pedido == null) return;
            txtIdPedidoEditar.Text = pedido.IdPedido.ToString();
            txtIdUsuarioEditarPedido.Text = pedido.IdUsuario.ToString();
            txtNombreUsuarioEditarPedido.Text = pedido.Usuario;
            txtEstadoEditarPedido.Text = pedido.Estado;
            txtDirEditarPedido.Text = pedido.DireccionEntrega;
            txtFechaEditarPedido.Text = pedido.fecha.ToString();
            txtDescuentoEditarPedido.Text = pedido.Descuento.ToString();
            txtTotalEditarPedido.Text = pedido.PrecioTotal;
            //txtCantidadTotalEditarPedido.Text = pedido.Cantidad.ToString();
            txtCantidadTotalEditarPedido.Text = pedido.CantidadTotal.ToString();
        }

        // TODO: Cargar Pedido del Form en Objeto
        private void CargarPedidoDelForm(Pedido pedido, bool check = true)
        {
            if (pedido == null) return;
            pedido.IdPedido = !string.IsNullOrWhiteSpace(txtIdPedidoEditar.Text) ? int.Parse(txtIdPedidoEditar.Text) : -1;
            pedido.IdUsuario = int.Parse(txtIdUsuarioEditarPedido.Text);
            pedido.Usuario = txtNombreUsuarioEditarPedido.Text;
            pedido.Estado = txtEstadoEditarPedido.Text;
            pedido.DireccionEntrega = txtDirEditarPedido.Text;
            pedido.fecha = DateTime.Parse(txtFechaEditarPedido.Text);
            pedido.Descuento = int.Parse(txtDescuentoEditarPedido.Text);
            pedido.Cantidad = int.Parse(txtCantidadTotalEditarPedido.Text);

            if (!string.IsNullOrWhiteSpace(txtTotalEditarPedido.Text))
                pedido.precioTotal = decimal.Parse(txtTotalEditarPedido.Text, NumberStyles.Currency);
            txtIdUsuarioEditarPedido.Enabled = false;
        }

        // TODO: Cargar Pedido_Articulos en Admin
        private void CargarPedido_Articulos() //ver si usar
        {
            try
            {
                NegocioPedido = new NegocioPedido();
                Pedido_articulos = NegocioPedido.ListarPerdido_articulos();
                dgvPedido_Articulos.DataSource = Pedido_articulos;
                dgvPedido_Articulos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // Mensajes
        private void mensajes()
        {
            try
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
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        #endregion METODOS

        //############################## EVENTOS ##############################
        // Eventos de la pagina:
        protected void btnSingOutMenuAdmin_Click(object sender, EventArgs e)
        {
            try
            {
                Session.Remove("usuarioActual");
                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        #region LOGICA PEDIDOS
        // TODO: BOTON Dar Alta Pedido en Grid: METODO SIN USO Y SENTIDO, SACAR LUEGO PARA NO ROMPER NADA
        protected void btnAltaBajaPedido_Click(object sender, EventArgs e)
        {
            try
            {
                int idMatch = int.Parse(((Button)sender).CommandArgument);

                //NegocioArticulo = new NegocioArticulo();
                //NegocioArticulo.DarAltaBajaUsuario(idMatch, true);
                //dgvAdmin.DataSource = NegocioArticulo.ListarArticulos();
                //dgvAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Cargar panel de pedidos solicitados del panel principal al entrar como admin
        protected void CargarListaPanelAdmin()
        {
            try
            {
                NegocioPedido = new NegocioPedido();
                rptListaPedidosPanel.DataSource = NegocioPedido.ListarPedidos();
                rptListaPedidosPanel.DataBind();

                // Cambiar el estilo del panel según el estado del pedido
                foreach (RepeaterItem item in rptListaPedidosPanel.Items)
                {
                    Label lblEstadoPedidoPanel = (Label)item.FindControl("lblEstadoPedidoPanel");
                    lblEstadoPedidoPanel.Text = lblEstadoPedidoPanel.Text.ToUpper();
                    if (lblEstadoPedidoPanel.Text == "INICIADO")
                    {
                        lblEstadoPedidoPanel.CssClass = "badge bg-warning";
                    }
                    else if (lblEstadoPedidoPanel.Text == "TERMINADO")
                    {
                        lblEstadoPedidoPanel.CssClass = "badge bg-success";
                    }
                    else if (lblEstadoPedidoPanel.Text == "CANCELADO")
                    {
                        lblEstadoPedidoPanel.CssClass = "badge bg-danger";
                    }
                }
                lblCantPedidos.Text = NegocioPedido.CantidadPedidos().ToString();
                lblRecaudacionPedidos.Text = string.Format("{0:C2}", NegocioPedido.RecaudacionTotal());
                lblRecaudacionProm.Text = string.Format("{0:C2}", NegocioPedido.RecaudacionPromedio());
                lblPedidosCompletados.Text = NegocioPedido.PedidosCompletados().ToString();
                lblPedidosPendientes.Text = NegocioPedido.PedidosPendientes().ToString();
                lblCantidadUsuarios.Text = NegocioPedido.CantidadUsuarios().ToString();
                lblArtRegistrados.Text = NegocioPedido.CantidadArticulos().ToString();
                lblCantMarcas.Text = NegocioPedido.CantidadMarcas().ToString();
                lblCantPedidosMesAnterior.Text = new NegocioPedido().CantPedidosMesAnterior().ToString();

                //validaciones para colores segun el resultado de la query
                if (NegocioPedido.CantPedidosMesAnterior() > 0)
                {
                    lblCantPedidosMesAnterior.CssClass = "mdi mdi-arrow-bottom-right fw-bold text-success";
                }
                else
                {
                    lblCantPedidosMesAnterior.CssClass = "mdi mdi-arrow-bottom-right fw-bold text-danger";
                }
                //fin validaciones
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // TODO: BOTON ir Editar/Detalle Pedido en Grid (IMPORTANTE)
        protected void ibtEditarPedido_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //cargamos variables
                int idMatch = Convert.ToInt32(((ImageButton)sender).CommandArgument);
                Session.Add("idPedidoEditar", idMatch);
                NegocioPedido = new NegocioPedido();

                //buscamos el pedido
                PedidoList = NegocioPedido.ListarPedidos(idMatch, "IdPedido");
                dgvAdminPedido.DataSource = PedidoList;
                dgvAdminPedido.DataBind();

                //buscamos los articulos del pedido
                Session.Add("PedidoArticulosListaEdit", NegocioPedido.ListarPedido_articulo(idMatch));
                Pedido_articulos = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;

                dgvPedido_Articulos.DataSource = Pedido_articulos;
                dgvPedido_Articulos.DataBind();

                //Cargamos pedido en form
                int cantTotal = 0;
                Pedido_articulos.ForEach(x => cantTotal += x.Cantidad);
                PedidoList[0].CantidadTotal = cantTotal;

                CargarPedidoEnForm(PedidoList[0]);
                sectionAdminPedidoUnitario.Visible = true;

                //cargamos los id de los articulos que hay en BD
                ddlAgregarArticuloPedido_Articulos.DataSource = new NegocioArticulo().ListarArticulos();
                ddlAgregarArticuloPedido_Articulos.DataTextField = "Id";
                ddlAgregarArticuloPedido_Articulos.DataValueField = "Id";
                ddlAgregarArticuloPedido_Articulos.DataBind();

                //quitamos/mostramos
                dgvAdminPedido.Visible = true;
                dgvAdminPedidos.Visible = false;
                dgvPedido_Articulos.Visible = true;
                upadetePanelPedidosEditar.Visible = true;
                lblNuevoPedido.Visible = false;
                lblEditarPedido.Visible = true;
                btnEliminarPedido_Articulos.Visible = true;
                accordionPedidoArticulos.Visible = true;

                lblArticulosXidPedido_Articulos.Visible = false;
                ddlAgregarArticuloPedido_Articulos.Visible = false;
                btnAgregarArticuloPedido_ArticulosFinal.Visible = false;

                ddlAgregarArticuloPedido_Articulos.Visible = true;
                btnAgregarArticuloPedido_ArticulosFinal.Visible = true;
                lblArticulosXidPedido_Articulos.Visible = true;
                txtTotalEditarPedido.Enabled = false;
                txtNombreUsuarioEditarPedido.Enabled = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // TODO: BOTONES PEDIDOS MENU
        protected void btnPedidosMenu_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoBoton = (sender as LinkButton).CommandName;
                switch (tipoBoton)
                {
                    case "btnPedidosTodos":
                        Response.Redirect("Admin.aspx?id=1", false);
                        break; // no usos despues de aca, pero lo dejo por si las dudas (filtra por tipo de estado la listra principal)
                    case "btnPedidosPendientes":
                        CargarPedidos("Pendiente");
                        break;
                    case "btnPedidosEntregados":
                        CargarPedidos("Entregado");
                        break;
                    case "btnPedidosCancelados":
                        CargarPedidos("Cancelados");
                        break;
                    default:
                        HelperUsuario.MensajePopUp(this, "Ocurrio un error inesperado");
                        break;
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Volver Lista Pedidos
        protected void btnVolverListaPedidos_Click(object sender, EventArgs e)
        {
            string filtro = ((LinkButton)sender).CommandName;
            if (filtro == "btnVolverListaPedidos")
            {
                dgvAdminPedidos.Visible = true;
                dgvAdminPedido.Visible = false;
                sectionAdminPedidoUnitario.Visible = false;

                dgvPedido_Articulos.Visible = false;
                upadetePanelPedidosEditar.Visible = false;
                dgvAdmin.Visible = false;
                Response.Redirect("Admin.aspx?id=1", false);
            }
        }

        // TODO: Boton Agregar/Modificar Pedido Final (importante)
        protected void btnModificarAgregarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                // Cargamos variables e instanciamos objetos
                NegocioPedido = new NegocioPedido();
                Pedido pedido = new Pedido();
                //validamos
                if (string.IsNullOrWhiteSpace(txtIdPedidoEditar.Text))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Id pedido no puede estar vacio";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtIdUsuarioEditarPedido.Text))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Id usuario no puede estar vacio";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtNombreUsuarioEditarPedido.Text))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Nombre usuario no puede estar vacio";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtEstadoEditarPedido.Text))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Estado no puede estar vacio";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDirEditarPedido.Text))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Direccion no puede estar vacio";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtFechaEditarPedido.Text))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Fecha no puede estar vacio";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtDescuentoEditarPedido.Text) || !txtDescuentoEditarPedido.Text.All(c => char.IsDigit(c) || char.IsNumber(c)))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Descuento no puede estar vacio y tiene que ser un numero";
                    return;
                }
                if (string.IsNullOrWhiteSpace(txtCantidadTotalEditarPedido.Text) || !txtCantidadTotalEditarPedido.Text.All(c => char.IsDigit(c) || char.IsNumber(c)))
                {
                    lblErrorPedidos.Visible = true;
                    lblErrorPedidosText.Text = "Cantidad no puede estar vacio y tiene que ser un numero";
                    return;
                }

                //if (string.IsNullOrWhiteSpace(txtTotalEditarPedido.Text) || !txtTotalEditarPedido.Text.All(c => char.IsDigit(c) || char.IsNumber(c)))
                //{
                //    lblErrorPedidos.Visible = true;
                //    lblErrorPedidosText.Text = "Total no puede estar vacio y tiene que ser un numero";
                //    return;
                //}
                CargarPedidoDelForm(pedido);
                int res = 0;

                // Comprobamos que el Id del usuario exista
                int idMatch = int.Parse(txtIdUsuarioEditarPedido.Text);
                NegocioUsuario = new NegocioUsuario();
                int resUser = 0;
                resUser = NegocioUsuario.ComprobarId(idMatch);
                if (resUser == 0)
                {
                    lblAlertUsuarioNoEncontrado.Visible = true;
                    btnModificarAgregarPedido.Enabled = false;
                    return;
                }

                // editamos pedido y buscamos lista Pedido_Articulos en Session
                List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;

                // Si lista_pedido_articulos es null, es porque no se agrego ningun articulo al pedido, cortamos modificacion
                if (listaPedido_Articulo == null)
                {
                    HelperUsuario.MensajePopUp(this, "No hay articulos en Pedido");
                    return;
                }
                //calculamos nuevo total
                int resTotal = listaPedido_Articulo.Sum(x => x.Cantidad);
                if (resTotal != pedido.Cantidad)
                {
                    HelperUsuario.MensajePopUp(this, "Cantidades distintas, verificar");
                }

                // Editamos pedido en DB (IMPORTANTE)
                res = NegocioPedido.EditarPedido(pedido);

                // Eliminamos Pedidos_Articulos en DB anterior para piasar los anteriores, no funciona bien sino
                for (int i = 0; i < listaPedido_Articulo.Count; i++)
                {
                    NegocioPedido.EliminarPedido_articulo(pedido.IdPedido);
                }

                // Agregamos los articulos nuevos Pedido_Articulo en DB segun el estado del pedido y la cantidad en lista Pedido_Articulos
                res += NegocioPedido.AgregarPedido_articulo(listaPedido_Articulo);

                // Mensaje de exito o error
                if (res >= 1)
                {
                    HelperUsuario.MensajePopUp(this, "Pedido editado con exito");
                    dgvAdminPedido.DataSource = new NegocioPedido().ListarPedidos(pedido.IdPedido, "IdPedido");
                    dgvAdminPedido.DataBind();
                }
                else if (res == 0)
                    HelperUsuario.MensajePopUp(this, "Ocurrio un error al intentar guardar los cambios");
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton SUMAR Articulo en Editar Pedidos
        protected void btnAgregarArtPedido_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                // Cargamos variables e instanciamos objetos
                int idArticulo = int.Parse(((ImageButton)sender).CommandArgument);
                List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;
                decimal nuevoTotal = 0;
                int nuevaCantidad = 0;

                //calculamos el nuevo total y acumulamos items
                listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad += 1;
                foreach (CarritoItem item in listaPedido_Articulo)
                {
                    nuevoTotal += item.Cantidad * item.precio;
                    nuevaCantidad += item.Cantidad;
                }

                //rendereamos otra vez
                txtTotalEditarPedido.Text = string.Format("{0:C2}", nuevoTotal);
                txtNuevoTotal.Text = string.Format("{0:C2}", nuevoTotal);
                txtNuevoTotal.Visible = true;
                txtCantidadTotalEditarPedido.Text = nuevaCantidad.ToString();
                dgvPedido_Articulos.DataSource = listaPedido_Articulo;
                dgvPedido_Articulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton RESTAR Articulo en Editar Pedidos
        protected void btnRestarArtPedido_Click(object sender, ImageClickEventArgs e)
        {
            // Cargamos variables e instanciamos objetos
            int idArticulo = int.Parse(((ImageButton)sender).CommandArgument);
            List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;
            decimal nuevoTotal = 0;
            int nuevaCantidad = 0;

            //calculamos nuevo total y restamos items
            listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad -= 1; //restamos aca el item
            if (listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad == 0)
            {
                listaPedido_Articulo.RemoveAll(itm => itm.Id == idArticulo);
            }
            listaPedido_Articulo.ForEach(itm => {
                nuevoTotal += itm.Cantidad * itm.precio;
                nuevaCantidad += itm.Cantidad;
            });

            //rendereamos otra vez
            txtNuevoTotal.Text = string.Format("{0:C2}", nuevoTotal);
            txtTotalEditarPedido.Text = string.Format("{0:C2}", nuevoTotal);
            txtNuevoTotal.Visible = true;
            txtCantidadTotalEditarPedido.Text = nuevaCantidad.ToString();
            dgvPedido_Articulos.DataSource = listaPedido_Articulo;
            dgvPedido_Articulos.DataBind();
        }

        // TODO: Boton Eliminar Articulo en lista Pedido_Articulo
        protected void btnEliminarArtPedido_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                //cargamos variables e instanciamos objetos
                int idArticulo = int.Parse(((ImageButton)sender).CommandArgument);
                decimal nuevoTotal = 0;
                int nuevaCantidad = 0;

                // Eliminamos el articulo de la lista Pedido_Articulo y calculamos el nuevo total
                List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;
                listaPedido_Articulo.RemoveAll(itm => itm.Id == idArticulo);
                listaPedido_Articulo.ForEach(itm => {
                    nuevoTotal += itm.Cantidad * itm.precio;
                    nuevaCantidad += itm.Cantidad;
                });
                if (nuevoTotal < 0) nuevoTotal = 0;

                //rendereamos otra vez
                txtNuevoTotal.Text = string.Format("{0:C2}", nuevoTotal);
                txtNuevoTotal.Visible = true;
                txtTotalEditarPedido.Text = string.Format("{0:C2}", nuevoTotal);
                txtCantidadTotalEditarPedido.Text = nuevaCantidad.ToString();
                dgvPedido_Articulos.DataSource = listaPedido_Articulo;
                dgvPedido_Articulos.DataBind();
                dgvPedido_Articulos.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Agregar Articulo Nuevo a lista Pedido_Articulos
        protected void btnAgregarArticuloPedido_ArticulosFinal_Click(object sender, EventArgs e)
        {
            //Cargamos variables e instanciamos objetos
            int idPedido = -1; //ID CAMBIADO A -1
            if (Session["idPedidoEditar"] != null)
                idPedido = (int)Session["idPedidoEditar"];

            int idArticulo = int.Parse(ddlAgregarArticuloPedido_Articulos.SelectedValue);
            List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;
            decimal nuevoTotal = 0;
            int nuevaCantidad = 0;

            //Si no hay obj en session, lo agregamos
            if (listaPedido_Articulo == null)
            {
                listaPedido_Articulo = new List<CarritoItem>();
                Session.Add("PedidoArticulosListaEdit", listaPedido_Articulo);
            }

            //Comprobamos si el articulo a agregar ya esta en la lista Pedido_Articulo. Si esta se acumula, renderea y retorna
            if (listaPedido_Articulo.Find(itm => itm.Id == idArticulo) != null)
            {
                listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad += 1;
                listaPedido_Articulo.ForEach(itm => {
                    nuevoTotal += itm.Cantidad * itm.precio;
                    nuevaCantidad += itm.Cantidad;
                });

                txtNuevoTotal.Text = string.Format("{0:C2}", nuevoTotal);
                txtNuevoTotal.Visible = true;
                txtTotalEditarPedido.Text = string.Format("{0:C2}", nuevoTotal);
                txtCantidadTotalEditarPedido.Text = nuevaCantidad.ToString();
                dgvPedido_Articulos.DataSource = listaPedido_Articulo;
                dgvPedido_Articulos.DataBind();
                return;
            }

            // Agregamos el articulo a la lista Pedido_Articulo
            Articulo newArticulo = new NegocioArticulo().ListarArticulo(idArticulo)[0];

            CarritoItem newItem = new CarritoItem()
            {
                Id = idArticulo,
                Cantidad = 1,
                Nombre = newArticulo.Nombre,
                Categoria = newArticulo.Categoria.Descripcion,
                Descripcion = newArticulo.Descripcion,
                Estado = newArticulo.Estado ? "Alta" : "Baja",
                IdPedido = idPedido, // ACA SE ASIGNA EL ID DEL PEDIDO
                precio = newArticulo.precio,
                ImagenUrl = newArticulo.ImagenUrl,
                Marca = newArticulo.Marca.Descripcion,
                Stock = newArticulo.Stock,
            };

            //render de la lista Pedido_Articulo y calculamos el nuevo total (primero el .Add() para que calcule bien)
            listaPedido_Articulo.Add(newItem);
            listaPedido_Articulo.ForEach(itm => nuevoTotal += itm.Cantidad * itm.precio);

            txtTotalEditarPedido.Text = string.Format("{0:C2}", nuevoTotal);
            txtNuevoTotal.Text = string.Format("{0:C2}", nuevoTotal);
            txtNuevoTotal.Visible = true;
            dgvPedido_Articulos.DataSource = listaPedido_Articulo;
            dgvPedido_Articulos.DataBind();
        }

        //TODO: Boton Eliminar Pedido
        protected void btnEliminarPedido_Articulos_Click(object sender, EventArgs e)
        {
            try
            {
                int idPedido = (int)Session["idPedidoEditar"];
                int res = 0;
                NegocioPedido = new NegocioPedido();
                res += NegocioPedido.EliminarPedido_articulo(idPedido);
                res += NegocioPedido.EliminarPedido(idPedido);

                if (res >= 1)
                {
                    Session["MensajeExito"] = "Pedido eliminado";
                    Response.Redirect("Admin.aspx?id=2", false);
                }
                else
                {
                    HelperUsuario.MensajePopUp(this, "Error al eliminar pedido");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Crear Nuevo Pedido
        protected void btnCrearNuevoPedidoMenu_Click(object sender, EventArgs e)
        {
            try
            {
                //cargamos los id de los articulos que hay en BD
                ddlAgregarArticuloPedido_Articulos.DataSource = new NegocioArticulo().ListarArticulos();
                ddlAgregarArticuloPedido_Articulos.DataTextField = "Id";
                ddlAgregarArticuloPedido_Articulos.DataValueField = "Id";
                ddlAgregarArticuloPedido_Articulos.DataBind();

                if (Session["PedidoArticulosListaEdit"] != null)
                    Session.Remove("PedidoArticulosListaEdit");

                upadetePanelPedidosEditar.Visible = true;
                dgvAdminPedidos.Visible = false;
                lblNuevoPedido.Visible = true;
                lblEditarPedido.Visible = false;
                btnEliminarPedido_Articulos.Visible = false;
                dgvAdminPedido.Visible = false;
                accordionPedidoArticulos.Visible = true;
                lblArticulosXidPedido_Articulos.Visible = true;
                ddlAgregarArticuloPedido_Articulos.Visible = true;
                btnAgregarArticuloPedido_ArticulosFinal.Visible = true;

                txtFechaEditarPedido.Text = DateTime.Now.ToString("yyyy-MM-dd");
                btnAgregarPedido.Visible = true;
                btnModificarAgregarPedido.Visible = false;
                filtrosPedidos.Visible = false;
                divEstadisticas.Visible = false;
                lblAdministracionArticulos.Visible = false;
                FiltrosArticulos.Visible = false;
                dgvAdmin.Visible = false;
                lblAdministracionPedidos.Visible = true;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Cancelar/Terminar Pedido
        protected void btnCancelarTerminarPedido(object sender, EventArgs e)
        {
            int idPedido = int.Parse(((Button)sender).CommandArgument);
            string tipo = ((Button)sender).CommandName;
            if (tipo == "Cancelar")
            {
                try
                {
                    NegocioPedido = new NegocioPedido();
                    NegocioPedido.ModificarEstado(idPedido, "CANCELADO");
                    dgvAdminPedidos.DataSource = NegocioPedido.ListarPedidos();
                    dgvAdminPedidos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
            else if (tipo == "Terminar")
            {
                try
                {
                    NegocioPedido = new NegocioPedido();
                    NegocioPedido.ModificarEstado(idPedido, "TERMINADO");
                    dgvAdminPedidos.DataSource = NegocioPedido.ListarPedidos();
                    dgvAdminPedidos.DataBind();
                }
                catch (Exception ex)
                {
                    Session.Add("error", ex);
                    Response.Redirect("Error.aspx", false);
                }
            }
        }

        //TODO: Boton Buscar Articulo por ID Pedido_Articulos
        protected void btnBuscarArticuloXid_Pedido_Articulos_Click(object sender, EventArgs e)
        {
            try
            {
                int idMatch = int.Parse(txtIdArticuloAbuscar_Pedido_Articulos.Text);
                NegocioArticulo = new NegocioArticulo();
                dgvArticuloBuscado_Pedido_Articulos.DataSource = NegocioArticulo.ListarArticulo(idMatch);
                dgvArticuloBuscado_Pedido_Articulos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Agregar Nuevo Pedido
        protected void btnAgregarPedido_Click(object sender, EventArgs e)
        {
            try
            {
                // Cargamos variables e instanciamos objetos
                lblAlertUsuarioNoEncontrado.Visible = false;
                NegocioPedido = new NegocioPedido();
                Pedido pedido = new Pedido();
                CargarPedidoDelForm(pedido);
                int iDpedidoRes = 0;
                int resAgregarArticulos = 0;

                // Comprobamos que el Id del usuario exista
                int idMatch = int.Parse(txtIdUsuarioEditarPedido.Text);
                NegocioUsuario = new NegocioUsuario();
                int resUser = 0;
                resUser = NegocioUsuario.ComprobarId(idMatch);
                if (resUser == 0)
                {
                    lblAlertUsuarioNoEncontrado.Visible = true;
                    btnModificarAgregarPedido.Enabled = false;
                    return;
                }

                // Comprobamos articulos nuevos a crear
                List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;
                if (listaPedido_Articulo == null)
                {
                    HelperUsuario.MensajePopUp(this, "No hay articulos en el pedido");
                    return;
                }
                else
                {
                    int resCant = 0;
                    listaPedido_Articulo.ForEach(itm => resCant += itm.Cantidad);
                    if (resCant == 0)
                    {
                        HelperUsuario.MensajePopUp(this, "No hay articulos en el pedido");
                        return;
                    }
                    else
                    {
                        pedido.Cantidad = resCant;
                        pedido.CantidadTotal = resCant;
                    }

                }

                // Creamos el pedido
                iDpedidoRes = NegocioPedido.AgregarPedido(pedido, "sp");

                // Si se creo el pedido, creamos los articulos del pedido
                if (iDpedidoRes <= 0)
                {
                    HelperUsuario.MensajePopUp(this, "Ocurrio un Error al agregar el pedido");
                    return;
                }
                else
                {
                    // Cargamos el id del pedido en cada articulo y creamos en bd los articulos asociados al pedido
                    NegocioPedido.CargarIdPedido(listaPedido_Articulo, iDpedidoRes);
                    resAgregarArticulos = NegocioPedido.AgregarPedido_articulo(listaPedido_Articulo);
                }

                //confirmamos carga
                if (resAgregarArticulos > 0)
                {
                    Session["MensajeExito"] = "Pedido Cargado Correcatamente";
                    Response.Redirect("Admin.aspx?id=2", false);
                }
                else
                {
                    HelperUsuario.MensajePopUp(this, "Ocurrio un Error al agregar el pedido");
                    return;
                }


            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        #endregion//FIN BOTONES LOGICA PEDIDOS


        #region TODO: LOGICA USUARIO
        // TODO: BOTON EDITAR USUARIO EN GRID
        protected void ibtEditarUsuario_Click(object sender, ImageClickEventArgs e)
        {
            sectionModificarUsuario.Visible = true;
            dgvAdminUsuario.Visible = false;
            CargarUsuarioParaEditar(int.Parse((sender as ImageButton).CommandArgument));
            btnAltaUsuario.Visible = true;
            btnBajaUsuario.Visible = true;
            btnEliminarUsuario.Visible = true;
            filtrosUsuarios.Visible = false;
        }

        // TODO: BOTON ACTUALIZAR/CREAR USUARIO (Importante)
        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            try
            {
                //si es valido los imputs
                if (Page.IsValid)
                {
                    if (string.IsNullOrEmpty(txtNombre.Text) || string.IsNullOrEmpty(txtApellido.Text) || string.IsNullOrEmpty(txtDni.Text) || string.IsNullOrEmpty(txtEmail.Text) || string.IsNullOrEmpty(txtClave.Text) || string.IsNullOrEmpty(txtDomicilio.Text))
                    {
                        HelperUsuario.MensajePopUp(this, "Hay campos erróneos o vacíos");
                        return;
                    }

                    // cargamos los datos
                    usuario = new Usuario();
                    usuario.Nombre = txtNombre.Text;
                    usuario.Apellido = txtApellido.Text;
                    usuario.Mail = txtEmail.Text;
                    usuario.Clave = txtClave.Text;
                    usuario.Dni = int.Parse(txtDni.Text);
                    usuario.Direccion = txtDomicilio.Text;
                    usuario.UrlImgUsuario = "img/usuarios/default.png";
                    usuario.Nivel = ddlTipoUsuario.SelectedValue.ToString();
                    usuario.Activo = true;
                    NegocioUsuario = new NegocioUsuario();

                    // si es modo agregar
                    int res = 0;
                    if (btnGuardarUsuario.Text == "Agregar Usuario")
                    {
                        btnGuardarUsuario.Text = "Guardar Cambios";
                        //si usuario ya existe, cortamos la carga, sino cargamos
                        if (!HelperUsuario.ExistUser(usuario))
                        {
                            res = NegocioUsuario.AgregarUsuario(usuario);
                            HelperUsuario.MensajePopUp(this, "Usuario Agregado Exitosamente");
                        }
                        else
                        {
                            HelperUsuario.MensajePopUp(this, "El usuario ya existe");
                            dgvAdminUsuario.Visible = true;
                            return;
                        }
                    }
                    // si es modo modificar
                    else if (btnGuardarUsuario.Text == "Guardar Cambios")
                    {
                        res = NegocioUsuario.EditarUsuario(usuario);
                        HelperUsuario.MensajePopUp(this, "Registro Modificado Exitosamente");
                    }

                    if (res == 0)
                        HelperUsuario.MensajePopUp(this, "Ocurrio un Error Inesperado"); // va a tirar dos msj si no guarda, mejorar para manejar el error

                    // recargamos la lista
                    usuarioList = NegocioUsuario.ListarUsuarios();
                    dgvAdminUsuario.DataSource = usuarioList;
                    dgvAdminUsuario.DataBind();
                    dgvAdminUsuario.Visible = true;
                    //Response.Redirect("Admin.aspx?id=6");
                }
                else
                {
                    HelperUsuario.MensajePopUp(this, "Hubo error en una validación");
                }


            }
            catch (Exception ex)
            {

                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // TODO: BOTON DAR DE BAJA USUARIO (Logica)
        protected void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            NegocioUsuario = new NegocioUsuario();
            int idMatch = int.Parse(((Button)sender).CommandArgument);
            NegocioUsuario.DarBajaUsuario(idMatch);
            //CargarUsuario();
            usuarioList = NegocioUsuario.ListarUsuarios();
            dgvAdminUsuario.DataSource = usuarioList;
            dgvAdminUsuario.DataBind();
            dgvAdminUsuario.Visible = true;
            //Response.Redirect("Admin.aspx?id=6");
        }

        // TODO: BOTON ELIMINAR USUARIO (Fisica)
        protected void btnEliminarUsuario_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            NegocioUsuario = new NegocioUsuario();
            usuario.Id = int.Parse(txtId.Text);
            NegocioUsuario.EliminarUsuario(usuario.Id);
            CargarUsuario();
            Response.Redirect("Admin.aspx?id=6");
        }
        // TODO: BOTON DAR DE ALTA USUARIO (Logica)
        protected void btnAltaUsuario_Click(object sender, EventArgs e)
        {
            NegocioUsuario = new NegocioUsuario();
            int idMatch = int.Parse(((Button)sender).CommandArgument);
            NegocioUsuario.DarAltaUsuario(idMatch);
            //CargarUsuario();
            usuarioList = NegocioUsuario.ListarUsuarios();
            dgvAdminUsuario.DataSource = usuarioList;
            dgvAdminUsuario.DataBind();
            dgvAdminUsuario.Visible = true;
        }

        // TODO: AGREGAR NUEVO USUARIO
        protected void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {
            btnGuardarUsuario.Text = "Agregar Usuario";

            txtId.Text = string.Empty;
            txtNombre.Text = string.Empty;
            txtApellido.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtClave.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtDomicilio.Text = string.Empty;

            dgvAdminUsuario.Visible = false;
            btnAltaUsuario.Visible = false;
            btnBajaUsuario.Visible = false;
            btnEliminarUsuario.Visible = false;
            sectionModificarUsuario.Visible = true;
            lblAdministracionUsuarios.Visible = true;
            divEstadisticas.Visible = false;
            filtrosUsuarios.Visible = false;
        }

        // TODO: Link Volver a Lista Aneterior (Depende del CommandName del btn)
        protected void lnkVolverListaUsuarios_Click(object sender, EventArgs e)
        {
            string filtro = ((LinkButton)sender).CommandName;

            if (filtro == "btnVolverListaUsuarios")
            {
                dgvAdminUsuario.Visible = true;
                sectionModificarUsuario.Visible = false;
            }
        }
        #endregion // FIN LOGICA USUARIO


        #region TODO: LOGICA ARTICULOS
        //Metodo para agregar articulo
        protected void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                bool validacion = true;
                string tipo = ((Button)sender).Text; // Usar luego
                marca = new Marca();
                marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
                marca.Descripcion = ddlMarca.SelectedItem.ToString();
                //marca.ObtenerMarca(marca.Id);
                categoria = new Categoria();
                categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);
                categoria.Descripcion = ddlCategoria.SelectedItem.ToString();
                //categoria.ObtenerCategoria(categoria.Id);

                NegocioArticulo = new NegocioArticulo();
                articulo = new Articulo();

                //Validamos los campos
                if (string.IsNullOrWhiteSpace(tbIdArt.Text) || !tbIdArt.Text.All(c => char.IsNumber(c)))
                {
                    lblRespuestaError.Text = "Debe ingresar un ID y tiene que ser un numero";
                    lblErrorArticulos.Visible = true;
                    SectionCrearArt.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbNombreArt.Text))
                {
                    lblRespuestaError.Text = "Debe Ingresar un Nombre";
                    lblErrorArticulos.Visible = true;
                    SectionCrearArt.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbPrecioArt.Text))
                {
                    lblRespuestaError.Text = "Debe ingresar un Precio";
                    lblErrorArticulos.Visible = true;
                    SectionCrearArt.Visible = true;
                    return;
                }
                string valor = tbPrecioArt.Text;
                var regexValor = new Regex(@"[\d.,]+");
                if (!regexValor.IsMatch(valor))
                {
                    lblRespuestaError.Text = "El Precio esta mal Ingresado";
                    lblErrorArticulos.Visible = true;
                    SectionCrearArt.Visible = true;
                    return;
                }
                if (string.IsNullOrWhiteSpace(tbStockArt.Text))
                {
                    lblRespuestaError.Text = "Debe ingresar un stock";
                    lblErrorArticulos.Visible = true;
                    SectionCrearArt.Visible = true;
                    return;
                }
                if (!tbStockArt.Text.All(c => char.IsDigit(c) || char.IsNumber(c)))
                {
                    lblRespuestaError.Text = "El Stock esta mal Ingresado";
                    lblErrorArticulos.Visible = true;
                    SectionCrearArt.Visible = true;
                    return;
                }
                //fin validaciones

                //cargamos los datos del articulo
                string str = tbPrecioArt.Text;
                var regex = new Regex(@"[\d.,]+");
                var match = regex.Match(str);
                decimal result = Convert.ToDecimal(match.Value);

                //validamos que no tengamos stock y precio negativo
                if (result < 0 || int.Parse(tbStockArt.Text) < 0)
                {
                    lblRespuestaError.Text = "El Precio/Stock no puede ser negativo";
                    lblErrorArticulos.Visible = true;
                    SectionCrearArt.Visible = true;
                    return;
                }
                articulo.Id = Convert.ToInt32(tbIdArt.Text);
                articulo.Nombre = tbNombreArt.Text;
                articulo.Descripcion = tbDescripArt.Text;
                articulo.ImagenUrl = tbImgArt.Text;
                articulo.precio = result;
                articulo.Marca = marca;
                articulo.Categoria = categoria;
                articulo.Estado = true;
                articulo.Stock = int.Parse(tbStockArt.Text);

                //Editamos o Creamos un nuevo articulo
                if (btnAgregar.Text == "Crear Articulo")
                {
                    if (NegocioArticulo.crearArticulo(articulo) == 1)
                    {
                        Session["MensajeExito"] = "Articulo Creado Exitosamente";
                        Response.Redirect("Admin.aspx?id=5", false);
                    }
                }
                else if (btnAgregar.Text == "Guardar Cambios")
                {
                    if (NegocioArticulo.editarArticulo(articulo) == 1)
                    {
                        Session["MensajeExito"] = "Articulo Modificado Exitosamente";
                        Response.Redirect("Admin.aspx?id=5", false);
                    }
                }
                else
                {
                    HelperUsuario.MensajePopUp(this, "Hubo un error en la creacion/modificacion del articulo");
                }
            }
            catch (Exception ex)
            {
                Session.Add("Error", ex);
                Response.Redirect("Error.aspx", false);
            }

        } // Verificar luego 

        //TODO: CARGAR DDL EN AGREGAR ART (Marca y Categoria)
        protected void CargaDdl()
        {
            try
            {
                NegocioCategoria = new NegocioCategoria();
                NegocioMarca = new NegocioMarca();
                ddlCategoria.DataSource = NegocioCategoria.ListarCategorias();
                ddlCategoria.DataTextField = "Descripcion";
                ddlCategoria.DataValueField = "Id";
                ddlCategoria.DataBind();
                ddlMarca.DataSource = NegocioMarca.ListarMarcas();
                ddlMarca.DataTextField = "Descripcion";
                ddlMarca.DataValueField = "Id";
                ddlMarca.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // TODO: Evento Imagen Art Cambio de Texto
        protected void tbImgArt_TextChanged(object sender, EventArgs e)
        {
            imgNuevoArt.ImageUrl = tbImgArt.Text;
        }

        // TODO: BOTON Volver Lista Articulos (en form de nuevo Articulo/Modifcar articulo)
        protected void btnLinkVolverListaArticulos_Click(object sender, EventArgs e)
        {
            if (dgvAdmin.DataSource != null)
                dgvAdmin.Visible = true;
            else
            {
                NegocioArticulo = new NegocioArticulo();
                dgvAdmin.DataSource = NegocioArticulo.ListarArticulos();
                dgvAdmin.DataBind();
                dgvAdmin.Visible = true;
                dgvAdminArtUnitario.Visible = false;
                FiltrosArticulos.Visible = true;
                lblAdministracionArticulos.Visible = true;
            }
        }

        //TODO: Boton Dar Alta Articulo Lista
        protected void btnDarAltaArticuloLista_Click(object sender, EventArgs e)
        {
            try
            {
                int idMatch = int.Parse(((Button)sender).CommandArgument);
                NegocioArticulo = new NegocioArticulo();
                NegocioArticulo.DarAltaBajaUsuario(idMatch, true);
                dgvAdmin.DataSource = NegocioArticulo.ListarArticulos();
                dgvAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Dar Baja Articulo Lista
        protected void btnDarBajaArticuloLista_Click(object sender, EventArgs e)
        {
            try
            {
                int idMatch = int.Parse(((Button)sender).CommandArgument);
                NegocioArticulo = new NegocioArticulo();
                NegocioArticulo.DarAltaBajaUsuario(idMatch, false);
                dgvAdmin.DataSource = NegocioArticulo.ListarArticulos();
                dgvAdmin.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Boton Editar Articulo
        protected void btnEditarArticuloLista_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioArticulo = new NegocioArticulo();
                int idMatch = int.Parse(((Button)sender).CommandArgument);

                articuloList = NegocioArticulo.ListarArticulo(idMatch);
                dgvAdminArtUnitario.DataSource = articuloList;
                dgvAdminArtUnitario.DataBind();

                CargarArticuloEnformulario(articuloList[0]);
                ddlCategoria.SelectedValue = articuloList[0].Categoria.Id.ToString();
                ddlMarca.SelectedValue = articuloList[0].Marca.Id.ToString();

                dgvAdminArtUnitario.Visible = true;
                dgvAdmin.Visible = false;
                SectionCrearArt.Visible = true;
                tituloNuevoArticulo.Visible = false;
                tituloEditarArticulo.Visible = true;
                FiltrosArticulos.Visible = false;
                btnAgregar.Text = "Guardar Cambios";
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //TODO: Cargar Articulo en Formulario
        private void CargarArticuloEnformulario(Articulo art)
        {
            tbIdArt.Text = art.Id.ToString();
            tbNombreArt.Text = art.Nombre;
            tbDescripArt.Text = art.Descripcion;
            tbPrecioArt.Text = art.Precio;
            tbStockArt.Text = art.Stock.ToString();
            CargaDdl();
            tbImgArt.Text = art.ImagenUrl;
            imgNuevoArt.ImageUrl = art.ImagenUrl;
        }

        //TODO: Page Index Change en LISTA ARTICULOS
        protected void dgvAdmin_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            dgvAdmin.PageIndex = e.NewPageIndex;
            CargarArticulos();
        }

        //TODO: Boton Eliminar Articulo
        protected void btnEliminarArticulo_Click(object sender, EventArgs e)
        {
            try
            {
                int idMatch = int.Parse(tbIdArt.Text);
                NegocioArticulo = new NegocioArticulo();
                if (NegocioArticulo.eliminarArticulo(idMatch) > 0)
                {

                    Session["MensajeExito"] = "Articulo Eliminado";
                    Response.Redirect("Admin.aspx?id=5", false);
                }
                else
                {
                    HelperUsuario.MensajePopUp(this, "Hubo un error en la eliminacion del articulo");
                }

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        #endregion//FIN LOGICA ARTÍCULOS


        #region LOGICA CATEGORIAS
        // BOTON Agregar Categorias (Ver)
        protected void btnAgregarCategoria_Click(object sender, EventArgs e)
        {
            //si quiere agregar una nueva categoria lo redirige 
            Response.Redirect("Admin.aspx?id=8");
        }
        //TODO: Guardar categoria modificada
        protected void btnGuardarCate_Click(object sender, EventArgs e)
        {
            categoria = new Categoria();
            NegocioCategoria = new NegocioCategoria();

            // Obtener el botón que se hizo clic
            Button btnGuardarCate = (Button)sender;

            // Obtener el contenedor del botón (div.card) utilizando NamingContainer
            RepeaterItem repeaterItem = (RepeaterItem)btnGuardarCate.NamingContainer;
            var cardContainer = (HtmlGenericControl)repeaterItem.FindControl("cardContainer");
            var btnEditarCate = (Button)cardContainer.FindControl("btnEditarCate");

            // Obtener los controles Label y TextBox dentro del contenedor
            var lblCategoria = (Label)cardContainer.FindControl("lblCategoria");
            var txtCategoria = (TextBox)cardContainer.FindControl("txtCategoria");
            var lblIdCate = (Label)cardContainer.FindControl("lblIdCate");
            var lblUrl = (Label)cardContainer.FindControl("lblUrl");
            var tbUrlImg = (TextBox)cardContainer.FindControl("tbUrlImg");
            var lblCambiarImg = (Label)cardContainer.FindControl("lblCambiarImg");

            // Actualizar el texto del Label con el valor ingresado en el TextBox
            lblCategoria.Text = txtCategoria.Text;
            lblUrl.Text = tbUrlImg.Text;

            //asigno valores para guardarlos en bd
            categoria.Id = Convert.ToInt32(lblIdCate.Text);
            categoria.Descripcion = lblCategoria.Text;
            categoria.UrlImagen = lblUrl.Text;

            //validamos que el nombre de la categoría sea valido antes de guardar
            if (txtCategoria.Text == "")
            {
                HelperUsuario.MensajePopUp(this, "El campo no puede estar vacío");
                return;
            }
            else
            {
                // Validar que solo se permitan números y letras
                Regex regex = new Regex("^[a-zA-Z0-9]+$");
                if (!regex.IsMatch(txtCategoria.Text))
                {
                    HelperUsuario.MensajePopUp(this, "Solo se permiten números y letras");
                    return;
                }
                else
                {
                    //guardar categoria
                    NegocioCategoria.editarCategoria(categoria);
                    HelperUsuario.MensajePopUp(this, "Categoría modificada con exito!");

                }
            }

            // Mostrar el Label y ocultar el TextBox
            lblCategoria.Visible = true;
            txtCategoria.Visible = false;
            lblIdCate.Visible = true;
            lblUrl.Visible = false;
            tbUrlImg.Visible = false;
            lblCambiarImg.Visible = false;

            // Ocultar el botón "Guardar" y mostrar el botón "Editar"
            btnGuardarCate.Visible = false;
            btnEditarCate.Visible = true;
        }

        //TODO: Habilitar los label para poder modificar las categorías
        protected void btnEditarCate_Click(object sender, EventArgs e)
        {
            // Obtener el botón que se hizo clic
            Button btnEditarCate = (Button)sender;

            // Obtener el contenedor del botón (div.card) utilizando NamingContainer
            RepeaterItem repeaterItem = (RepeaterItem)btnEditarCate.NamingContainer;
            var cardContainer = (HtmlGenericControl)repeaterItem.FindControl("cardContainer");

            // Obtener los controles Label y TextBox dentro del contenedor
            var lblCategoria = (Label)cardContainer.FindControl("lblCategoria");
            var txtCategoria = (TextBox)cardContainer.FindControl("txtCategoria");
            var lblUrl = (Label)cardContainer.FindControl("lblUrl");
            var tbUrlImg = (TextBox)cardContainer.FindControl("tbUrlImg");
            var lblCambiarImg = (Label)cardContainer.FindControl("lblCambiarImg");

            // Mostrar el TextBox y ocultar el Label
            lblCategoria.Visible = false;
            txtCategoria.Visible = true;
            lblUrl.Visible = false;
            tbUrlImg.Visible = true;
            lblCambiarImg.Visible = true;

            // Establecer el texto del TextBox con el valor actual del Label
            txtCategoria.Text = lblCategoria.Text;
            tbUrlImg.Text = lblUrl.Text;

            // Ocultar el botón "Editar" y mostrar el botón "Guardar"
            var btnGuardarCate = (Button)cardContainer.FindControl("btnGuardarCate");
            btnEditarCate.Visible = false;
            btnGuardarCate.Visible = true;
        }

        //TODO: Evento cambio de ImgUrl
        protected void tbUrlImg_TextChanged(object sender, EventArgs e)
        {
            TextBox tbUrlImg = (TextBox)sender;
            RepeaterItem repeaterItem = (RepeaterItem)tbUrlImg.NamingContainer;
            System.Web.UI.WebControls.Image imgCate = (System.Web.UI.WebControls.Image)repeaterItem.FindControl("imgCate");

            // Asignar el valor del TextBox al ImageUrl del control Image
            imgCate.ImageUrl = tbUrlImg.Text;
        }

        //TODO: Boton Baja Categoria
        protected void btnBajaCate_Click(object sender, EventArgs e)
        {

        }// sin hacer

        //TODO: Boton Eliminar categoria
        protected void btnEliminarCate_Click(object sender, EventArgs e)
        {
            NegocioCategoria = new NegocioCategoria();
            Button btnBajaCate = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btnBajaCate.NamingContainer;
            var cardContainer = (HtmlGenericControl)repeaterItem.FindControl("cardContainer");
            var lblIdCate = (Label)cardContainer.FindControl("lblIdCate");
            NegocioCategoria.borrarCategoria(Convert.ToInt32(lblIdCate.Text));
            Response.Redirect("Admin.aspx?id=4");
        }

        //TODO: Mostrar Nueva Categoria (secction)
        private void cargarNuevaCategoria()
        {
            SectionNuevaCate.Visible = true;
        }

        //TODO: Boton Guardar Nueva Categoria
        protected void btnAgregarCate_Click(object sender, EventArgs e)
        {
            categoria = new Categoria();
            NegocioCategoria = new NegocioCategoria();

            categoria.Id = int.Parse(tbIdCate.Text);
            categoria.Descripcion = tbNombreCate.Text;
            categoria.UrlImagen = tbUrlImgCate.Text;

            //validamos que el nombre de la categoría no exista antes de guardar
            if (HelperUsuario.ExistCategoria(categoria.Id))
            {
                HelperUsuario.MensajePopUp(this, "Ya existe una categoría con ese número ID");
            }
            else
            {
                NegocioCategoria.agregarCategoria(categoria);
                HelperUsuario.MensajePopUp(this, "Nueva categoría registrada con exito!");
                Session["MensajeExito"] = "Nueva categoría registrada con éxito!";
                Response.Redirect("Admin.aspx?id=4");

            }
        }

        //TODO: Evento cambio de ImgUrl Categoria
        protected void tbUrlImgCate_TextChanged(object sender, EventArgs e)
        {
            imgNuevaCate.ImageUrl = tbUrlImgCate.Text;
        }

        //TODO: Boton Volver a Categorias (Ver)
        protected void volverCate_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?id=4");
        }
        #endregion//FIN LOGICA CATEGORIAS


        #region LOGICA MARCAS
        //TODO: LOGICA MARCAS
        //TODO: Evento cambio de ImgUrl Marca
        protected void tbUrlImgMarca_TextChanged(object sender, EventArgs e)
        {
            // Asignar el valor del TextBox al ImageUrl del control Image
            TextBox tbUrlImgMarca = (TextBox)sender;
            RepeaterItem repeaterItem = (RepeaterItem)tbUrlImgMarca.NamingContainer;
            System.Web.UI.WebControls.Image imgMarca = (System.Web.UI.WebControls.Image)repeaterItem.FindControl("imgMarca");
            imgMarca.ImageUrl = tbUrlImgMarca.Text;
        }

        //TODO:Evento cambio de ImgUrl al crear nueva Marca
        protected void tbUrlImgNuevaMarca_TextChanged(object sender, EventArgs e)
        {
            imgNuevaMarca.ImageUrl = tbUrlImgNuevaMarca.Text;
        }

        //TODO: Boton Guardar nueva Marca
        protected void btnGuardarNewMarca_Click(object sender, EventArgs e)
        {
            marca = new Marca();
            NegocioMarca = new NegocioMarca();

            marca.Id = int.Parse(tbIdMarca.Text);
            marca.Descripcion = tbNombreMarca.Text;
            marca.UrlImagen = tbUrlImgNuevaMarca.Text;

            if (HelperUsuario.ExistMarca(marca.Id))
            {
                HelperUsuario.MensajePopUp(this, "Ya existe una marca con ese ID");
            }
            else
            {
                NegocioMarca.AgregarMarca(marca);
                HelperUsuario.MensajePopUp(this, "Nueva marca registrada con exito!");
                Session["MensajeExito"] = "Nueva marca registrada con éxito!";
                Response.Redirect("Admin.aspx?id=3");

            }
        }


        //TODO: Boton Volver a Lista Marcas (ver)
        protected void btnVolverMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?id=3");
        }

        //TODO: Ver Secction Nueva Marca
        private void cargarNuevaMarca()
        {
            SectionNuevaMarca.Visible = true;
        }

        //TODO: Boton Agregar Marca (ver)
        protected void btnAgregarMarca_Click(object sender, EventArgs e)
        {
            Response.Redirect("Admin.aspx?id=9");
        }

        //TODO: Boton 
        protected void btnGuardarMarca_Click(Object sender, EventArgs e)
        {
            // Obtener el botón que se hizo clic
            Button btnGuardarMarca = (Button)sender;

            // Obtener el contenedor del botón (div.card) utilizando NamingContainer
            RepeaterItem repeaterItem = (RepeaterItem)btnGuardarMarca.NamingContainer;
            var cardContainer = (HtmlGenericControl)repeaterItem.FindControl("cardContainerMarca");

            // Obtener los controles Label y TextBox dentro del contenedor
            var lblIdMarca = (Label)cardContainer.FindControl("lblIdMarca");
            var lblMarca = (Label)cardContainer.FindControl("lblMarca");
            var txtMarca = (TextBox)cardContainer.FindControl("txtMarca");
            var lblUrlMarca = (Label)cardContainer.FindControl("lblUrlMarca");
            var tbUrlImgMarca = (TextBox)cardContainer.FindControl("tbUrlImgMarca");

            //asignar valores para guardar
            marca = new Marca();
            NegocioMarca = new NegocioMarca();
            marca.Id = int.Parse(lblIdMarca.Text);
            marca.Descripcion = txtMarca.Text;
            marca.UrlImagen = tbUrlImgMarca.Text;


            //validamos que el nombre de la marca sea valido antes de guardar
            if (txtMarca.Text == "")
            {
                HelperUsuario.MensajePopUp(this, "El campo no puede estar vacío");
                return;
            }
            else
            {
                // Validar que solo se permitan números y letras
                Regex regex = new Regex("^[a-zA-Z0-9]+$");
                if (!regex.IsMatch(txtMarca.Text))
                {
                    HelperUsuario.MensajePopUp(this, "Solo se permiten ingresar números y letras");
                    return;
                }
                else
                {
                    //guardar marca
                    NegocioMarca.EditarMarca(marca);
                    HelperUsuario.MensajePopUp(this, "Marca modificada con exito!");

                }
            }
            // Mostrar el Label y ocultar el TextBox
            lblMarca.Visible = true;
            txtMarca.Visible = false;
            lblUrlMarca.Visible = false;
            tbUrlImgMarca.Visible = false;


            lblMarca.Text = txtMarca.Text;
            lblUrlMarca.Text = tbUrlImgMarca.Text;

            var btnEditarMarca = (Button)cardContainer.FindControl("btnEditarMarca");
            btnGuardarMarca.Visible = false;
            btnEditarMarca.Visible = true;
        }

        //TODO: Boton Eliminar Marca
        protected void btnEliminarMarca_Click(object sender, EventArgs e)
        {
            NegocioMarca = new NegocioMarca();
            Button btnBajaMarca = (Button)sender;
            RepeaterItem repeaterItem = (RepeaterItem)btnBajaMarca.NamingContainer;
            var cardContainer = (HtmlGenericControl)repeaterItem.FindControl("cardContainerMarca");
            var lblIdMarca = (Label)cardContainer.FindControl("lblIdMarca");
            NegocioMarca.borrarMarca(Convert.ToInt32(lblIdMarca.Text));
            Response.Redirect("Admin.aspx?id=3");
        }

        //TODOD: Boton Editar Marca
        protected void btnEditarMarca_Click(object sender, EventArgs e)
        {
            // Obtener el botón que se hizo clic
            Button btnEditarMarca = (Button)sender;

            // Obtener el contenedor del botón (div.card) utilizando NamingContainer
            RepeaterItem repeaterItem = (RepeaterItem)btnEditarMarca.NamingContainer;
            var cardContainer = (HtmlGenericControl)repeaterItem.FindControl("cardContainerMarca");

            // Obtener los controles Label y TextBox dentro del contenedor
            var lblMarca = (Label)cardContainer.FindControl("lblMarca");
            var txtMarca = (TextBox)cardContainer.FindControl("txtMarca");
            var lblUrlMarca = (Label)cardContainer.FindControl("lblUrlMarca");
            var tbUrlImgMarca = (TextBox)cardContainer.FindControl("tbUrlImgMarca");

            //asignar valor de los label a los textbox
            txtMarca.Text = lblMarca.Text;
            tbUrlImgMarca.Text = lblUrlMarca.Text;

            // Mostrar el TextBox y ocultar el Label
            lblMarca.Visible = false;
            txtMarca.Visible = true;
            lblUrlMarca.Visible = false;
            tbUrlImgMarca.Visible = true;

            // Ocultar el botón "Editar" y mostrar el botón "Guardar"
            var btnGuardarMarca = (Button)cardContainer.FindControl("btnGuardarMarca");
            btnGuardarMarca.Visible = true;
            btnEditarMarca.Visible = false;

        }



        //FIN LOGICA MARCAS
        #endregion MARCAS


        #region OTROS
        // BOTON DETALLE EN PANEL ESTADISITICAS
        protected void btnVerDetallePedido_Click(object sender, EventArgs e)
        {
            try
            {
                //cargamos variables
                int idMatch = Convert.ToInt32(((Button)sender).CommandArgument);
                Session.Add("idPedidoEditar", idMatch);
                NegocioPedido = new NegocioPedido();

                //buscamos el pedido
                PedidoList = NegocioPedido.ListarPedidos(idMatch, "IdPedido");
                dgvAdminPedido.DataSource = PedidoList;
                dgvAdminPedido.DataBind();

                //buscamos los articulos del pedido
                Session.Add("PedidoArticulosListaEdit", NegocioPedido.ListarPedido_articulo(idMatch));
                Pedido_articulos = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;

                dgvPedido_Articulos.DataSource = Pedido_articulos;
                dgvPedido_Articulos.DataBind();

                //Cargamos pedido en form
                int cantTotal = 0;
                Pedido_articulos.ForEach(x => cantTotal += x.Cantidad);
                PedidoList[0].CantidadTotal = cantTotal;

                CargarPedidoEnForm(PedidoList[0]);
                sectionAdminPedidoUnitario.Visible = true;

                //cargamos los id de los articulos que hay en BD
                ddlAgregarArticuloPedido_Articulos.DataSource = new NegocioArticulo().ListarArticulos();
                ddlAgregarArticuloPedido_Articulos.DataTextField = "Id";
                ddlAgregarArticuloPedido_Articulos.DataValueField = "Id";
                ddlAgregarArticuloPedido_Articulos.DataBind();

                //quitamos/mostramos
                dgvAdminPedido.Visible = true;
                dgvAdminPedidos.Visible = false;
                dgvPedido_Articulos.Visible = true;
                upadetePanelPedidosEditar.Visible = true;
                lblNuevoPedido.Visible = false;
                lblEditarPedido.Visible = true;
                btnEliminarPedido_Articulos.Visible = true;
                accordionPedidoArticulos.Visible = true;

                lblArticulosXidPedido_Articulos.Visible = false;
                ddlAgregarArticuloPedido_Articulos.Visible = false;
                btnAgregarArticuloPedido_ArticulosFinal.Visible = false;

                ddlAgregarArticuloPedido_Articulos.Visible = true;
                btnAgregarArticuloPedido_ArticulosFinal.Visible = true;
                lblArticulosXidPedido_Articulos.Visible = true;
                txtTotalEditarPedido.Enabled = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // FILTROS
        //Boton Mayor precio filtros
        protected void btnMayorMenorPrecioFiltroPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                divEstadisticas.Visible = false;
                NegocioPedido = new NegocioPedido();
                PedidoList = NegocioPedido.ListarPedidos();

                if (((Button)sender).CommandName == "MAYOR")
                    PedidoList = PedidoList.OrderByDescending(itm => itm.precioTotal).ToList();
                else if (((Button)sender).CommandName == "MENOR")
                    PedidoList = PedidoList.OrderBy(itm => itm.precioTotal).ToList();

                dgvAdminPedidos.DataSource = PedidoList;
                dgvAdminPedidos.DataBind();

            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Boton Estado Pedidos filtros
        protected void btnEstadosPedidosFiltros_Click(object sender, EventArgs e)
        {
            try
            {
                divEstadisticas.Visible = false;
                NegocioPedido = new NegocioPedido();
                PedidoList = NegocioPedido.ListarPedidos();

                string estado = ((Button)sender).CommandName;
                if(estado == "btnIniciado")
                    PedidoList = PedidoList.Where(itm => itm.Estado == "INICIADO").ToList();
                else if (estado == "btnTerminado")
                    PedidoList = PedidoList.Where(itm => itm.Estado == "TERMINADO").ToList();
                else if (estado == "btnCancelado")
                    PedidoList = PedidoList.Where(itm => itm.Estado == "CANCELADO").ToList();

                dgvAdminPedidos.DataSource = PedidoList;
                dgvAdminPedidos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Boton Filtros Personalizados Pedidos
        protected void btnFiltrosPersonalizados_Click(object sender, EventArgs e)
        {
            try
            {
                divEstadisticas.Visible = false;
                NegocioPedido = new NegocioPedido();
                PedidoList = NegocioPedido.ListarPedidos();
                
                int idPedidoUser = string.IsNullOrWhiteSpace(txtFiltroIdUser_Pedido.Text)? 0 : Convert.ToInt32(txtFiltroIdUser_Pedido.Text);
                int idPedido = string.IsNullOrWhiteSpace(txtFiltroIdPedido_Pedido.Text)? 0 : Convert.ToInt32(txtFiltroIdPedido_Pedido.Text);
                string nombreUser = string.IsNullOrWhiteSpace(txtFiltroNombreUsuario_Pedido.Text)? string.Empty : txtFiltroNombreUsuario_Pedido.Text;
                DateTime fechaDesde = string.IsNullOrWhiteSpace(txtFiltroFecha.Text)? DateTime.MinValue : Convert.ToDateTime(txtFiltroFecha.Text);

                if(idPedidoUser != 0)
                    PedidoList.RemoveAll(itm => itm.IdUsuario != idPedidoUser);
                if(idPedido != 0)
                    PedidoList.RemoveAll(itm => itm.IdPedido != idPedido);
                if (nombreUser != string.Empty)
                    PedidoList.RemoveAll(itm => itm.Usuario != nombreUser);
                if(fechaDesde != DateTime.MinValue)
                    PedidoList.RemoveAll(itm => itm.fecha.Date != fechaDesde.Date);

                //rendereamos la lista filtrada
                dgvAdminPedidos.DataSource = PedidoList;
                dgvAdminPedidos.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Boton Limpiar Filtros Pedidos
        protected void btnLimpiarFiltrosPedidos_Click(object sender, EventArgs e)
        {
            try
            {
                CargarPedidos();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // Boton Filtrar Estado Usuarios
        protected void btnFiltrarEstadoUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioUsuario = new NegocioUsuario();
                usuarioList = NegocioUsuario.ListarUsuarios();

                string estado = ((Button)sender).CommandName;
                if (estado == "ACTIVO")
                    usuarioList = usuarioList.Where(itm => itm.Activo).ToList();
                else if (estado == "INACTIVO")
                    usuarioList = usuarioList.Where(itm => !itm.Activo).ToList();

                dgvAdminUsuario.DataSource = usuarioList;
                dgvAdminUsuario.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Boton Limpiar Filtros Usuarios
        protected void btnLimpiarFiltrosUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                CargarUsuario();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //Boton Filtrar Usuarios
        protected void btnFiltrarUsuarios_Click(object sender, EventArgs e)
        {
            try
            {
                NegocioUsuario = new NegocioUsuario();
                usuarioList = NegocioUsuario.ListarUsuarios();

                int idUsuario = string.IsNullOrWhiteSpace(txtIdFiltro_Usuario.Text) ? 0 : Convert.ToInt32(txtIdFiltro_Usuario.Text);
                int dni = string.IsNullOrWhiteSpace(txtDNIFiltro_Usuario.Text) ? 0 : Convert.ToInt32(txtDNIFiltro_Usuario.Text);
                string nombre = string.IsNullOrWhiteSpace(txtNombreFiltro_Usuario.Text) ? string.Empty : txtNombreFiltro_Usuario.Text;
                string apellido = string.IsNullOrWhiteSpace(txtApellidoFiltro_Usuario.Text) ? string.Empty : txtApellidoFiltro_Usuario.Text;

                if(idUsuario != 0)
                    usuarioList.RemoveAll(itm => itm.Id != idUsuario);
                if(dni != 0)
                    usuarioList.RemoveAll(itm => itm.Dni != dni);
                if (nombre != string.Empty)
                    usuarioList.RemoveAll(itm => itm.Nombre != nombre);
                if(apellido != string.Empty)
                    usuarioList.RemoveAll(itm => itm.Apellido != apellido);

                dgvAdminUsuario.DataSource = usuarioList;
                dgvAdminUsuario.DataBind();
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }
        #endregion OTROS

    }//END CLASS
}//END