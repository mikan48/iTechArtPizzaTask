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
    public class PromoCodeService : IPromoCodesService
    {
        private readonly IRepository<PromoCode> promoCodeRepository;
        private readonly IRepository<Order> orderRepository;
        public PromoCodeService(IRepository<PromoCode> promoCodeRepository, IRepository<Order> orderRepository)
        {
            this.promoCodeRepository = promoCodeRepository ?? throw new ArgumentNullException(nameof(promoCodeRepository));
            this.orderRepository = orderRepository ?? throw new ArgumentNullException(nameof(orderRepository));
        }
        public async Task<List<PromoCodeViewModel>> GetAllAsync()
        {
            List<PromoCode> codes = await promoCodeRepository.GetAllAsync();
            List<PromoCodeViewModel> codesVMs = new List<PromoCodeViewModel>();
            foreach (PromoCode code in codes)
            {
                codesVMs.Add(new PromoCodeViewModel { Code = code.Code, Discount = code.Discount });
            }
            return codesVMs;
        }

        public async Task AddAsync(string code, double discount, DateTime start, DateTime end)
        {
            PromoCode promoCode = new PromoCode()
            {
                Code = code,
                Discount = discount,
                StartDate = start,
                EndDate = end
            };
            await promoCodeRepository.AddAsync(promoCode);
        }

        public async Task AddPromoCodeToOrder(Guid orderId, string code)
        {
            Order order = await orderRepository.FindItemByIdAsync(orderId);
            PromoCode promoCode = await promoCodeRepository.FindItemByNameAsync(code);
            if (order != null && promoCode != null)
            {
                order.OrderCost *= (1 - promoCode.Discount);
            }
        }
    }
}
