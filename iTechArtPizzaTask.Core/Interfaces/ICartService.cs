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
        Task<bool> AddPizzaInCartAsync(string pizzaName, int quantity, Guid cartId);
        Task<bool> EditPizzasInCartAsync(string pizzaName, int quantity, Guid cartId);
        Task<bool> DeletePizzaFromCartAsync(string pizzaName, Guid cartId);
    }
}
