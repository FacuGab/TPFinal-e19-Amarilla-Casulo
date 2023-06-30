using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Categoria
    {
        //CONSTRUCTORES:
        public Categoria() { }
        public Categoria(int id, string descripcion, string img)
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
        //obtener categoria por id
        public Categoria ObtenerCategoria(int id)
        {
            Categoria categoria = new Categoria();
            categoria.Id = id;
            return categoria;
        }
    }
}
