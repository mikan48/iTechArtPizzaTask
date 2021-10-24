using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using iTechArtPizzaTask.Interfaces;
using iTechArtPizzaTask.Models;

namespace iTechArtPizzaTask.Repositories.Fakes
{
    public class PizzasRepository : IPizzasRepository
    {
        private static List<Pizza> pizzas = new List<Pizza>
        {
            new Pizza
            (
                id: 1,
                pizzaName: "Carbonara"
            ),
            new Pizza
            (
                id: 2,
                pizzaName: "Pepperoni"
            ),
        };

        public List<Pizza> GetPizzas() => pizzas;
    }
}
