using Dominio;
using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
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

        // LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            sectionModificarUsuario.Visible = false;
            SectionCrearArt.Visible = false;
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
                    // Tratar de no usar el query string para mostrar info
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
                                break;
                            case 8:
                                break;
                            case 9:
                                break;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Session.Add("error", ex);
                Response.Redirect("Error.aspx", false);
            }
        }


        //      ############### METODOS ###############

        // METODOS USUARIO
        // TODO: Cargar Usuario en Admin
        private void CargarUsuario()
        {
            NegocioUsuario = new NegocioUsuario();
            usuarioList = NegocioUsuario.ListarUsuarios();
            dgvAdminUsuario.DataSource = usuarioList;
            dgvAdminUsuario.DataBind();
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


        //      ############### EVENTOS ###############
        protected void ibtEliminar_Click(object sender, ImageClickEventArgs e)
        {

        } //sin hacer todavia

        protected void ibtEditar_Click(object sender, ImageClickEventArgs e)
        {

        } //sin hacer todavia

        protected void ibtBaja_Click(object sender, ImageClickEventArgs e)
        {

        } //sin hacer todavia

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
        // TODO: ??
        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            userImg.ImageUrl = txtUrl.Text;
        }


        // BOTONES LOGICA PEDIDOS
        // TODO: BOTON Elimnar Pedido en Grid
        protected void ibtEliminarPedido_Click(object sender, ImageClickEventArgs e)
        {

        } //sin hacer todavia

        // TODO: BOTON Editar/Detalle Pedido en Grid
        protected void ibtEditarPedido_Click(object sender, ImageClickEventArgs e)
        {
            int idMatch = Convert.ToInt32(((ImageButton)sender).CommandArgument);
            NegocioPedido = new NegocioPedido();
            PedidoList = NegocioPedido.ListarPedidos(idMatch, "IdPedido");
            dgvAdminPedido.DataSource = PedidoList;
            dgvAdminPedido.DataBind();

            Pedido_articulos = NegocioPedido.ListarPedido_articulo(idMatch);
            dgvPedido_Articulos.DataSource = Pedido_articulos;
            dgvPedido_Articulos.DataBind();
            dgvAdminPedidos.Visible = false;
            dgvPedido_Articulos.Visible = true;
            sectionEditarPedidos.Visible = true; 
        }

        // TODO: BOTON Dar Baja Pedido en Grid
        protected void ibtBajaPedido_Click(object sender, ImageClickEventArgs e)
        {

        } //sin hacer todavia

        // TODO: BOTONES PEDIDOS MENU
        protected void btnPedidosMenu_Click(object sender, EventArgs e)
        {
            try
            {
                string tipoBoton = (sender as LinkButton).CommandName;
                switch (tipoBoton)
                {
                    case "btnPedidosTodos":
                        CargarPedidos();
                        break;
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
        //FIN BOTONES LOGICA PEDIDOS


        // BOTONES LOGICA USUARIO
        // TODO: BOTON EDITAR USUARIO EN GRID
        protected void ibtEditarUsuario_Click(object sender, ImageClickEventArgs e)
        {
            sectionModificarUsuario.Visible = true;
            dgvAdminUsuario.Visible = false;
            CargarUsuarioParaEditar(int.Parse((sender as ImageButton).CommandArgument));
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
            //Response.Redirect("Admin.aspx?id=6"); //obs: no hace falta renderiar todo y pasar por el load, solo tenemos que hacer visible y que funcione ajax en los uptadte panel
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
            sectionModificarUsuario.Visible = true;
        }

        // TODO: Link Volver a Lista Aneterior (Depende del CommandName del btn)
        protected void lnkVolverListaUsuarios_Click(object sender, EventArgs e)
        {
            string filtro = ((LinkButton)sender).CommandName;
            if (filtro == "btnVolverListaPedidos")
            {
                dgvAdminPedidos.Visible = true;
                sectionEditarPedidos.Visible = false;
                dgvAdminPedido.Visible = false;
            }
            else if (filtro == "btnVolverListaUsuarios")
            {
                dgvAdminUsuario.Visible = true;
                sectionModificarUsuario.Visible = false;
            }
        }
        // FIN BOTONES LOGICA USUARIO

        //TODO: LOGICA ARTICULOS
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
            Response.Redirect("Admin.aspx?id=5");
        }

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
            }
        }
        //FIN LOGICA ARTÍCULOS


        //LOGICA CATEGORIAS
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
            var lblIdCate = (Label)cardContainer.FindControl("lblIdCate");
            var txtIdCate = (TextBox)cardContainer.FindControl("txtIdCate");
            var lblUrl = (Label)cardContainer.FindControl("lblUrl");
            var tbUrlImg = (TextBox)cardContainer.FindControl("tbUrlImg");
            var lblCambiarImg = (Label)cardContainer.FindControl("lblCambiarImg");

            // Mostrar el TextBox y ocultar el Label
            lblCategoria.Visible = false;
            txtCategoria.Visible = true;
            lblIdCate.Visible = false;
            txtIdCate.Visible = true;
            lblUrl.Visible = false;
            tbUrlImg.Visible = true;
            lblCambiarImg.Visible = true;

            // Establecer el texto del TextBox con el valor actual del Label
            txtCategoria.Text = lblCategoria.Text;
            txtIdCate.Text = lblIdCate.Text;
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
        //FIN LOGICA CATEGORIAS
    }
}