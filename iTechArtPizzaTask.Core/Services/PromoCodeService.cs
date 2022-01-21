using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class PromoCodeService : IService<PromoCode>
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

        public Task UpdateAsync(PromoCode item)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(PromoCode item)
        {
            throw new NotImplementedException();
        }

        public async Task<PromoCode> FindItemByNameAsync(string name)
        {
            return await repository.FindItemByNameAsync(name);
        }

        public Task<PromoCode> FindItemByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
