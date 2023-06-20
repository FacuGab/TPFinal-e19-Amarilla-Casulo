using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class CarritoItem
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public decimal precio { get; set; }
        public string Precio { get { return string.Format("{0:C2}", precio); } }
        public int Cantidad { get; set; }//Agrege esta propiedad para la cantidad de items iguales en el carrito
        public string ImagenUrl { get; set; }
        public string TotalParcial { get { return string.Format( "{0:C2}", precio * Cantidad); } }
    }
}
