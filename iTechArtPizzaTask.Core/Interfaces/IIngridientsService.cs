using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IIngridientsService
    {
        Task AddIngridientAsync(string ingridientName);
    }
}
