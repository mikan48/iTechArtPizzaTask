using iTechArtPizzaTask.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IUsersService
    {
        Task<List<UserViewModel>> GetAllUsersWithOrdersAsync();
        Task DeleteAsync(Guid userId);
    }
}
