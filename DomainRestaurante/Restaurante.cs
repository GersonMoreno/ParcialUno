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
            decimal costoTotal = 0.0m;
            decimal precioTotal = 0.0m;
            decimal utilidadTotal = 0.0m;
            string respuesta = string.Empty ;
            foreach (var ingrediente in ingredientes)
            {
                foreach (var producto in Productos)
                {
                    if (ingrediente.Nombre.Equals(producto.Nombre))
                    {
                        respuesta += producto.Salida(ingrediente.Cantidad) + "\n";
                        costoTotal += producto.Costo*ingrediente.Cantidad;
                        precioTotal += producto.Precio*ingrediente.Cantidad;
                        utilidadTotal += producto.Utilidad* ingrediente.Cantidad;
                    }
                }
            }
            var venta = new Venta(nombre: "Combo perro doble",costo: costoTotal,precio:precioTotal,utilidad:utilidadTotal,fecha:new DateTime(2021,01,21));
            Ventas.Add(venta);
            respuesta = respuesta+ venta.Nombre + $": El costo de la venta ${venta.Costo} y un precio de ${venta.Precio} y la utilidad ${venta.Utilidad}";
            return respuesta;
            
        }
        
    }
}
