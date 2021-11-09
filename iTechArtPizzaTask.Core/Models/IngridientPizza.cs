using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class IngridientPizza
    {
        public int IngridientId { get; set; }
        public Ingridient Ingridient { get; set; }
        public int PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
