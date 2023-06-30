using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Marca
    {
        //CONSTRUCTORES:
        public Marca() { }
        public Marca(int id, string descripcion, string img) 
        {
            Id = id;
            Descripcion = descripcion;
            UrlImagen = img;
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }
        public string UrlImagen { get; set; }
        public override string ToString()
        {
            return Descripcion;
        }
        //obtener marca por id
        public Marca ObtenerMarca(int id)
        {
            Marca marca = new Marca();
            marca.Id = id;
            return marca;
        }
    }
}
