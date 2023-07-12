using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Pedido
    {
        public int IdPedido { get; set; }
        public int IdUsuario { get; set; }
        public int IdArticulo { get; set; } // no usar 
        public string Usuario { get; set; }
        public string NombreArt { get; set; } // no usar
        public int Cantidad { get; set; }
        public int CantidadTotal { get; set; }
        public DateTime fecha { get; set; } //ver si este formato es util
        public string Fecha { get { return string.Format(" {0:dd/MM/yyyy}.", Fecha); } } // ver si anda correctamente
        public string Estado { get; set; }
        public string DireccionEntrega { get; set; }
        public decimal Descuento { get; set; }
        public decimal precioTotal { get; set; }
        public string PrecioTotal { get { return string.Format( "{0:C2}", precioTotal); } } // ver si anda correctamente
        public List<CarritoItem> totalItems { get; set; } // por ahora de testeo, ver si tiene funcionalidad

        //CONSTRUCTORES:
        public Pedido() { }
        public Pedido(int idPedido, int idUsuario, DateTime fecha, string estado, string direccionEntrega, decimal descuento, decimal total)
        {
            IdPedido = idPedido;
            IdUsuario = idUsuario;
            this.fecha = fecha;
            Estado = estado;
            DireccionEntrega = direccionEntrega;
            Descuento = descuento;
            this.precioTotal = total;
        }
    }
}
