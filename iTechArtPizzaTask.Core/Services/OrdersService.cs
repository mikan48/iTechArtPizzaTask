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
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> ordersRepository;
        private readonly IRepository<PromoCode> promoCodeRepository;
        public OrdersService(IRepository<Order> repository, IRepository<PromoCode> promoCodeRepository)
        {
            this.ordersRepository = ordersRepository ?? throw new ArgumentNullException(nameof(ordersRepository));
            this.promoCodeRepository = promoCodeRepository ?? throw new ArgumentNullException(nameof(promoCodeRepository));
        }
        public async Task<List<OrderViewModel>> GetAllAsync()
        {
            List<Order> orders = await ordersRepository.GetAllAsync();
            List<OrderViewModel> orderVMs = new();
            foreach (Order order in orders)
            {
                orderVMs.Add(new OrderViewModel 
                { 
                    Status = order.Status, 
                    DestinationAddress = order.DestinationAddress, 
                    OrderCost = order.OrderCost
                }
                );
            }
            return orderVMs;
        }

        public async Task Ordering(Guid id, Guid userId, DeliveryMethod deliveryMethod, Payment payment,
                                                        string adress, string commentary, string promocode)
        {
            Order order = await ordersRepository.FindItemByIdAsync(id);
            if (order != null)
            {
                double discount = 0;
                if (promocode != null)
                {
                    PromoCode code = await promoCodeRepository.FindItemByNameAsync(promocode);
                    if (code != null)
                    {
                        DateTime time = DateTime.Now;
                        if (time < code.EndDate && time > code.StartDate)
                        {
                            discount = code.Discount;
                        }
                    }
                }

                order.UserId = userId;
                order.DeliveryMethod = deliveryMethod;
                order.Payment = payment;
                order.DestinationAddress = adress;
                order.OrderCommentary = commentary;
                order.Status = OrderStatuses.ORDERED;
                order.OrderCost *= (1 - discount);

                await ordersRepository.AddAsync(order);
            }
        }
    }
}
