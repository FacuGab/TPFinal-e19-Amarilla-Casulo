using Dominio;
using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.Eventing.Reader;
using System.Globalization;
using System.Linq;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Web;
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
        private int numPedido = 0;

        // LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            sectionModificarUsuario.Visible = false;
            SectionCrearArt.Visible = false;
            //btnAgregarArticuloPedido_Articulos.Visible = false;
            //ddlAgregarArticuloPedido_Articulos.Visible = false;
            try
            {
                // Ver el tema de usar los Redirect constantes para usar los param de url si es posible, es recargar constantemente todo una y otra vez por cada vuelta.
                // Validamos que el user este Logeado y ademas sea Admin, nivel de usuario = 'A'.
                // Funciona, pero no se si tenes un user con nivel A creado y aparte redirecciona muy rapido. Ver si crear una pagina de loggin de vista simple para el "uso de empleados" para redireccionar.
                // Usuario admin = Session["usuarioActual"] as Usuario;
                // if(!HelperUsuario.IsAdmin(admin))
                // {
                //     HelperUsuario.MensajePopUp(this, "No tiene las credenciales para entrar o No te encuentras logeado");
                //     return;
                //     //Response.Redirect("Default.aspx", false);
                // }
                if (!IsPostBack)
                {    
                    //Obs: Tratar de no usar el query string para mostrar info, trae problemas de postback
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
                                break;
                            case 8:
                                cargarNuevaCategoria();
                                break;
                            case 9:
                                cargarNuevaMarca();
                                break;
                        }
                    }

                    //Validamos que el user este Logeado y ademas sea Admin, nivel de usuario = 'A'.
                    //usuario = Session["usuarioActual"] as Usuario;
                    //if(HelperUsuario.IsLogged(usuario) && HelperUsuario.IsAdmin(usuario))
                    //    HelperUsuario.MensajePopUp(this, "Bienvenido " + usuario.Nombre + " " + usuario.Apellido);
                    //else
                    //    HelperUsuario.MensajePopUp(this, "No tiene las credenciales para entrar o No te encuentras logeado");
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        //############################## METODOS ##############################
        // METODOS USUARIO
        // TODO: Cargar Usuario en Admin
        private void CargarUsuario()
        {
            NegocioUsuario = new NegocioUsuario();
            usuarioList = NegocioUsuario.ListarUsuarios();
            dgvAdminUsuario.DataSource = usuarioList;
            dgvAdminUsuario.DataBind();
            btnAgregarArticuloPedido_Articulos.Visible = false;
            ddlAgregarArticuloPedido_Articulos.Visible = false;
        }

        // TODO: Cargar Usuario para Editar en Admin
        private void CargarUsuarioParaEditar(int idMatch)
        {
            // Manu, ojo con los new a obj que nunca se van a usar, instancias objetos que ya son traidos por el metodo de Negocio en este caso; se puede perder o pisar data.
            // Aca particularmente solo asigna memoria a un obj, que nunca va a usar al cambiar el puntero, si hacemos new Usuario() y despues asignamos a otro obj Usuario con el metodo de negocio.
            //usuario = new Usuario();
            NegocioUsuario = new NegocioUsuario();
            usuario = NegocioUsuario.BuscarUsuarioPorId(idMatch);
            txtNombre.Text = usuario.Nombre;
            txtApellido.Text = usuario.Apellido;
            txtEmail.Text = usuario.Mail;
            txtClave.Text = usuario.Clave;
            txtDni.Text = usuario.Dni.ToString();
            txtDomicilio.Text = usuario.Direccion;
            txtUrl.Text = usuario.UrlImgUsuario;
            txtTipoUsuario.Text = usuario.Nivel.ToString();
            txtId.Text = usuario.Id.ToString();
        }


        // METDOS ARTICULOS
        // TODO: Cargar Articulos en Admin
        private void CargarArticulos()
        {
            NegocioArticulo = new NegocioArticulo();
            articuloList = NegocioArticulo.ListarArticulos();
            dgvAdmin.DataSource = articuloList;
            dgvAdmin.DataBind();
        }


        // METDOS CATEGORIA Y MARCAS
        // TODO: Cargar Categorias en Admin
        private void CargarCategorias()
        {
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
            NegocioMarca = new NegocioMarca();
            MarcaList = NegocioMarca.ListarMarcas();
            dgvAdminMarca.DataSource = MarcaList;
            dgvAdminMarca.DataBind();
            titleMarcas.Visible = true;
            sectionAgregarMarca.Visible=true;
        }


        // METDOS PEDIDOS
        // TODO: Cargar Pedidos en Admin
        private void CargarPedidos()
        {

            NegocioPedido = new NegocioPedido();
            PedidoList = NegocioPedido.ListarPedidos();
            dgvAdminPedidos.DataSource = PedidoList;
            dgvAdminPedidos.DataBind();
            dgvAdminPedidos.Visible = true;
            dgvAdminUsuario.Visible = false;
            
        }

        // TODO: Cargar Pedidos en Admin con Filtro
        private void CargarPedidos(string filtro)
        {
            NegocioPedido = new NegocioPedido();
            PedidoList = NegocioPedido.ListarPedidos(filtro);
            dgvAdminPedidos.DataSource = PedidoList;
            dgvAdminPedidos.DataBind();
            dgvAdminPedidos.Visible = true;
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
        }

        // TODO: Cargar Pedido del Form en Objeto
        private void CargarPedidoDelForm(Pedido pedido)
        {
            if (pedido == null) return;
            pedido.IdPedido = int.Parse(txtIdPedidoEditar.Text);
            pedido.IdUsuario = int.Parse(txtIdUsuarioEditarPedido.Text);
            pedido.Usuario = txtNombreUsuarioEditarPedido.Text;
            pedido.Estado = txtEstadoEditarPedido.Text;
            pedido.DireccionEntrega = txtDirEditarPedido.Text;
            pedido.fecha = DateTime.Parse(txtFechaEditarPedido.Text);
            pedido.Descuento = int.Parse(txtDescuentoEditarPedido.Text);
            pedido.precioTotal = decimal.Parse(txtTotalEditarPedido.Text, NumberStyles.Currency);
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


        //############################## EVENTOS ##############################
        // Eventos de la pagina:
        // TODO: Boton Sing Out en MENU no ABM  (TEST Para cerrar la sesion)
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
        // TODO: Evento User ImgUrl cambio??
        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            userImg.ImageUrl = txtUrl.Text;
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

        // TODO: BOTON ir Editar/Detalle Pedido en Grid
        protected void ibtEditarPedido_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int idMatch = Convert.ToInt32(((ImageButton)sender).CommandArgument);
                Session.Add("idPedidoEditar", idMatch);
                NegocioPedido = new NegocioPedido();

                PedidoList = NegocioPedido.ListarPedidos(idMatch, "IdPedido");
                dgvAdminPedido.DataSource = PedidoList;
                dgvAdminPedido.DataBind();

                Session.Add("PedidoArticulosListaEdit", NegocioPedido.ListarPedido_articulo(idMatch));
                Pedido_articulos = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;

                dgvPedido_Articulos.DataSource = Pedido_articulos;
                dgvPedido_Articulos.DataBind();

                CargarPedidoEnForm(PedidoList[0]);
                sectionAdminPedidoUnitario.Visible = true;
                btnAgregarArticuloPedido_Articulos.Visible = true;

                dgvAdminPedido.Visible = true;
                dgvAdminPedidos.Visible = false;
                dgvPedido_Articulos.Visible = true;
                upadetePanelPedidosEditar.Visible = true;
                btnAgregarArticuloPedido_Articulos.Visible = true;
                lblNuevoPedido.Visible = false;
                lblEditarPedido.Visible = true;
                btnEliminarPedido_Articulos.Visible = true;

                lblArticulosXidPedido_Articulos.Visible = false;
                ddlAgregarArticuloPedido_Articulos.Visible = false;
                btnAgregarArticuloPedido_ArticulosFinal.Visible = false;
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }

        // TODO: BOTONES PEDIDOS MENU (sin uso casi)
        protected void btnPedidosMenu_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoBoton = (sender as LinkButton).CommandName;
                switch (tipoBoton)
                {
                    case "btnPedidosTodos":
                        CargarPedidos();
                        break; // no usos despues de aca, pero lo dejo por si las dudas (filtra por tipo de estado la listra principal)
                    case "btnPedidosPendientes":
                        CargarPedidos("Pendiete");
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
                btnAgregarArticuloPedido_Articulos.Visible = false;

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
                CargarPedidoDelForm(pedido);
                
                // editamos pedido y buscamos lista Pedido_Articulos en Session
                int res = NegocioPedido.EditarPedido(pedido);
                List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;

                // Eliminamos Pedidos_Articulos en DB anterior
                for (int i = 0; i < listaPedido_Articulo.Count; i++)
                {
                    NegocioPedido.EliminarPedido_articulo(pedido.IdPedido);
                }

                // Agregamos los articulos nuevos Pedido_Articulo en DB segun el estado del pedido y la cantidad en lista Pedido_Articulos
                NegocioPedido.AgregarPedido_articulo(listaPedido_Articulo);
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
                
                listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad += 1;
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

            listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad -= 1;
            if (listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad == 0)
                listaPedido_Articulo.RemoveAll(itm => itm.Id == idArticulo);
            dgvPedido_Articulos.DataSource = listaPedido_Articulo;
            dgvPedido_Articulos.DataBind();
        }

        // TODO: Boton Eliminar Articulo en lista Pedido_Articulo
        protected void btnEliminarArtPedido_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                int idArticulo = int.Parse(((ImageButton)sender).CommandArgument);
                // Eliminamos el articulo de la lista Pedido_Articulo
                List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;
                listaPedido_Articulo.RemoveAll(itm => itm.Id == idArticulo);
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

        // TODO: Boton Agregar Articulo en Lista Pedidos_Articulos
        protected void btnAgregarArticuloPedido_Articulos_Click(object sender, EventArgs e)
        {
            ddlAgregarArticuloPedido_Articulos.DataSource = new NegocioArticulo().ListarArticulos();
            ddlAgregarArticuloPedido_Articulos.DataTextField = "Id";
            ddlAgregarArticuloPedido_Articulos.DataValueField = "Id";
            ddlAgregarArticuloPedido_Articulos.DataBind();

            ddlAgregarArticuloPedido_Articulos.Visible = true;
            btnAgregarArticuloPedido_ArticulosFinal.Visible = true;
            lblArticulosXidPedido_Articulos.Visible = true;
        }

        //TODO: Boton Agregar Articulo Nuevo a lista Pedido_Articulos
        protected void btnAgregarArticuloPedido_ArticulosFinal_Click(object sender, EventArgs e)
        {
            //Cargamos variables e instanciamos objetos
            int idPedido = (int)Session["idPedidoEditar"];
            int idArticulo = int.Parse(ddlAgregarArticuloPedido_Articulos.SelectedValue);
            List<CarritoItem> listaPedido_Articulo = Session["PedidoArticulosListaEdit"] as List<CarritoItem>;

            if(listaPedido_Articulo == null)
                listaPedido_Articulo = new List<CarritoItem>();

            //Comprobamos si el articulo a agregar ya esta en la lista Pedido_Articulo
            if (listaPedido_Articulo.Find(itm => itm.Id == idArticulo) != null)
            {
                listaPedido_Articulo.Find(itm => itm.Id == idArticulo).Cantidad += 1;
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
                IdPedido = idPedido,
                precio = newArticulo.precio,
                ImagenUrl = newArticulo.ImagenUrl,
                Marca = newArticulo.Marca.Descripcion,
                Stock = newArticulo.Stock,
            };

            listaPedido_Articulo.Add(newItem);
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
                    HelperUsuario.MensajePopUp(this, "Pedido eliminado");
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
                upadetePanelPedidosEditar.Visible = true;
                dgvAdminPedidos.Visible = false;
                lblNuevoPedido.Visible = true;
                lblEditarPedido.Visible = false;
                btnEliminarPedido_Articulos.Visible = false;
                btnAgregarArticuloPedido_Articulos.Visible = true;
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
            if(tipo == "Cancelar")
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
        }

        // TODO: BOTON ACTUALIZAR/CREAR USUARIO
        protected void btnGuardarUsuario_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            // Aca habria que llamar helper para validar imputs

            // cargamos los datos
            usuario.Id = int.Parse(txtId.Text);
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Mail = txtEmail.Text;
            usuario.Clave = txtClave.Text;
            usuario.Dni = int.Parse(txtDni.Text);
            usuario.Direccion = txtDomicilio.Text;
            usuario.UrlImgUsuario = txtUrl.Text;
            usuario.Nivel = txtTipoUsuario.Text;
            usuario.Activo = true;

            NegocioUsuario = new NegocioUsuario();
            int res = 0;
            // si es modo agregar
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
            txtUrl.Text = string.Empty;
            txtDni.Text = string.Empty;
            txtDomicilio.Text = string.Empty;
            txtTipoUsuario.Text = string.Empty;

            dgvAdminUsuario.Visible = false;
            btnAltaUsuario.Visible = false;
            btnBajaUsuario.Visible = false;
            btnEliminarUsuario.Visible = false;
            btnAgregarArticuloPedido_Articulos.Visible = false;
            sectionModificarUsuario.Visible = true;
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
            marca = new Marca();
            marca.Id = Convert.ToInt32(ddlMarca.SelectedValue);
            marca.ObtenerMarca(marca.Id);
            categoria = new Categoria();
            categoria.Id = Convert.ToInt32(ddlCategoria.SelectedValue);
            categoria.ObtenerCategoria(categoria.Id);

            NegocioArticulo = new NegocioArticulo();
            articulo = new Articulo();
            articulo.Id = Convert.ToInt32(tbIdArt.Text);
            articulo.Nombre = tbNombreArt.Text;
            articulo.Descripcion = tbDescripArt.Text;
            articulo.ImagenUrl = tbImgArt.Text;
            articulo.precio = Convert.ToDecimal(tbPrecioArt.Text);
            articulo.Marca = marca;
            articulo.Categoria = categoria;
            articulo.Estado = true;
            articulo.Stock = int.Parse(tbStockArt.Text);
            NegocioArticulo.crearArticulo(articulo);
            //CargarArticulos();
            Response.Redirect("Admin.aspx?id=5");
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
            if(dgvAdmin.DataSource != null)
                dgvAdmin.Visible = true;
            else
            {
                NegocioArticulo = new NegocioArticulo();
                dgvAdmin.DataSource = NegocioArticulo.ListarArticulos();
                dgvAdmin.DataBind();
                dgvAdmin.Visible = true;
                dgvAdminArtUnitario.Visible = false;
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

            // Obtener los controles Label y TextBox dentro del contenedor
            var lblCategoria = (Label)cardContainer.FindControl("lblCategoria");
            var txtCategoria = (TextBox)cardContainer.FindControl("txtCategoria");
            var lblIdCate = (Label)cardContainer.FindControl("lblIdCate");
            var txtIdCate = (TextBox)cardContainer.FindControl("txtIdCate");
            var lblUrl = (Label)cardContainer.FindControl("lblUrl");
            var tbUrlImg = (TextBox)cardContainer.FindControl("tbUrlImg");
            var lblCambiarImg = (Label)cardContainer.FindControl("lblCambiarImg");

            // Actualizar el texto del Label con el valor ingresado en el TextBox
            lblCategoria.Text = txtCategoria.Text;
            lblIdCate.Text = txtIdCate.Text;
            lblUrl.Text = tbUrlImg.Text;

            //asigno valores para guardarlos en bd
            categoria.Id = Convert.ToInt32(lblIdCate.Text);
            categoria.Descripcion = lblCategoria.Text;
            categoria.UrlImagen = lblUrl.Text;

            //guardar categoria
            NegocioCategoria.editarCategoria(categoria);

            // Mostrar el Label y ocultar el TextBox
            lblCategoria.Visible = true;
            txtCategoria.Visible = false;
            lblIdCate.Visible = true;
            txtIdCate.Visible = false;
            lblUrl.Visible = false;
            tbUrlImg.Visible = false;
            lblCambiarImg.Visible = false;

            // Ocultar el botón "Guardar" y mostrar el botón "Editar"
            var btnEditarCate = (Button)cardContainer.FindControl("btnEditarCate");
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
            Image imgCate = (Image)repeaterItem.FindControl("imgCate");

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
            NegocioCategoria.agregarCategoria(categoria);
            Response.Redirect("Admin.aspx?id=4");
        }

        //TODO: Evento cambio de ImgUrl Categoria
        protected void tbUrlImgCate_TextChanged(object sender, EventArgs e)
        {
            imgNuevaCate.ImageUrl= tbUrlImgCate.Text;
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
            Image imgMarca = (Image)repeaterItem.FindControl("imgMarca");
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

            if(HelperUsuario.ExistMarca(marca.Id))
            {
                HelperUsuario.MensajePopUp(this,"Ya existe una marca con ese ID");
            }
            else
            {
                NegocioMarca.AgregarMarca(marca);
                HelperUsuario.MensajePopUp(this, "Nueva marca registrada con exito!");
                Session["MensajeExito"] = "Nueva marca registrada con éxito!";
                Response.Redirect("Admin.aspx?id=3");

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
            NegocioMarca.EditarMarca(marca);

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

    }//END CLASS
}//END