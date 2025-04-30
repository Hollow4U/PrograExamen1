using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Oveja : Animals
    {
        public Oveja(string name, int price, int quantity, int growCount, int productionDay, int productionDayOriginal) : base(name, price, quantity, growCount,productionDay, productionDayOriginal)
        {
        }
        public override void Production(int selection)
        {
            if (Program.Inventory[selection] is Animals animal && animal.productionDay > 0)
            {
                animal.productionDay -= 1;

                if (animal.productionDay <= 0)
                {
                    Program.Inventory[selection + 7].quantity += animal.productionDay * Program.Inventory[selection].quantity;
                    Console.WriteLine($"Ha obtenido {Program.Inventory[selection + 7].quantity} {Program.Inventory[selection + 7].name}");
                    animal.productionDay = 0;
                    animal.productionDay = animal.productionDayOriginal;

                }
            }
        }
    }
}