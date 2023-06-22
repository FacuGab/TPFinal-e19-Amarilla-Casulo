using Data;
using Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Negocio
{
    public class NegocioPedido
    {
        DataAccess datos = null;
        List<Pedido> pedidos = null;
        Pedido pedido;
        public List<Pedido> PedidoItems { get; set; }
        public NegocioPedido()
        {
            PedidoItems = new List<Pedido>();
        }

        //TODO: Listar Pedidos
        public List<Pedido> ListarPedidos()
        {
            datos = new DataAccess();
            pedidos = new List<Pedido>();
      
            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                datos.SetQuery("SELECT P.IdPedido as 'ID_Pedido',U.Id as 'ID_usuario',A.Id as 'ID_Articulo', U.Nombre + ' '+ U.Apellido as 'Usuario', A.Nombre as 'Nombre_Articulo', P.Cantidad as 'Cantidad_Solicitada', P.Fecha as 'Fecha', P.Estado as 'Estado', P.DireccionEntrega as 'Direccion', P.Descuento as 'Descuento', P.PrecioTotal as 'Precio_Total_Articulo' FROM PEDIDOS P JOIN USUARIOS U ON P.IdUsuarios = U.Id JOIN ARTICULOS A ON P.IdArticulos = A.Id", "query");
                datos.ReadQuery();
                var aux = datos.Lector;
                while (datos.Lector.Read())
                {
                    pedido = new Pedido();
                    pedido.IdPedido = (int)aux["ID_Pedido"];
                    pedido.IdUsuario = (int)aux["ID_usuario"];
                    pedido.IdArticulo = (int)aux["ID_Articulo"];
                    pedido.NombreArt = aux["Nombre_Articulo"].ToString();
                    pedido.Cantidad = (int)aux["Cantidad_Solicitada"];
                    pedido.Usuario = aux["Usuario"].ToString();
                    pedido.fecha = (DateTime)aux["Fecha"];
                    pedido.Estado = aux["Estado"].ToString();
                    pedido.DireccionEntrega = aux["Direccion"].ToString();
                    pedido.Descuento = (decimal)aux["Descuento"];
                    pedido.precioTotal = (decimal)aux["Precio_Total_Articulo"];

                    pedidos.Add(pedido);
                }
                return pedidos;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }
    }
}