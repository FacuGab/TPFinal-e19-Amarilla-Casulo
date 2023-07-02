using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarritoItem
    {
        public int Id { get; set; } // IdArticulo seria
        public string Nombre { get; set; }
        public decimal precio { get; set; }
        public string Precio { get { return string.Format("{0:C2}", precio); } }
        public int Cantidad { get; set; }
        public string ImagenUrl { get; set; }
        public string TotalParcial { get { return string.Format( "{0:C2}", precio * Cantidad); } }
        public int IdPedido { get; set; } //para usar en pedido
        public string Descripcion { get; set; }
        public string Marca { get; set; }
        public string Categoria { get; set;}
        public string Estado { get; set;}
        public int Stock { get; set; }

    }
}
