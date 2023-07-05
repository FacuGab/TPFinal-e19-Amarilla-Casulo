using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Articulo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Descripcion { get; set; }
        public Marca Marca { get; set; }
        public Categoria Categoria { get; set; }
        public decimal precio { get; set; }
        public string Precio { get { return string.Format("{0:C2}", precio); } }
        public bool Estado { get; set; } // si esta activo o no para mostrar, baja/alta logica
        public string EstadoStr { get { return (Estado == true) ? "Alta" : "Baja"; } }
        public int Stock { get; set; }
        public string ImagenUrl { get; set; }

        //CONSTRUCTORES:
        public Articulo() 
        {
            Marca = new Marca();
            Categoria = new Categoria();
        }
        public Articulo(int id, string nombre, string descripcion, Marca marca, Categoria categoria, decimal precio, bool estado, int stock)
        {
            Id = id;
            Nombre = nombre;
            Descripcion = descripcion;
            //Ver si funciona asi, o simplificar el agregado de los obj marca y categoria instanciando
            Marca = marca; 
            Categoria = categoria;
            this.precio = precio;
            Estado = estado;
            Stock = stock;
        }
    }
}
