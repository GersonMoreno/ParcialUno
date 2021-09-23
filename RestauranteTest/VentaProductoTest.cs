using NUnit.Framework;
using DomainRestaurante;

namespace RestauranteTest
{
    public class VentaProductoTest
    {
        [SetUp]
        public void Setup()
        {
        }
        /*
         Entrada producto -1
        H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS
        Criterio de aceptación:
        1. La cantidad de la entrada de debe ser mayor a 0
        Dado	En el restaurante hay producto nombre: “Gaseosa”, cantidad: 10, costo: 1000, precio: 2000, utilidad:1000
        Cuando	Se registre entrada de -1
        Entonces	El sistema arrojara un mensaje “La entrada del producto es incorrecta”

         */
        [Test]
        public void EntradaProductoDeMenosUno()
        {
            var Producto = new Producto(nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            string respuesta = Producto.Entrada(cantidadEntrada: -1);
            Assert.AreEqual("La entrada del producto es incorrecta", respuesta);
        }
        /*
         Aumentar entrada En producto
        H1: COMO USUARIO QUIERO REGISTRAR LA ENTRADA PRODUCTOS
        Criterio de aceptación:
        2. La cantidad de la entrada se le aumentará a la cantidad existente del producto
        Dado	En el restaurante hay producto nombre: “Gaseosa”, cantidad: 10, costo: 1000, precio: 2000, utilidad:1000
        Cuando	Se registre la entrada de 10
        Entonces	El sistema arrojara un mensaje “La cantidad del Gaseosa aumento y es de 20”

         */
        [Test]
        public void AumentarCantidadEntradaEnProducto()
        {
            var Producto = new Producto(nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            string respuesta = Producto.Entrada(cantidadEntrada: 10);
            Assert.AreEqual("La cantidad del Gaseosa aumento y es de 20", respuesta);
        }
        /*
         Salida de producto -1
        H2: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS
        Criterio de aceptación:
        2.1. La cantidad de la salida de debe ser mayor a 0
        Dado	En el restaurante hay producto nombre: “Gaseosa”, cantidad: 10, costo: 1000, precio: 2000, utilidad:1000
        Cuando	Se retira producto de -1
        Entonces	El sistema arrojara un mensaje “La cantidad de salida es incorrecta”
         */
        [Test]
        public void SalidaDeProductoDeMenosUno()
        {
            var Producto = new Producto(nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            string respuesta = Producto.Salida(cantidadSalida: -1);
            Assert.AreEqual("La cantidad de salida es incorrecta", respuesta);
        }
        /*
         Disminuir cantidad de productos salientes
        H2: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS
        Criterio de aceptación:
        2.2. En caso de un producto sencillo la cantidad de la salida se le disminuirá a la cantidad existente del producto.
        Dado	En el restaurante hay producto nombre: “Gaseosa”, cantidad: 10, costo: 1000, precio: 2000, utilidad:1000
        Cuando	Se retira producto de 2
        Entonces	El sistema arrojara un mensaje “La cantidad de Gaseosa restante es de 8”
         */
        [Test]
        public void DisminuirCantidadDeProductosSalientes()
        {
            var Producto = new Producto(nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            string respuesta = Producto.Salida(cantidadSalida: 2);
            Assert.AreEqual("La cantidad de Gaseosa restante es de 8", respuesta);
        }
    }
}