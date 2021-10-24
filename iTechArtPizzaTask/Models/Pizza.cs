using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Models
{
    public class Pizza
    {
        public Pizza(int id, string pizzaName)
        {
            this.id = id;
            this.pizzaName = pizzaName;
        }

        public int id { get; set; }
        public string pizzaName { get; set; }
    }
}
