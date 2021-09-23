using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRestaurante
{
    public class Venta
    {
        public Venta(string nombre, decimal costo, decimal precio, decimal utilidad, DateTime fecha)
        {
            Nombre = nombre;
            Costo = costo;
            Precio = precio;
            Utilidad = utilidad;
            Fecha = fecha;
        }

        public string Nombre { get; private set; }
        public decimal Costo { get; private set; }
        public decimal Precio { get; private set; }
        public decimal Utilidad { get; private set; }
        public DateTime Fecha { get; set; }

    }
}
