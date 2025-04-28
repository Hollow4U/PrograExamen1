using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Oveja : Animals
    {
        public Oveja(string name, int price, int quantity, int growCount) : base(name, price, quantity, growCount)
        {
        }
        public void WoolProduction()
        {

        }
    }
}
