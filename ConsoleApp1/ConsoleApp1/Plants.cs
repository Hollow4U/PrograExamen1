using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Plants : Product
    {
        public Plants(string name, int price, int quantity) : base(name, price, quantity)
        {
        }
    }
}
