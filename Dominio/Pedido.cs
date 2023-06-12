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
        public DateTime fecha { get; set; } //ver si este formato es util
        public string Fecha { get { return string.Format(" {0:dd/MM/yyyy}.", Fecha); } } // ver si anda correctamente
        public string Estado { get; set; }
        public string DireccionEntrega { get; set; }
        public decimal Descuento { get; set; }
        public decimal total { get; set; }
        public string Total { get { return string.Format( "{0:C2}", total); } } // ver si anda correctamente

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
            this.total = total;
        }
    }
}
