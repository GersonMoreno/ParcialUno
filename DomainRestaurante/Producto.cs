using System;

namespace DomainRestaurante
{
    public class Producto
    {
        public int Id { get; private set; }
        public string Nombre { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Utilidad { get; private set; }
        public Producto(int id, string nombre,int cantidad,decimal costo,decimal precio,decimal utilidad)
        {
            Id = id;
            Nombre = nombre;
            Cantidad = cantidad;
            Costo = costo;
            Precio = precio;
            Utilidad = utilidad;
        }
        public string Entrada(int cantidadEntrada)
        {
            if (cantidadEntrada<=0)
            {
                return "La entrada del producto es incorrecta";
            }
            Cantidad += cantidadEntrada;
            return $"La cantidad del {Nombre} aumento y es de {Cantidad}";
        }
        public string Salida(int cantidadSalida)
        {
            if (cantidadSalida <= 0 || (Cantidad-cantidadSalida)<0)
            {
                return $"La cantidad de salida del producto {Nombre} es incorrecta";
            }
            var cantidadInicial = Cantidad;
            Cantidad -= cantidadSalida;
            return $"Exito";
        }
    }
}
