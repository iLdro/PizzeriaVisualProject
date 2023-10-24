using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzeriaVisual
{
    public class Pizza
    {
        public List<string> Toppings { get; set; }
        public string Size { get; set; }

        public Pizza(List<string> toppings, string size)
        {
            Toppings = toppings;
            Size = size;
        }
    }
}
