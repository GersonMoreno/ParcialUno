using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainRestaurante
{
    public class Ingrediente
    {
        public Ingrediente(Producto producto, int cantidadRetirar)
        {
            Producto = producto;
            CantidadRetirar = cantidadRetirar;
        }

        public Producto Producto { get; private set; }
        public int CantidadRetirar { get; private set; }
    }
}
