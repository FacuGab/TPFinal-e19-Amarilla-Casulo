using Data;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
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
        public List<Pedido> PedidoItems { get { return pedidos; } }
        public List<CarritoItem> Pedido_Articulos { get; set; }

        //TABLA #### PEDIDOS ####
        #region PEDIDOS
        //TODO: Listar Pedidos
        public List<Pedido> ListarPedidos()
        {
            datos = new DataAccess();
            pedidos = new List<Pedido>();
      
            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                //Sacar el nombre de articulo, y agregar en la parte que liste los articulos y sus cantidades asociadas en el pedido
                datos.SetQuery("SELECT P.IdPedido as 'ID_Pedido',U.Id as 'ID_usuario',A.Id as 'ID_Articulo', U.Nombre + ' '+ U.Apellido as 'Usuario', A.Nombre as 'Nombre_Articulo', P.Cantidad as 'Cantidad_Solicitada', P.Fecha as 'Fecha', P.Estado as 'Estado', P.DireccionEntrega as 'Direccion', P.Descuento as 'Descuento', P.PrecioTotal as 'Precio_Total_Articulo' FROM PEDIDOS P JOIN USUARIOS U ON P.IdUsuarios = U.Id JOIN ARTICULOS A ON P.IdArticulos = A.Id", "query");
                datos.ReadQuery();

                var aux = datos.Lector;
                while (aux.Read())
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

        //TODO: Agregar Pedido
        public int AgregarPedido(Pedido pedidoNuevo)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("INSERT INTO PEDIDOS VALUES(@IdUsuario, @IdArticulo, @Usuario, @Fecha, @Estado, @DireccionEntrega, @Descuento, @PrecioTotal)", "query");
                datos.SetParameters("@IdUsuario", pedidoNuevo.IdUsuario);
                datos.SetParameters("@IdArticulo", pedidoNuevo.IdArticulo);
                datos.SetParameters("@Usuario", pedidoNuevo.Usuario);
                datos.SetParameters("@Fecha", pedidoNuevo.fecha);
                datos.SetParameters("@Estado", pedidoNuevo.Estado);
                datos.SetParameters("@DireccionEntrega", pedidoNuevo.DireccionEntrega);
                datos.SetParameters("@Descuento", pedidoNuevo.Descuento);
                datos.SetParameters("@PrecioTotal", pedidoNuevo.precioTotal);
                return datos.ExecuteQuery();
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

        //TODO: Editar Pedidos
        public int EditarPedido(Pedido pedido)
        {
            datos = new DataAccess();
            //NOTA: no tiene sentido darle inteligencia para diferenciar por valor individual si solo se cambia uno, es mucho mucho lio, pisar los valores anteriores.
            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                // cambie el metodo y el resto xq ejecutaba una lectura con ReadQuery(), hay que usar ExecuteQuery() para hacer un UPDATE, DElETE o INSERT, ReadQuery solo funciona con SELECT. Faltan los valores por parametro para actualizar el registro
                datos.SetQuery("UPDATE PEDIDOS SET IdUsuarios = @IdUsuario, IdArticulos = @IdArticulos, Cantidad = @Cantidad, Fecha = @Fecha, Estado = @Estado, DireccionEntrega = @DireccionEntrega, Descuento = @Descuento, PrecioTotal = @PrecioTotal WHERE IdPedido = @IdPedido", "query");
                datos.SetParameters("@IdPedido", pedido.IdPedido);
                datos.SetParameters("@IdUsuario", pedido.IdUsuario);
                datos.SetParameters("@IdArticulos", pedido.IdArticulo);
                datos.SetParameters("@Cantidad", pedido.Cantidad);
                datos.SetParameters("@Fecha", pedido.fecha); // ver si usar fecha en tipo DateTime, o mandar a la bd un strgin formateado para evitar problemas de casteo con sql
                datos.SetParameters("@Estado", pedido.Estado);
                datos.SetParameters("@DireccionEntrega", pedido.DireccionEntrega);
                datos.SetParameters("@Descuento", pedido.Descuento);
                datos.SetParameters("@PrecioTotal", pedido.precioTotal);
                int res = datos.ExecuteQuery();
                return res;
            }
            catch (SqlException ex)
            {
                throw ex;
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
        }

        //TODO: Eliminar Pedido
        public int EliminarPedido(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                datos.SetQuery("DELETE FROM PEDIDOS WHERE IdPedido = @id", "query");
                datos.SetParameters("@id", id);
                return datos.ExecuteQuery();
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

        //TODO: Modificar Estado Pedido (ex-cancelarPedido, este metodo mejor que sea unico, ya que el Estado puede modificarse mucho mas seguido)
        public int ModificarEstado(int id, string estado)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                datos.SetQuery("UPDATE PEDIDOS SET Estado = @estado WHERE IdPedido = @id", "query");
                datos.SetParameters("@estado", estado);
                datos.SetParameters("@id", id);
                return datos.ExecuteQuery();
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
        #endregion PEDIDOS

        // #### TABLA PEDIDO_ARTICULO ####
        #region PEDIDO_ARTICULO
        //TODO: Listar Todos Pedidos_articulo
        public List<CarritoItem> ListarPerdido_articulos()
        {
            datos = new DataAccess();
            CarritoItem item;
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT IdPedido, IdArticulo, Cantidad FROM PEDIDO_ARTICULO", "query");
                datos.ReadQuery();
                var aux = datos.Lector;
                Pedido_Articulos = new List<CarritoItem>();

                while(aux.Read())
                {
                    item = new CarritoItem();
                    item.Id = (int)aux["IdArticulo"];
                    item.IdPedido = (int)aux["IdPedido"];
                    item.Cantidad = (int)aux["Cantidad"];
                    Pedido_Articulos.Add(item);
                }
                return Pedido_Articulos;
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

        //TODOS: Agregar Pedido_articulo por Id
        public List<CarritoItem> ListarPedido_articulo(int id)
        {
            datos = new DataAccess();
            CarritoItem item;
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT IdPedido, IdArticulo, Cantidad FROM PEDIDO_ARTICULO WHERE IdPedido = @Id", "query");
                datos.SetParameters("@Id", id);
                datos.ReadQuery();
                var aux = datos.Lector;
                Pedido_Articulos = new List<CarritoItem>();

                while (aux.Read())
                {
                    item = new CarritoItem();
                    item.Id = (int)aux["IdArticulo"];
                    item.IdPedido = (int)aux["IdPedido"];
                    item.Cantidad = (int)aux["Cantidad"];
                    Pedido_Articulos.Add(item);
                }
                return Pedido_Articulos;
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

        //TODO: Agregar Pedido_artiulo
        public int AgregarPedido_articulo(CarritoItem pedido_articulo)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("INSERT INTO PEDIDO_ARTICULO VALUES (@IdPedido, @IdArticulo, @Cantidad)", "query");
                datos.SetParameters("@IdPedido", pedido_articulo.IdPedido);
                datos.SetParameters("@IdArticulo", pedido_articulo.Id);
                datos.SetParameters("@Cantidad", pedido_articulo.Cantidad);
                return datos.ExecuteQuery();
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

        //TODO: Editar Pedido_articulo
        public int EditarPedido_articulo(CarritoItem pedido_articulo)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("UPDATE PEDIDO_ARTICULO SET IdPedido = @IdPedido, IdArticulo = @IdArticulo, Cantidad = @Cantidad WHERE IdPedido = @IdPedido", "query");
                datos.SetParameters("@IdPedido", pedido_articulo.IdPedido);
                datos.SetParameters("@IdArticulo", pedido_articulo.Id);
                datos.SetParameters("@Cantidad", pedido_articulo.Cantidad);
                return datos.ExecuteQuery();
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

        //TODO: Eliminar Pedido_articulo
        public int EliminarPedido_articulo(int id)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("DELETE FROM PEDIDOS_ARTICULO WHERE IdPedido = @IdPedido", "query");
                datos.SetParameters("@IdPedido", id);
                return datos.ExecuteQuery();
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
        #endregion PEDIDO_ARTICULO
    }
}