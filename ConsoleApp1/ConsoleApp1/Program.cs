using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        public static int money = 500;

        public static List<Product> Inventory = new List<Product>
        {
            new Vaca("Vaca",200,0,0), //0
            new Vaca("Bebe vaca",0,0,0), //1
            new Oveja("Oveja",300,0,0), //2
            new Oveja("Bebe oveja",0,0,0), //3
            new Tomate("Semilla de Tomate",0,0,4,3), //4
            new Tomate("Tomate",0,0,0,0),  //5
            new Papa("Semilla de Papa",0,0,0,5), //6
            new Papa("Papa",0,0,0,0),  //7
        };

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                Farm(4);
                Farm(6);
                Console.WriteLine("¿Quieres comprar o vender algo?");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");

                string shopOption = Console.ReadLine();

                switch (shopOption)
                {
                    case "1":
                        BuyingShop();
                        break;
                    case "2":
                        SellingShop();
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }

            }
        }

        static void ComprarProducto(int productId)
        {
            if (productId < 0 || productId > Inventory.Count)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }

            Product product = Inventory[productId];

            if (product is IShop buyableProduct)
            {
                Console.WriteLine($"¿Cuántas {Program.Inventory[productId].name} deseas comprar?");
                string input = Console.ReadLine();

                if (int.TryParse(input, out int quantity))
                {
                    buyableProduct.Buy(quantity);
                }
                else
                {
                    Console.WriteLine("Entrada no válida.");
                }
            }
            else
            {
                Console.WriteLine("Este producto no es comprable.");
            }
        }

        static void VenderProducto(int productId)
        {
            if (productId < 0 || productId > Inventory.Count)
            {
                Console.WriteLine("Producto no encontrado.");
                return;
            }

            Product product = Inventory[productId];

            product.Sell(productId); 
        }

        static void BuyingShop()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Bienvenido a la tienda");
                Console.WriteLine("1. Comprar Vaca");
                Console.WriteLine("2. Comprar Oveja");
                Console.WriteLine("3. Comprar X");
                Console.WriteLine("4. Salir");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        ComprarProducto(0); //vaca
                        break;
                    case "2":
                        ComprarProducto(2);
                        break;
                    case "3":
                        ComprarProducto(2);
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("¡Gracias por tu compra!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }

        static void SellingShop()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("Bienvenido a la tienda");
                Console.WriteLine("1. Vender Vaca");
                Console.WriteLine("2. Vender Oveja");
                Console.WriteLine("3. Vender X");
                Console.WriteLine("4. Salir");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        VenderProducto(0); //vaca
                        break;
                    case "2":
                        VenderProducto(2);
                        break;
                    case "3":
                        VenderProducto(2);
                        break;
                    case "4":
                        exit = true;
                        Console.WriteLine("¡Gracias por tu compra!");
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;

                }
            }
        }
        static void MostrarInventario()
        {
            Console.WriteLine(" Inventario actual");
            foreach (var product in Inventory)
            {
                Console.WriteLine($"{product.name}: {product.quantity}");
            }
        }

        static void Farm(int i)
        {
            Product product = Inventory[i];

           if(product is Seeds seed)
           {
                seed.SeedGrow(i);
           }
        }
    }
}