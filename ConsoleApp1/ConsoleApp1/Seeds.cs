using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Seeds : Product , IShop
    {
        public int growCount;
        public int growDay;
        public int growDayOriginal;
        public Seeds(string name, int price, int quantity, int growCount,int growDay) : base(name, price, quantity)
        {
            this.growCount = growCount;
            this.growDay = growDay;
            this.growDayOriginal = growDay;
        }

        public void Plant(int selection)
        {
            bool exit = false;
            while (!exit)
            {
                if (Program.Inventory[selection].quantity == 0)
                {
                    Console.WriteLine("No tienes semillas para plantar");
                    exit = true;
                }
                else
                {
                    Console.WriteLine($"¿Cuantas {Program.Inventory[selection].name} quieres plantar?");
                    string quantityInput = Console.ReadLine();

                    if (int.TryParse(quantityInput, out int quantityPlant) && quantityPlant > 0)
                    {
                        if (Program.Inventory[selection].quantity >= quantityPlant)
                        {
                            Program.Inventory[selection].quantity -= quantityPlant;

                            if (Program.Inventory[selection] is Seeds seeds)
                            {
                                seeds.growCount += quantityPlant;
                            }
                        }


                        Console.WriteLine($"Ahora tienes {Program.Inventory[selection].quantity} {Program.Inventory[selection].name}");
                        Console.WriteLine($"Plantas {quantityPlant} {Program.Inventory[selection].name}");
                    }

                }
            }

        }

        public void SeedGrow(int selection)
        {
            if (Program.Inventory[selection] is Seeds seeds && seeds.growCount > 0)
            {
                seeds.growDay -= 1;

                Console.WriteLine($" {seeds.name} está creciendo... Días restantes: {seeds.growDay}");

                if (seeds.growDay <= 0)
                {
                    Program.Inventory[selection + 1].quantity += seeds.growCount * 5;
                    Console.WriteLine($"Has cosechado {Program.Inventory[selection+1].quantity} {Program.Inventory[selection + 1].name}");
                    seeds.growCount = 0;
                    seeds.growDay = seeds.growDayOriginal;
                  
                }
            }
        }

        public void Buy()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine($"¿Quieres comprar {name}?");
                Console.WriteLine("1. Si");
                Console.WriteLine("2. No");

                string option = Console.ReadLine();

                switch (option)
                {
                    case "1":
                        Console.WriteLine($"¿Cuántas unidades de {name} deseas comprar?");
                        string quantityInput = Console.ReadLine();
                        if (int.TryParse(quantityInput, out int quantity))
                        {
                            int precioTotal = quantity * price;
                            Program.money = Program.money - precioTotal;
                            this.quantity += quantity;


                            Console.WriteLine($"Gastaste {precioTotal} y ahora tienes {Program.money} de dinero y obtuviste {this.quantity} {name}.");
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