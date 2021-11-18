using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Pizza
    {
        //public Pizza(int PizzaId, string PizzaName)
        //{
        //    this.PizzaId = PizzaId;
        //    this.PizzaName = PizzaName;
        //}

        [Key]
        public int PizzaId { get; set; }
        public string PizzaName { get; set; }
        [Column(TypeName = "money")]
        public double PizzaCost { get; set; }
        public ICollection<Ingridient> Ingridients { get; set; }
        public ICollection<IngridientPizza> IngridientPizzas { get; set; }
        public ICollection<OrderPizza> OrderPizzas { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
