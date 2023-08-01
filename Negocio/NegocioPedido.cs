using Data;
using Dominio;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

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
        //TODO: Listar Pedidos (trae con mas data que solo la del pedido, es una query joineada)
        public List<Pedido> ListarPedidos()
        {
            datos = new DataAccess();
            pedidos = new List<Pedido>();
      
            try
            {
                datos.AbrirConexion();
                //Cambiar por un sp
                //Sacar el nombre de articulo, y agregar en la parte que liste los articulos y sus cantidades asociadas en el pedido
                datos.SetQuery("sp_ListarPedidos","sp");
                datos.ReadQuery();

                var aux = datos.Lector;
                while (aux.Read())
                {
                    pedido = new Pedido();
                    pedido.IdPedido = (int)aux["ID_Pedido"];
                    pedido.IdUsuario = (int)aux["ID_usuario"];
                    pedido.Cantidad = (int)aux["Cantidad_Articulos"];
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

        //TODO: Listar Pedodo por ID y modo (puede filtara por idPedido y por idUsuario)
        public List<Pedido> ListarPedidos(int id, string modo = null)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT IdPedido, IdUsuarios, IdArticulos, U.Nombre+' '+U.Apellido as 'Usuario', Cantidad, Fecha, Estado, DireccionEntrega, Descuento, PrecioTotal FROM PEDIDOS INNER JOIN USUARIOS U ON IdUsuarios = U.Id WHERE IdPedido = @id", "query");
                datos.SetParameters("@modo", modo);
                datos.SetParameters("@id", id);
                datos.ReadQuery();

                var aux = datos.Lector;
                pedidos = new List<Pedido>();
                while(aux.Read())
                {
                    pedido = new Pedido();
                    pedido.IdPedido = (int)aux["IdPedido"];
                    pedido.IdUsuario = (int)aux["IdUsuarios"];
                    pedido.IdArticulo = (int)aux["IdArticulos"];
                    pedido.Usuario = aux["Usuario"].ToString();
                    pedido.Cantidad = (int)aux["Cantidad"];
                    pedido.fecha = (DateTime)aux["Fecha"];
                    pedido.Estado = aux["Estado"].ToString();
                    pedido.DireccionEntrega = aux["DireccionEntrega"].ToString();
                    pedido.Descuento = (decimal)aux["Descuento"];
                    pedido.precioTotal = (decimal)aux["PrecioTotal"];
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

        // TODO: Listar Pedidos por Filtro
        public List<Pedido> ListarPedidos(string filtro)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery($"SELECT IdPedido, IdUsuarios, IdArticulos, U.Nombre+' '+U.Apellido as 'Usuario', Cantidad, Fecha, Estado, DireccionEntrega, Descuento, PrecioTotal FROM PEDIDOS INNER JOIN USUARIOS U ON IdUsuarios = U.Id WHERE Estado = @filtro", "query");
                datos.SetParameters("@filtro", filtro);
                datos.ReadQuery();

                var aux = datos.Lector;
                pedidos = new List<Pedido>();
                while (aux.Read())
                {
                    pedido = new Pedido();
                    pedido.IdPedido = (int)aux["IdPedido"];
                    pedido.IdUsuario = (int)aux["IdUsuarios"];
                    pedido.IdArticulo = (int)aux["IdArticulos"];
                    pedido.Usuario = aux["Usuario"].ToString();
                    pedido.Cantidad = (int)aux["Cantidad"];
                    pedido.fecha = (DateTime)aux["Fecha"];
                    pedido.Estado = aux["Estado"].ToString();
                    pedido.DireccionEntrega = aux["DireccionEntrega"].ToString();
                    pedido.Descuento = (decimal)aux["Descuento"];
                    pedido.precioTotal = (decimal)aux["PrecioTotal"];
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
        public int AgregarPedido(Pedido pedidoNuevo, string tipo)
        {
            datos = new DataAccess();
            try
            {
                int totalItems;
                if(pedidoNuevo.totalItems == null)
                    totalItems = pedidoNuevo.Cantidad;
                else
                    totalItems = pedidoNuevo.totalItems.Count;

                datos.AbrirConexion();

                if (tipo == "query")
                    datos.SetQuery("INSERT INTO PEDIDOS (IdUsuarios, IdArticulos, Cantidad, Fecha, Estado, DireccionEntrega, Descuento, PrecioTotal) VALUES (@IdUsuario, @IdArticulo, @Cantidad, GETDATE(), @Estado, @DireccionEntrega, @Descuento, @PrecioTotal)", tipo);
                else if (tipo == "sp")
                    datos.SetQuery("sp_CrearPedido", tipo);

                datos.SetParameters("@IdUsuario", pedidoNuevo.IdUsuario);
                datos.SetParameters("@IdArticulo", pedidoNuevo.IdArticulo);
                datos.SetParameters("@Cantidad", totalItems);
                datos.SetParameters("@Fecha", pedidoNuevo.fecha); //ver si la fecha la agarra bien SQL, x ahora quedo un getdate() por parte de la bd
                datos.SetParameters("@Estado", pedidoNuevo.Estado);
                datos.SetParameters("@DireccionEntrega", pedidoNuevo.DireccionEntrega);
                datos.SetParameters("@Descuento", pedidoNuevo.Descuento);
                datos.SetParameters("@PrecioTotal", pedidoNuevo.precioTotal);

                if(tipo == "sp")
                    return (int)datos.ExecuteScalar();
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

        //TODOS: Listar Pedido_articulo por Id
        public List<CarritoItem> ListarPedido_articulo(int id)
        {
            datos = new DataAccess();
            CarritoItem item;
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("sp_ListarPedido_Articulos", "sp");
                datos.SetParameters("@id", id);
                datos.ReadQuery();
                var aux = datos.Lector;
                Pedido_Articulos = new List<CarritoItem>();

                while (aux.Read())
                {
                    item = new CarritoItem();
                    item.Id = (int)aux["IdArticulo"];
                    item.IdPedido = id;
                    item.Cantidad = (int)aux["Cantidad"];
                    item.Nombre = aux["Nombre"].ToString();
                    item.Descripcion = aux["Descripcion"].ToString();
                    item.Marca = aux["Marca"].ToString();
                    item.Categoria = aux["Categoria"].ToString();
                    item.ImagenUrl = aux["ImagenUrl"].ToString();
                    item.Estado = aux["Estado"].ToString();
                    item.Stock =  (int)aux["Stock"];
                    item.precio = (decimal)aux["Precio"];
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

        //TODO: Agregar Pedido_articulo Lista
        public int AgregarPedido_articulo(List<CarritoItem> pedido_articulo)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("INSERT INTO PEDIDO_ARTICULO VALUES (@IdPedido, @IdArticulo, @Cantidad)", "query");
                int contador = 0;

                foreach (CarritoItem item in pedido_articulo)
                {
                    datos.SetParameters("@IdPedido", item.IdPedido);
                    datos.SetParameters("@IdArticulo", item.Id);
                    datos.SetParameters("@Cantidad", item.Cantidad);
                    contador += datos.ExecuteQuery();
                    datos.DisposeParameters();
                }
                return contador;
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
                datos.SetQuery("UPDATE PEDIDO_ARTICULO SET IdArticulo = @IdArticulo, Cantidad = @Cantidad WHERE IdPedido = @IdPedido", "query");
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
                datos.SetQuery("DELETE FROM PEDIDO_ARTICULO WHERE IdPedido = @IdPedido", "query");
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

        // OTROS
        //TODO: Cargar Pedido
        public Pedido CargarPedido(List<CarritoItem> lista, Usuario usuarioActual, decimal total, string dirEntrega = null, decimal descuento = 0.00M)
        {
            try
            {
                pedido = new Pedido();

                pedido.IdUsuario = usuarioActual.Id;
                pedido.Usuario = usuarioActual.Nombre + usuarioActual.Apellido;
                pedido.fecha = DateTime.Now;
                pedido.Estado = "INICIADO";
                pedido.DireccionEntrega = dirEntrega ?? usuarioActual.Direccion;
                pedido.totalItems = new List<CarritoItem>(lista);
                pedido.Cantidad = lista.Sum(itm => itm.Cantidad); // cantidad de articulos distintos, no de unidades totales

                //Aca podriamos calcular nuevamente el total a partir de info en lista y llamar un metodo para calcular el total final si usamos descuento
                pedido.Descuento = descuento > 0.00M? descuento : 0.00M;
                pedido.precioTotal = total;

                return pedido;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Caragar Id Pedido
        public void CargarIdPedido(List<CarritoItem> items, int idPedido)
        {
            try
            {
                items.ForEach(itm => itm.IdPedido = idPedido);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        //TODO: Dar Alta/Baja Pedido
        public int CambiarEstado(int idMatch, string estado)
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("UPDATE PEDIDOS SET Estado = @estado WHERE IdPedido = @id ", "query");
                datos.SetParameters("@id", idMatch);
                datos.SetParameters("@estado", estado);
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

        //todo: mostrar cantidad de pedidos realizados
        public int CantidadPedidos()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT COUNT(*) FROM PEDIDOS WHERE ESTADO='Terminado' OR ESTADO='INICIADO'", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        public int CantPedidosMesAnterior()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT COUNT(*) - (SELECT COUNT(*) FROM PEDIDOS WHERE MONTH(Fecha) = MONTH(GETDATE())- 1 AND Estado = 'terminado' OR Estado='iniciado' ) AS DiferenciaPedidos FROM PEDIDOS WHERE MONTH(Fecha) = MONTH(GETDATE()) AND Estado = 'terminado' OR Estado='iniciado';", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        //todo: mostrar cantidad de pedidos realizados
        public decimal RecaudacionTotal()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT SUM(PrecioTotal) FROM PEDIDOS", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        public decimal RecaudacionPromedio()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("SELECT AVG(PrecioTotal) FROM PEDIDOS", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        public decimal PedidosCompletados()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("select count(*) from PEDIDOS where Estado ='terminado'", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        public decimal PedidosPendientes()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("select count(*) from pedidos where Estado='iniciado'", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        public decimal CantidadUsuarios()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("select count(*) from USUARIOS where Activo = 1 ", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        public decimal CantidadArticulos()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("select count(*) from ARTICULOS where ESTADO = 1;", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
        public decimal CantidadMarcas()
        {
            datos = new DataAccess();
            try
            {
                datos.AbrirConexion();
                datos.SetQuery("select count(*) from MARCAS;", "query");
                var result = datos.ExecuteScalar(); // Ejecutar la consulta y obtener el resultado

                if (result != null && result != DBNull.Value)
                {
                    return Convert.ToDecimal(result);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                datos.CerrarConexion();
            }
            return 0; // Si no se encuentra ningún resultado, devolver 0
        }
    }
}