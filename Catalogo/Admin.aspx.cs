using Dominio;
using Helper;
using Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
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

        //LOAD
        protected void Page_Load(object sender, EventArgs e)
        {
            sectionModificarUsuario.Visible = false;
            try
            {
                // Validamos que el user este Logeado y ademas Sea Admin, osea su nivel tiene que ser 'A'. Ver el tema de usar los Redirect constantes para usar por url, es recargar constantemente todo una y otra vez por cada vuelta
                //Usuario admin = Session["usuarioActual"] as Usuario;
                //if(!HelperUsuario.IsAdmin(admin))
                //{
                //    HelperUsuario.MensajePopUp(this, "No tiene las credenciales para entrar o No te encuentras logeado");
                //    return;
                //    //Response.Redirect("Default.aspx", false);
                //}

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

        //METODOS
        // TODO: Cargar Usuario en Admin
        private void CargarUsuario()
        {
            usuarioList = new List<Usuario>();
            NegocioUsuario = new NegocioUsuario();
            usuarioList = NegocioUsuario.ListarUsuarios();
            dgvAdminUsuario.DataSource = usuarioList;
            dgvAdminUsuario.DataBind();
        }

        // TODO: Cargar Usuario para Editar en Admin
        private void CargarUsuarioParaEditar(int idMatch)
        {
            // Manu, ojo con los new a obj que nunca se van a usar, instancias objetos que ya son traidos por el metodo de Negocio en este caso, se puede perder o pisar data.
            // En este caso particular solo asigna memoria a un obj que nunca va a usar al cambiar el puntero si hacemos new Usuario() y despues asignamos a otro obj Usuario,
            // el primer obj en teoria sigue con memoria asignada que nunca se va usar.
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

        // TODO: Cargar Articulos en Admin
        private void CargarArticulos()
        {
            articuloList = new List<Articulo>();
            NegocioArticulo = new NegocioArticulo();
            articuloList = NegocioArticulo.ListarArticulos();
            dgvAdmin.DataSource = articuloList;
            dgvAdmin.DataBind();
        }

        // TODO: Cargar Categorias en Admin
        private void CargarCategorias()
        {
            categoriaList = new List<Categoria>();
            NegocioCategoria = new NegocioCategoria();
            categoriaList = NegocioCategoria.ListarCategorias();
            dgvAdminCate.DataSource = categoriaList;
            dgvAdminCate.DataBind();
        }

        // TODO: Cargar Marcas en Admin
        private void CargarMarcas()
        {
            MarcaList = new List<Marca>();
            NegocioMarca = new NegocioMarca();
            MarcaList = NegocioMarca.ListarMarcas();
            dgvAdminMarca.DataSource = MarcaList;
            dgvAdminMarca.DataBind();
        }

        // TODO: Cargar Pedidos en Admin
        private void CargarPedidos()
        {
            PedidoList = new List<Pedido>();
            NegocioPedido = new NegocioPedido();
            PedidoList = NegocioPedido.ListarPedidos();
            dgvAdminPedidos.DataSource = PedidoList;
            dgvAdminPedidos.DataBind();

            var pedido_articulo = NegocioPedido.ListarPerdido_articulos(); //se puede buscar por ID de Pedido pasando por parametro
            dgvPedido_Articulos.DataSource = pedido_articulo;
            dgvPedido_Articulos.DataBind();
        }

        // TODO: Cargar Pedido_Articulos en Admin
        private void CargarPedido_Articulos() //ver si usar
        {
            try
            {
                Pedido_articulos = new List<CarritoItem>();
                NegocioPedido = new NegocioPedido();
                var pedido_articulo = NegocioPedido.ListarPerdido_articulos();
                dgvPedido_Articulos.DataSource = pedido_articulo;
                dgvPedido_Articulos.DataBind();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // EVENTOS (obs: mejor agregar los eventos cuando se estan por ingresar su logica, sino despues se puede complicar buscar en front)
        protected void ibtEliminar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtEditar_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtBaja_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtEliminarPedido_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtEditarPedido_Click(object sender, ImageClickEventArgs e)
        {

        }

        protected void ibtBajaPedido_Click(object sender, ImageClickEventArgs e)
        {

        }


        // #### BOTONES LOGICA USUARIO ####
        // TODO: BOTON EDITAR USUARIO
        protected void ibtEditarUsuario_Click(object sender, ImageClickEventArgs e)
        {
            sectionModificarUsuario.Visible = true;
            dgvAdminUsuario.Visible = false;
            CargarUsuarioParaEditar(int.Parse((sender as ImageButton).CommandArgument));
        }

        // TODO: ??
        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            userImg.ImageUrl = txtUrl.Text;
        }

        // TODO: BOTON ACTUALIZAR USUARIO
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
            //Response.Redirect("Admin.aspx?id=6");
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

        // TODO: AGREGAR NUEVO USUARIO (Sin usar vista registro)
        protected void btnAgregarNuevoUsuario_Click(object sender, EventArgs e)
        {

        }
    }
}