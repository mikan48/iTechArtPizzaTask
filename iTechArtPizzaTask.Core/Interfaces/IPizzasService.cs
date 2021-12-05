using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IPizzasService
    {
        Task<List<Pizza>> GetAllAsync();
        Task AddAsync(Pizza pizza);
        Task DeleteAsync(Pizza pizza);
    }
}
