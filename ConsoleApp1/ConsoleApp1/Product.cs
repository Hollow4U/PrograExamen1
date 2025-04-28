using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Product 
    {
        public string name { get; set; }
        public int quantity { get; set; } = 0;
        public int price { get; set; }

        public Product(string name, int price, int quantity)
        {
            this.name = name;
            this.price = price;
            this.quantity = quantity;
        }

        public void Sell(int i)
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"¿Quieres vender {name}?");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine($"¿Cuántas unidades de {name} deseas vender?");
                        string quantityInput = Console.ReadLine();
                        if (int.TryParse(quantityInput, out int quantity))
                        {
                            if (this.quantity >= quantity)
                            {
                                int precioTotal = quantity * price;
                                Program.money += precioTotal;
                                this.quantity -= quantity;

                                Console.WriteLine($"Ganaste {precioTotal} y ahora tienes {Program.money} de dinero y te quedan {this.quantity} {name}.");
                            }
                            else
                            {
                                Console.WriteLine("No tienes suficientes unidades para vender.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Cantidad no valida");
                        }
                        exit = true;
                        break;
                    case "2":
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Opción no válida.");
                        break;
                }
            }
        }
    }
}
