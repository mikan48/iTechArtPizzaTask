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
    public class PromoCodeRepository : IRepository<PromoCode>
    {
        private readonly PizzaDeliveryContext context;
        public PromoCodeRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(PromoCode promoCode)
        {
            if (context.PromoCodes.Where(b => b.Code == promoCode.Code).Count() == 0)
            {
                await context.PromoCodes.AddAsync(promoCode);
                await context.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(PromoCode item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<PromoCode>> GetAllAsync()
        {
            return await context.PromoCodes.ToListAsync();
        }
        public Task UpdateAsync(PromoCode item)
        {
            throw new NotImplementedException();
        }
    }
}
