using Dominio;
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

        //METODOS
        private void CargarUsuario()
        {
            usuarioList = new List<Usuario>();
            NegocioUsuario = new NegocioUsuario();
            usuarioList = NegocioUsuario.ListarUsuarios();
            dgvAdminUsuario.DataSource = usuarioList;
            dgvAdminUsuario.DataBind();
        }
        private void CargarUsuarioParaEditar(int idMatch)
        { 
            usuario= new Usuario();
            NegocioUsuario = new NegocioUsuario();
            usuario = (Usuario)NegocioUsuario.BuscarUsuarioPorId(idMatch);
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
        private void CargarArticulos()
        {
            articuloList = new List<Articulo>();
            NegocioArticulo = new NegocioArticulo();
            articuloList = NegocioArticulo.ListarArticulos();
            dgvAdmin.DataSource = articuloList;
            dgvAdmin.DataBind();
        }
        private void CargarCategorias()
        {
            categoriaList = new List<Categoria>();
            NegocioCategoria = new NegocioCategoria();
            categoriaList = NegocioCategoria.ListarCategorias();
            dgvAdminCate.DataSource = categoriaList;
            dgvAdminCate.DataBind();
        }
        private void CargarMarcas()
        {
            MarcaList = new List<Marca>();
            NegocioMarca = new NegocioMarca();
            MarcaList = NegocioMarca.ListarMarcas();
            dgvAdminMarca.DataSource = MarcaList;
            dgvAdminMarca.DataBind();
        }
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

        //EVENTOS (obs: mejor agregar los eventos cuando se estan por ingresar su logica, sino despues se puede complicar buscar en front)
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

        protected void ibtEditarUsuario_Click(object sender, ImageClickEventArgs e)
        {
            sectionModificarUsuario.Visible = true;
            dgvAdminUsuario.Visible = false;
            CargarUsuarioParaEditar(int.Parse((sender as ImageButton).CommandArgument));
        }

        //
        protected void txtUrl_TextChanged(object sender, EventArgs e)
        {
            userImg.ImageUrl = txtUrl.Text;
        }

        // BOTON ACTUALIZAR USUARIO
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
            NegocioUsuario.ActualizarUsuario(usuario);
            CargarUsuario();
            sectionModificarUsuario.Visible = false;
            dgvAdminUsuario.Visible = true;
        }
    }
}