using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class UsersService : IUsersService
    {
        private readonly IRepository<User> usersRepository;
        private readonly IRepository<Order> ordersRepository;
        public UsersService(IRepository<User> usersRepository, IRepository<Order> ordersRepository)
        {
            this.usersRepository = usersRepository ?? throw new ArgumentNullException(nameof(usersRepository));
            this.ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
        }

        public async Task<List<UserViewModel>> GetAllUsersWithOrdersAsync()
        {
            List<User> users = await usersRepository.GetAllAsync();
            List<Order> orders = await ordersRepository.GetAllAsync();
            List<OrderViewModel> orderVMs = new List<OrderViewModel>();
            List<UserViewModel> userVMs = new List<UserViewModel>();

            foreach (User user in users)
            {
                orderVMs = null;
                foreach (Order order in orders)
                {
                    if(order.UserId == user.Id)
                    {
                        orderVMs.Add(new OrderViewModel { Status = order.Status, OrderCost = order.OrderCost, DestinationAddress = order.DestinationAddress});
                    }
                }
                userVMs.Add(new UserViewModel { FirstName = user.FirstName, LastName = user.LastName, Orders = orderVMs });
            }

            return userVMs;
        }

        public async Task DeleteAsync(Guid userId)
        {
            User user = await usersRepository.FindItemByIdAsync(userId);
            if (user != null)
            {
                await usersRepository.DeleteAsync(user);
            }
        }
    }
}
