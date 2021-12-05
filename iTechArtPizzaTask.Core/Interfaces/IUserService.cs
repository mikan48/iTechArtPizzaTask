using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllAsync();
        Task AddAsync(User user);
        Task DeleteAsync(User user);
    }
}
