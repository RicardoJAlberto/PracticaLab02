using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Supermercado
{
    internal class Program
    {
        static List<Area> areas = new List<Area>(); 
        static List<Categoria> categorias = new List<Categoria>(); 
        static List<Producto> productos = new List<Producto>(); 
        static List<Usuario> usuarios = new List<Usuario>();
        static List<Producto> carritoCompras = new List<Producto>(); 

        static void Main(string[] args)
        {

            
            areas.Add(new Area(1, "Limpieza"));
            areas.Add(new Area(2, "Decoracion"));

            
            categorias.Add(new Categoria(1, "Desinfectantes", 1));
            categorias.Add(new Categoria(2, "Adornos", 2));
            categorias.Add(new Categoria(3, "Ornamentas", 2));

            
            productos.Add(new Producto(1, "Aszistin", "J&J", DateTime.Now.AddMonths(3), DateTime.Now, "Limpiador para suelos del hogar", 10.99m, 100, 1));
            productos.Add(new Producto(2, "Velas", "Radamiel", DateTime.Now.AddMonths(6), DateTime.Now, "Velas aromaticas para el hogar", 5.99m, 50, 2));
            productos.Add(new Producto(3, "Escoba", "MSI", DateTime.Now.AddMonths(12), DateTime.Now, "Escobas para uso en el hogar", 8.99m, 80, 1));
            productos.Add(new Producto(4, "Laurel de la india", "RYMorganica", DateTime.Now.AddMonths(9), DateTime.Now, "semillas de arbol", 15.99m, 120, 3));

         
            usuarios.Add(new Usuario(1, "Rofoldo", 25, 1));
            usuarios.Add(new Usuario(2, "David", 30, 2));

            Console.WriteLine("Ingresar usuario > ");
            string usr = Console.ReadLine();

            if (usr == "Admin")
            {
                Console.Clear();
            }
            else
            {
                Console.WriteLine("usuario incorrecto");
                Thread.Sleep(500);
                Environment.Exit(0);

            }

            Console.WriteLine("Ingresar clave > ");
            string pass = Console.ReadLine();

            if (pass == ("Admin1"))
            {
                int opcion;
                do
                {
                    
                    Console.WriteLine("Supermercado - Menú principal");
                    Console.WriteLine("1. Crear Área");
                    Console.WriteLine("2. Crear Categoría");
                    Console.WriteLine("3. Crear Producto");
                    Console.WriteLine("4. Registrar Usuario");
                    Console.WriteLine("5. Realizar Venta");
                    Console.WriteLine("6. Salir");
                    Console.Write("Ingrese una opción: ");
                    opcion = Convert.ToInt32(Console.ReadLine());
                    Console.Clear();

                    switch (opcion)
                    {
                        case 1:
                            CrearArea();
                            break;
                        case 2:
                            CrearCategoria();
                            break;
                        case 3:
                            CrearProducto();
                            break;
                        case 4:
                            RegistrarUsuario();
                            break;
                        case 5:
                            RealizarVenta();
                            break;
                        case 6:
                            Console.WriteLine("Gracias por usar la aplicación");
                            break;
                        default:
                            Console.WriteLine("Opcion invalida. Por favor, ingrese una opcion valida.");
                            break;
                    }
                } while (opcion != 6);

            }
            else
            {
                Console.WriteLine("Error");
                Thread.Sleep(500);
                Environment.Exit(0);
            }

           
        }
        static void CrearArea()
        {
            Console.WriteLine("Crear Área");
            Console.Write("Ingrese el nombre del área: ");
            string nombre = Console.ReadLine();
            int id = areas.Count + 1;
            areas.Add(new Area(id, nombre));
            Console.WriteLine("Área creada exitosamente.");
        }

        static void CrearCategoria()
        {
            Console.WriteLine("Crear Categoría");
            Console.Write("Ingrese el nombre de la categoría: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el ID del área a la que pertenece la categoría: ");
            int areaId = Convert.ToInt32(Console.ReadLine());
            int id = categorias.Count + 1;
            categorias.Add(new Categoria(id, nombre, areaId));
            Console.WriteLine("Categoría creada exitosamente.");
        }

        static void CrearProducto()
        {
            Console.WriteLine("Crear Producto");
            Console.Write("Ingrese el nombre del producto: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese el proveedor del producto: ");
            string proveedor = Console.ReadLine();
            Console.Write("Ingrese la fecha de caducidad del producto (dd/MM/yyyy): ");
            DateTime fechaCaducidad = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Ingrese la fecha de entrada del producto (dd/MM/yyyy): ");
            DateTime fechaEntrada = Convert.ToDateTime(Console.ReadLine());
            Console.Write("Ingrese los detalles del producto: ");
            string detalles = Console.ReadLine();
            Console.Write("Ingrese el precio del producto: ");
           decimal precio = Convert.ToDecimal(Console.ReadLine());
           Console.Write("Ingrese la cantidad de unidades del producto: ");
           int unidades = Convert.ToInt32(Console.ReadLine());
           Console.Write("Ingrese el ID de la categoría a la que pertenece el producto: ");
           int categoriaId = Convert.ToInt32(Console.ReadLine());
           int id = productos.Count + 1;
           productos.Add(new Producto(id, nombre, proveedor, fechaCaducidad, fechaEntrada, detalles, precio, unidades, categoriaId));
           Console.WriteLine("Producto creado exitosamente.");
        }

        static void RegistrarUsuario()
        {
            Console.WriteLine("Registrar Usuario");
            Console.Write("Ingrese el ID del usuario: ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nombre del usuario: ");
            string nombre = Console.ReadLine();
            Console.Write("Ingrese la edad del usuario: ");
            int edad = Convert.ToInt32(Console.ReadLine());
            Console.Write("Ingrese el nivel del usuario (1 o 2): ");
            int nivel = Convert.ToInt32(Console.ReadLine());
            usuarios.Add(new Usuario(id, nombre, edad, nivel));
            Console.WriteLine("Usuario registrado exitosamente.");
        }

        static void RealizarVenta()
        {
            Console.WriteLine("Realizar Venta");
            Console.Write("Ingrese el ID del usuario que realiza la venta: ");
            int usuarioId = Convert.ToInt32(Console.ReadLine());

           
            Usuario usuario = usuarios.Find(u => u.Id == usuarioId);
            if (usuario == null)
            {
                Console.WriteLine("Usuario no encontrado. Por favor, registre el usuario antes de realizar una venta.");
                return;
            }

            if (usuario.Nivel == 1)
            {
                Console.WriteLine("El usuario no tiene permisos para realizar ventas.");
                return;
            }

            
            Console.WriteLine("Áreas Disponibles:");
            foreach (Area area in areas)
            {
                Console.WriteLine($"{area.Id}. {area.Nombre}");
            }
            Console.Write("Seleccione el ID del área: ");
            int areaId = Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("Categorías del Área:");
            List<Categoria> categoriasDelArea = categorias.FindAll(c => c.AreaId == areaId);
            foreach (Categoria categoria in categoriasDelArea)
            {
                Console.WriteLine($"{categoria.Id}. {categoria.Nombre}");
            }
            Console.Write("Seleccione el ID de la categoría: ");
            int categoriaId = Convert.ToInt32(Console.ReadLine());

            
            Console.WriteLine("Productos de la Categoría:");
            List<Producto> productosDeCategoria = productos.FindAll(p => p.CategoriaId == categoriaId);
            foreach (Producto producto in productosDeCategoria)
            {
                Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Unidades Disponibles: {producto.Unidades}");
            }

            
            List<Producto> productosSeleccionados = new List<Producto>();
            decimal totalAPagar = 0;
            bool seguirComprando = true;
            while (seguirComprando)
            {
                Console.Write("Ingrese el ID del producto que desea comprar (0 para finalizar): ");
                int productoId = Convert.ToInt32(Console.ReadLine());
                if (productoId == 0)
                {
                    seguirComprando = false;
                    break;
                }
                Producto productoSeleccionado = productos.Find(p => p.Id == productoId);
                if (productoSeleccionado == null)
                {
                    Console.WriteLine("Producto no encontrado. Por favor, seleccione un producto válido.");
                    continue;
                }
                Console.Write("Ingrese la cantidad de unidades que desea comprar: ");
                int cantidadCompra = Convert.ToInt32(Console.ReadLine());

                if (cantidadCompra > productoSeleccionado.Unidades)
                {
                    Console.WriteLine("No hay suficientes unidades disponibles. Por favor, ingrese una cantidad válida.");
                    continue;
                }

            
                productoSeleccionado.Unidades -= cantidadCompra;
                productosSeleccionados.Add(productoSeleccionado);
                totalAPagar += productoSeleccionado.Precio * cantidadCompra;

                Console.WriteLine("Producto agregado a la compra exitosamente.");

              
                Console.WriteLine("Resumen de la Compra:");
                Console.WriteLine("Productos seleccionados:");
                foreach (Producto producto in productosSeleccionados)
                {
                    Console.WriteLine($"ID: {producto.Id}, Nombre: {producto.Nombre}, Precio: {producto.Precio}, Cantidad: {producto.Unidades}");
                }
                Console.WriteLine($"Total a pagar: {totalAPagar}");
                Console.Write("Ingrese el nombre del cliente: ");
                string nombreCliente = Console.ReadLine();

                Console.WriteLine("Venta realizada exitosamente.");
            }
        }
    }

}



class Producto
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Proveedor { get; set; }
    public DateTime FechaCaducidad { get; set; }
    public DateTime FechaEntrada { get; set; }
    public string Detalles { get; set; }
    public decimal Precio { get; set; }
    public int Unidades { get; set; }
    public int CategoriaId { get; set; }

    
    public Producto(int id, string nombre, string proveedor, DateTime fechaCaducidad, DateTime fechaEntrada, string detalles, decimal precio, int unidades, int categoriaId)
    {
        Id = id;
        Nombre = nombre;
        Proveedor = proveedor;
        FechaCaducidad = fechaCaducidad;
        FechaEntrada = fechaEntrada;
        Detalles = detalles;
        Precio = precio;
        Unidades = unidades;
        CategoriaId = categoriaId;
    }
}


class Categoria
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int AreaId { get; set; }

    
    public Categoria(int id, string nombre, int areaId)
    {
        Id = id;
        Nombre = nombre;
        AreaId = areaId;
    }
}


class Area
{
    public int Id { get; set; }
    public string Nombre { get; set; }

 
    public Area(int id, string nombre)
    {
        Id = id;
        Nombre = nombre;
    }
}

class Usuario
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public int Edad { get; set; }
    public int Nivel { get; set; }

    
    public Usuario(int id, string nombre, int edad, int nivel)
    {
        Id = id;
        Nombre = nombre;
        Edad = edad;
        Nivel = nivel;
    }
}
