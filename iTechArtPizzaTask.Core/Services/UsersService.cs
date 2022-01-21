using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class UsersService : IService<User>
    {
        private readonly IRepository<User> repository;
        public UsersService(IRepository<User> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task AddAsync(User user)
        {
            await repository.AddAsync(user);
        }

        public async Task DeleteAsync(User user)
        {
            await repository.DeleteAsync(user);
        }

        public async Task<User> FindItemByIdAsync(Guid id)
        {
            return await repository.FindItemByIdAsync(id);
        }

        public Task<User> FindItemByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }

        public Task UpdateAsync(User item)
        {
            throw new NotImplementedException();
        }
    }
}
