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

        public string Vender(List<Ingrediente> ingredientes,string nombre,int cantidadAVender)
        {
            decimal costoTotal = 0.0m;
            decimal precioTotal = 0.0m;
            decimal utilidadTotal = 0.0m;
            string respuesta = string.Empty ;
            for (int i = 0; i < cantidadAVender; i++)
            {
                foreach (var ingrediente in ingredientes)
                {
                    foreach (var producto in Productos)
                    {
                        if (ingrediente.Producto.Id==producto.Id)
                        {
                            string respuestaSalida = producto.Salida(ingrediente.CantidadRetirar);
                            if (respuestaSalida.Equals($"Exito"))
                            {
                                costoTotal += producto.Costo * ingrediente.CantidadRetirar;
                                precioTotal += producto.Precio * ingrediente.CantidadRetirar;
                                utilidadTotal += producto.Utilidad * ingrediente.CantidadRetirar;
                            }
                            else
                            {
                                respuesta = respuestaSalida;
                                return respuesta;

                            }
                        }
                    }
                }
            }
            var venta = new Venta(nombre: nombre, costo: costoTotal,precio:precioTotal,utilidad:utilidadTotal,fecha:new DateTime(2021,01,21));
            Ventas.Add(venta);
            respuesta = respuesta+ venta.Nombre + $": El costo de la venta ${venta.Costo} y un precio de ${venta.Precio} y la utilidad ${venta.Utilidad}";
            return respuesta;
        }
        
    }
}
