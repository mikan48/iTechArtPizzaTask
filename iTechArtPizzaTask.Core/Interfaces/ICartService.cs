using iTechArtPizzaTask.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface ICartService
    {
        Task AddAsync(Guid userId);
        Task<List<PizzaViewModel>> GetAllPizzasInCartAsync(Guid cartId);
        Task AddPizzaInCartAsync(string pizzaName, int quantity, Guid cartId);
        Task EditPizzasInCartAsync(string pizzaName, int quantity, Guid cartId);
        Task DeletePizzaFromCartAsync(string pizzaName, Guid cartId);
    }
}
