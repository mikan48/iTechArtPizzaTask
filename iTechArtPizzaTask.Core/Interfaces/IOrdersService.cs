using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<List<OrderViewModel>> GetAllAsync();
        Task Ordering(Guid id, Guid userId, DeliveryMethod deliveryMethod, Payment payment,
            string adress, string commentary, string promocode);
    }
}
