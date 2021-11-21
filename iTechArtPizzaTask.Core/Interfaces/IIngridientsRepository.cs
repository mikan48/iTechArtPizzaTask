using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IIngridientsRepository
    {
        public Task AddIngridientAsync(string ingridientName);
    }
}
