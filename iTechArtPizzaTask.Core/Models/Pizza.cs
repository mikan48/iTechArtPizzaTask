using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Pizza
    {
        public Pizza(int PizzaId, string PizzaName)
        {
            this.PizzaId = PizzaId;
            this.PizzaName = PizzaName;
        }

        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
    }
}
