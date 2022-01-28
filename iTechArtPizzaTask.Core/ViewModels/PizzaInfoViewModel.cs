using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.ViewModels
{
    public class PizzaInfoViewModel
    {
        public string PizzaName { get; set; }
        public double PizzaCost { get; set; }
        public List<IngredientViewModel> Ingredients { get; set; }
    }
}
