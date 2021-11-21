using iTechArtPizzaTask.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class IngridientsService : IIngridientsService
    {
        private readonly IIngridientsRepository ingridientsRepository;
        public IngridientsService(IIngridientsRepository ingridientsRepository)
        {
            this.ingridientsRepository = ingridientsRepository ?? throw new ArgumentNullException(nameof(ingridientsRepository));
        }

        public async Task AddIngridientAsync(string ingridientName)
        {
            await ingridientsRepository.AddIngridientAsync(ingridientName);
        }
    }
}
