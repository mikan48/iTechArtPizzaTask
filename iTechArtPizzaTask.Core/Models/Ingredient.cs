using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Ingredient : BaseEntity
    {
        public string IngredientName { get; set; }
        [Column(TypeName = "money")]
        public double IngredientCost { get; set; }
        public ICollection<PizzasIngredient> PizzasIngredients { get; set; }
    }
}
