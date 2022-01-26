using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Pizza : BaseEntity
    {
        [Required(ErrorMessage = "Pizza must have name")]
        public string PizzaName { get; set; }
        [Column(TypeName = "money")]
        public double PizzaCost { get; set; }
        public string ImagePath { get; set; }
        public ICollection<PizzasIngredient> PizzasIngridients { get; set; }
        public ICollection<OrderedPizza> OrderedPizzas { get; set; }
    }
}
