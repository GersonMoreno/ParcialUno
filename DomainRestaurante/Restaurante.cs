using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRestaurante
{
    public class Restaurante
    {
        public List<Producto> Productos { get; private set; }
        public List<Venta> Ventas { get; private set; }
        public Restaurante(List<Producto> productos)
        {
            Productos = productos;
            Ventas = new List<Venta>();
        }

        public string Vender(List<Producto> ingredientes)
        {
            string respuesta = string.Empty ;
            foreach (var ingrediente in ingredientes)
            {
                foreach (var producto in Productos)
                {
                    if (ingrediente.Nombre.Equals(producto.Nombre))
                    {
                        respuesta += producto.Salida(ingrediente.Cantidad) + "\n";
                    }
                }
            }
            return respuesta;
            
        }
        
    }
}
