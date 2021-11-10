using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Ingridient
    {
        [Key]
        public int IngridientId { get; set; }
        public string IngridientName { get; set; }
        public ICollection<Pizza> Pizzas { get; set; }
        public ICollection<IngridientPizza> IngridientPizzas { get; set; }
    }
}
