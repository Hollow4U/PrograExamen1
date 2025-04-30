using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal abstract class Animals : Product , IShop
    {
        int growCount;
        public int productionDay;
        public int productionDayOriginal;

        public Animals(string name, int price, int quantity, int growCount, int productionDay,int productionDayOriginal) : base(name, price, quantity)
        {
            this.growCount = growCount; 
            this.productionDay = productionDay;
            this.productionDayOriginal = productionDay;
        }

        public void Reproduction(int selection)
        {
            if (Program.Inventory[selection].quantity >= 2)
            {
                Random random = new Random();
                int ranNum = random.Next(1, 21);

                if (ranNum >= 15)
                {
                    Program.Inventory[selection+1].quantity += 1;
                }
                else
                {
                    Console.WriteLine($"Parece que tus {name} se estan volviendo mas cercanas");
                }
            }
        }

        public void Growing(int selection)
        {
            if (Program.Inventory[selection].quantity > 0)
            {
                growCount+=1;

                if(growCount >= 3)
                {
                    growCount = 0;
                    Program.Inventory[selection].quantity -= 1;
                    Program.Inventory[selection - 1].quantity += 1;

                    Console.WriteLine($"Uno de tus {Program.Inventory[selection].name} crecio en una {Program.Inventory[selection - 1].name}");
                }
            }
        }

        public abstract void Production(int i);


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
