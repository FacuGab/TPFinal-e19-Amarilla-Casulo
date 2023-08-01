using System.Collections.Generic;
using System.Linq;
using Dominio;

namespace Negocio
{
    public class NegocioCarrito
    {
        public List<CarritoItem> Items { get; set; }

        //Constructor
        public NegocioCarrito()
        {
            Items = new List<CarritoItem>();
        }

        //TODO: Agregar Item
        public void AgregarItem(CarritoItem item)
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

        //TODO: Borrar Item Carrito
        public void BorrarItem(int itemId)
        {
            CarritoItem itemMatch = Items.FirstOrDefault(item => item.Id == itemId);
            if (itemMatch != null)
            {
                Items.Remove(itemMatch);
            }
        }

        //TODO: Modificar Cantidad
        public void ModificarCantidad(int itemId, int cantidad)//si hay algun articulo repetido le suma la cantidad
        {
            CarritoItem itemMatch = Items.FirstOrDefault(it => it.Id == itemId);
            if (itemMatch != null)
            {
                itemMatch.Cantidad = cantidad;
            }
        }
    }
}
