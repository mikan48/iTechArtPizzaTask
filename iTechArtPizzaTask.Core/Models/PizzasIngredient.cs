using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class PizzasIngredient : BaseEntity
    {
        public Guid IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
        public Guid PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        [Column(TypeName = "money")]
        public double ingredientCost { get; set; }
    }
}
