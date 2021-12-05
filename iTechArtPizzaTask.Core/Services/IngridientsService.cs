using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class IngridientsService : IIngridientsService
    {
        private readonly IRepository<Ingridient> repository;
        public IngridientsService(IRepository<Ingridient> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<List<Ingridient>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public async Task AddAsync(Ingridient ingridient)
        {
            await repository.AddAsync(ingridient);
        }
    }
}
