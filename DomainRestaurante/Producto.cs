using System;

namespace DomainRestaurante
{
    public class Producto
    {
        public string Nombre { get; private set; }
        public int Cantidad { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Utilidad { get; private set; }
        public Producto(string nombre,int cantidad,decimal costo,decimal precio,decimal utilidad)
        {
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

    }
}
