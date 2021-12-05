using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class PromoCodeService : IPromoCodeService
    {
        private readonly IRepository<PromoCode> repository;
        public PromoCodeService(IRepository<PromoCode> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task<List<PromoCode>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
        public async Task AddAsync(PromoCode promoCode)
        {
            await repository.AddAsync(promoCode);
        }
    }
}
