using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IPizzasRepository
    {
        public Task<List<Pizza>> GetAllPizzasAsync();
        public Task AddPizzaAsync(string pizzaName, double pizzaCost);
        public Task DeletePizzaAsync(string pizzaName);
    }
}
