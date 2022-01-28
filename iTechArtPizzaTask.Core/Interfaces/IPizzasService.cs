using iTechArtPizzaTask.Core.ViewModels;
using iTechArtPizzaTask.WebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IPizzasService
    {
        Task AddPizzaAsync(string pizzaName);
        Task DeletePizzaAsync(string pizzaName);
        Task AddPizzasIngredientsAsync(string pizzaName, string[] ingridientNames);
        Task<List<PizzaViewModel>> GetAllPizzasAsync();
        Task<PizzaInfoViewModel> GetPizzaInfoAsync(string pizzaName);
    }
}
