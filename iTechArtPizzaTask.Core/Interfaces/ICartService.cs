using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface ICartService
    {
        Task<List<OrderedPizza>> GetAllAsync();
        Task AddAsync(OrderedPizza orderedPizza);
        Task UpdateAsync(OrderedPizza orderedPizza);
        Task DeleteAsync(OrderedPizza orderedPizza);
    }
}
