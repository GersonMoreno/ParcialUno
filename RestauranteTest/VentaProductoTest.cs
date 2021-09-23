using NUnit.Framework;
using DomainRestaurante;
using System.Collections.Generic;

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
        /*
            Disminuir cantidad de productos compuestos salientes y guardar la venta
            H2: COMO USUARIO QUIERO REGISTRAR LA SALIDA PRODUCTOS
            Criterio de aceptación:
            2.3. En caso de un producto compuesto la cantidad de la salida se le disminuirá a la cantidad existente de cada uno de su ingrediente
            2. 4. Cada salida debe registrar el costo del producto y el precio de la venta
            Dado	En el restaurante quiere hacer un combo perro doble y tiene productos: nombre: “Gaseosa”, cantidad: 10, costo: 1000, precio: 2000, utilidad:1000
            “Salchicha”, cantidad: 40, costo: 1000, precio: 2000, utilidad:1000
            “Laminas queso Mozarela”, cantidad: 100, costo: 700, precio: 1500, utilidad: 800
            “Pan de perro”, cantidad: 60, costo: 1000, precio:1500, utilidad:500
            Cuando	Se retira una gaseosa, unas dos salchichas, dos láminas de queso y un pan de perro
            Entonces	El sistema arrojara un mensaje “Se retiro Salchicha, habían 40 y quedaron 38.
            Se retiro Gaseosa, habían 10 y quedaron 9.
            Se retiro Laminas queso Mozarela, habían 100 y quedaron 98.
            Se retiro Pan de perro, habían 60 y quedaron 59.
            El costo de la venta $5400 y un precio de $10500 y la utilidad $5100”

         */
        [Test]
        public void DisminuirCantidadDeProductosCompuestosSalientesGuardarLaVenta()
        {
            List<Producto> Productos = new List<Producto>();
            Productos.Add(new Producto(nombre: "Salchicha", cantidad: 40, costo: 1000, precio: 2000, utilidad: 1000));
            Productos.Add(new Producto(nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000));
            Productos.Add(new Producto(nombre: "Laminas queso Mozarela", cantidad: 100, costo: 700, precio: 1500, utilidad: 800));
            Productos.Add(new Producto(nombre: "Pan de perro", cantidad: 60, costo: 1000, precio: 1500, utilidad: 500));

            
            var Salchicha = new Producto(nombre: "Salchicha", cantidad: 2, costo: 1000, precio: 2000, utilidad: 1000);
            var Gaseosa = new Producto(nombre: "Gaseosa", cantidad: 1, costo: 1000, precio: 2000, utilidad: 1000);
            var QuesoMozarela = new Producto(nombre: "Laminas queso Mozarela", cantidad: 2, costo: 700, precio: 1500, utilidad: 800);
            var PanPerro = new Producto(nombre: "Pan de perro", cantidad: 1, costo: 1000, precio: 1500, utilidad: 500);
            List<Producto> Ingredientes = new List<Producto>();
            Ingredientes.Add(Salchicha);
            Ingredientes.Add(Gaseosa);
            Ingredientes.Add(QuesoMozarela);
            Ingredientes.Add(PanPerro);

            var Restaurante = new Restaurante(productos: Productos);
            string respuesta = Restaurante.Vender(Ingredientes);
            Assert.AreEqual("Se retiro Salchicha, habían 40 y quedaron 38."
            +"\nSe retiro Gaseosa, habían 10 y quedaron 9."
            + "\nSe retiro Laminas queso Mozarela, habían 100 y quedaron 98."
            + "\nSe retiro Pan de perro, habían 60 y quedaron 59." +
            "\nEl costo de la venta $5400 y un precio de $10500 y la utilidad $5100”", respuesta);
        }
    }
}