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
            var Producto = new Producto(1,nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);

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
            var Producto = new Producto(1,nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);

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
            
            List<Producto> productos = new List<Producto>();
            var gaseosa = new Producto(1,nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            productos.Add(gaseosa);
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(new Ingrediente(gaseosa,-1));
            var Restaurante = new Restaurante(productos);
            string respuesta = Restaurante.Vender(ingredientes, "Gaseosa",1);

            Assert.AreEqual("La cantidad de salida del producto Gaseosa es incorrecta", respuesta);
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
            List<Producto> productos = new List<Producto>();
            var gaseosa = new Producto(1, nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            productos.Add(gaseosa);
            
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(new(gaseosa,2));
            var Restaurante = new Restaurante(productos);
            string respuesta = Restaurante.Vender(ingredientes, "Gaseosa",1);

            Assert.AreEqual("Gaseosa: El costo de la venta $2000,0 y un precio de $4000,0 y la utilidad $2000,0", respuesta);
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
            Entonces	El sistema arrojara un mensaje “Combo perro doble: El costo de la venta $5400 y un precio de $10500 y la utilidad $5100”

         */
        [Test]
        public void DisminuirCantidadDeProductosCompuestosSalientesGuardarLaVenta()
        {
            List<Producto> Productos = new List<Producto>();
            var Salchicha = new Producto(1,nombre: "Salchicha", cantidad: 40, costo: 1000, precio: 2000, utilidad: 1000);
            var Gaseosa = new Producto(2,nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            var QuesoMozarela = new Producto(3,nombre: "Laminas queso Mozarela", cantidad: 100, costo: 700, precio: 1500, utilidad: 800);
            var PanPerro = new Producto(4,nombre: "Pan de perro", cantidad: 60, costo: 1000, precio: 1500, utilidad: 500);
            Productos.Add(Salchicha);
            Productos.Add(Gaseosa);
            Productos.Add(QuesoMozarela);
            Productos.Add(PanPerro);

            
           
            List<Ingrediente> Ingredientes = new List<Ingrediente>();
            Ingredientes.Add(new Ingrediente(Salchicha,2));
            Ingredientes.Add(new Ingrediente(Gaseosa,1));
            Ingredientes.Add(new Ingrediente(QuesoMozarela,2));
            Ingredientes.Add(new Ingrediente(PanPerro,1));

            var Restaurante = new Restaurante(productos: Productos);
            string respuesta = Restaurante.Vender(Ingredientes, "Combo perro doble",2);
            Assert.AreEqual("Combo perro doble: El costo de la venta $10800,0 y un precio de $21000,0 y la utilidad $10200,0", respuesta);
        }

        [Test]
        public void SalidaDeOnceProductos()
        {
            List<Producto> productos = new List<Producto>();
            var gaseosa = new Producto(1,nombre: "Gaseosa", cantidad: 10, costo: 1000, precio: 2000, utilidad: 1000);
            productos.Add(gaseosa);
            
            List<Ingrediente> ingredientes = new List<Ingrediente>();
            ingredientes.Add(new Ingrediente(gaseosa,11));
            var Restaurante = new Restaurante(productos);
            string respuesta = Restaurante.Vender(ingredientes, "Gaseosa",1);

            Assert.AreEqual("La cantidad de salida del producto Gaseosa es incorrecta", respuesta);
        }
    }
}