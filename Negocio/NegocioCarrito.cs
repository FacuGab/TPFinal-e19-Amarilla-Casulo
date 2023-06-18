using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Negocio
{
    public class NegocioCarrito
    {
        public List<CarritoItem> Items { get; set; }

        public NegocioCarrito()
        {
            Items = new List<CarritoItem>();
        }

        public void AgregarItem(CarritoItem item)//Ya debería validar que si hay otro articulo igual solo lo incremente
        {
            CarritoItem itemExistente = Items.FirstOrDefault(it => it.Id == item.Id);
            if (itemExistente != null)
            {
                // El item ya está en la lista, actualiza la cantidad
                itemExistente.Cantidad += item.Cantidad;
            }
            else
            {
                // El item no está en la lista, agrégalo
                Items.Add(item);
            }
        }

        public void BorrarItem(int itemId)
        {
            CarritoItem id = Items.FirstOrDefault(item => item.Id == itemId);
            if (id != null)
            {
                Items.Remove(id);
            }
        }

        public void ModificarCantidad(int itemId, int cantidad)//si hay algun articulo repetido le suma la cantidad
        {
            CarritoItem item = Items.FirstOrDefault(it => it.Id == itemId);
            if (item != null)
            {
                item.Cantidad = cantidad;
            }
        }
    }
}
