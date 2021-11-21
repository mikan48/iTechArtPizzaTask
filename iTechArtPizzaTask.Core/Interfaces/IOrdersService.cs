using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<List<Order>> GetAllOrdersAsync();
        Task AddOrderAsync();
        //Task AddPizzasInCart();
        //Task EditPizzasInCart();
        Task AddPromoCodeToOrder();
    }
}
