using Dominio;
using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
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

        // LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            sectionModificarUsuario.Visible = false;
            try
            {
                // Ver el tema de usar los Redirect constantes para usar los param de url, es recargar constantemente todo una y otra vez por cada vuelta.

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

        // ############### METODOS ###############
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
            NegocioCategoria = new NegocioCategoria();
            categoriaList = NegocioCategoria.ListarCategorias();
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

        // ############### EVENTOS ###############
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
            dgvAdminPedidos.DataSource = PedidoList;
            dgvAdminPedidos.DataBind();

            Pedido_articulos = NegocioPedido.ListarPedido_articulo(idMatch);
            dgvPedido_Articulos.DataSource = Pedido_articulos;
            dgvPedido_Articulos.DataBind();
            dgvPedido_Articulos.Visible = true;
        }

        // TODO: BOTON Dar Baja Pedido en Grid
        protected void ibtBajaPedido_Click(object sender, ImageClickEventArgs e)
        {

        } //sin hacer todavia
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
            //actualizar datos del usuario
            usuario = new Usuario();
            NegocioUsuario = new NegocioUsuario();
            usuario.Id = int.Parse(txtId.Text);
            usuario.Nombre = txtNombre.Text;
            usuario.Apellido = txtApellido.Text;
            usuario.Mail = txtEmail.Text;
            usuario.Clave = txtClave.Text;
            usuario.Dni = int.Parse(txtDni.Text);
            usuario.Direccion = txtDomicilio.Text;
            usuario.UrlImgUsuario = txtUrl.Text;
            usuario.Nivel = txtTipoUsuario.Text;
            NegocioUsuario.EditarUsuario(usuario);
            CargarUsuario();
            dgvAdminUsuario.Visible = true;
            //Response.Redirect("Admin.aspx?id=6"); //obs: no hace falta renderiar todo y pasar por el load, solo tenemos que hacer visible y que funcione ajax en los uptadte panel
        }

        // TODO: BOTON DAR DE BAJA USUARIO (Logica)
        protected void btnBajaUsuario_Click(object sender, EventArgs e)
        {
            usuario = new Usuario();
            NegocioUsuario = new NegocioUsuario();
            usuario.Id = int.Parse(txtId.Text);
            NegocioUsuario.DarBajaUsuario(usuario.Id);
            CargarUsuario();
            Response.Redirect("Admin.aspx?id=6");
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
            usuario = new Usuario();
            NegocioUsuario = new NegocioUsuario();
            usuario.Id = int.Parse(txtId.Text);
            NegocioUsuario.DarAltaUsuario(usuario.Id);
            CargarUsuario();
            Response.Redirect("Admin.aspx?id=6");
        }

        // TODO: AGREGAR NUEVO USUARIO (TEST Sin usar vista registro)
        protected void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {
            btnGuardarUsuario.Text = "Agregar Usuario";
            sectionModificarUsuario.Visible = true;
        }

        // TODO: Link Volver a Lista Usuario (TEST para volver a ver la lista cuando querramos)
        protected void lnkVolverListaUsuarios_Click(object sender, EventArgs e)
        {
            dgvAdminUsuario.Visible = true;
        }
        // FIN BOTONES LOGICA USUARIO
    }
}