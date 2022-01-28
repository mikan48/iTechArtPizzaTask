using iTechArtPizzaTask.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IPromoCodesService
    {
        Task<List<PromoCodeViewModel>> GetAllAsync();
        Task AddAsync(string code, double discount, DateTime start, DateTime end);
        Task AddPromoCodeToOrder(Guid orderId, string code);
    }
}
