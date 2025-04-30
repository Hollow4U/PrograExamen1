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
            new Vaca("Vaca",200,0,0,1,0), //0
            new Vaca("Bebe vaca",0,0,0,0,0), //1
            new Oveja("Oveja",300,0,0,10,0), //2
            new Oveja("Bebe oveja",0,0,0,0,0), //3
            new Seeds("Semilla de Tomate",0,0,4,3), //4
            new Tomate("Tomate",0,0,0,0),  //5
            new Seeds("Semilla de Papa",0,0,0,5), //6
            new Papa("Papa",0,0,0,0),  //7
            new Product("Leche",300,0), //8
            new Product("Lana", 500,0) //9
        };

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                FarmPlants(4);
                FarmPlants(6);
                FarmReproduction(0);
                FarmReproduction(2);
                AnimalGrowing(1);
                AnimalGrowing(3);
                AnimalProduction(0);
                AnimalProduction(2);



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
                buyableProduct.Buy();
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
                Console.WriteLine("3. Comprar Semillas de Tomate");
                Console.WriteLine("4. Comprar Semillas de Papa");
                Console.WriteLine("5. Salir");

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
                        ComprarProducto(4);
                        break;
                    case "4":
                        ComprarProducto(6);
                        break;
                    case "5":
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
                Console.WriteLine("3. Vender Tomate");
                Console.WriteLine("4. Vender Papa");
                Console.WriteLine("5. Vender Leche");
                Console.WriteLine("6. Vender Lana");
                Console.WriteLine("7. Salir");

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
                        VenderProducto(5);
                        break;
                    case "4":
                        VenderProducto(7);
                        break;
                    case "5":
                        VenderProducto(8);
                        break;
                    case "6":
                        VenderProducto(9);
                        break;
                    case "7":
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

        static void FarmPlants(int i)
        {
            Product product = Inventory[i];

           if(product is Seeds seed)
           {
                seed.SeedGrow(i);
           }
        }

        static void FarmReproduction(int i)
        {
            Product product = Inventory[i];

            if(product is Animals animal)
            {
                animal.Reproduction(i);
            }
        }

        static void AnimalGrowing(int i)
        {
            Product product = Inventory[i];

            if (product is Animals animal && Program.Inventory[i].quantity > 0)
            {
                animal.Growing(i);
            }
        }
        static void AnimalProduction(int i)
        {
            Product product = Inventory[i];

            if (product is Animals animal && Program.Inventory[i].quantity > 0)
            {
                animal.Production(i);
            }
        }

    }
}