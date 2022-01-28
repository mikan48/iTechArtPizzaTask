using iTechArtPizzaTask.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IIngredientsService
    {
        Task<List<IngredientViewModel>> GetAllAsync();
        Task AddAsync(string ingridientName, double ingridientCost);
    }
}
