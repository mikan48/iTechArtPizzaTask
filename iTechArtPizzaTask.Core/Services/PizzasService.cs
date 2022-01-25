using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class PizzasService : IService<Pizza>
    {
        private readonly IRepository<Pizza> repository;
        public PizzasService(IRepository<Pizza> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<List<Pizza>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task AddAsync(Pizza pizza)
        {
            await repository.AddAsync(pizza);
        }

        public async Task DeleteAsync(Pizza pizza)
        {
            await repository.DeleteAsync(pizza);
        }

        public async Task UpdateAsync(Pizza pizza)
        {
            await repository.UpdateAsync(pizza);
        }

        public async Task<Pizza> FindItemByNameAsync(string name)
        {
            return await repository.FindItemByNameAsync(name);
        }

        public Task<Pizza> FindItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public List<Pizza> FindItemsById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
