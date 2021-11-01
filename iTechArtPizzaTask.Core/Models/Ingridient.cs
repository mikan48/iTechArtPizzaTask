using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Ingridient
    {
        public int IngridientId { get; set; }
        public string IngridientName { get; set; }
        public int PizzaId { get; set; } //FK_pizzaId
        public Pizza Pizza { get; set; }
    }
}
