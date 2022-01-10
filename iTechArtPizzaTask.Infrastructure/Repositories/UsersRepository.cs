using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Infrastructure.Repositories
{
    public class UsersRepository : IRepository<User>
    {
        private readonly PizzaDeliveryContext context;
        public UsersRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public Task AddAsync(User item)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(User user)
        {
            context.Users.Remove(user);
            await context.SaveChangesAsync();
        }

        public Task<User> FindItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<User> FindItemByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await context.Users.ToListAsync();
        }

        public Task UpdateAsync(User user)
        {
            throw new NotImplementedException();
        }
    }
}
