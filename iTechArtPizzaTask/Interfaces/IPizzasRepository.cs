using iTechArtPizzaTask.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Interfaces
{
    interface IPizzasRepository
    {
        public List<Pizza> GetPizzas();
    }
}
