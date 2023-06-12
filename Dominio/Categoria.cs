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
        public Categoria(int id, string descripcion)
        {
            Id = id;
            Descripcion = descripcion;
        }
        public int Id { get; set; }
        public string Descripcion { get; set; }

        public override string ToString()
        {
            return Descripcion;        
        }
    }
}
