﻿using iTechArtPizzaTask.Core.Interfaces;
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
    public class IngridientsRepository : IRepository<Ingridient>
    {
        private readonly PizzaDeliveryContext context;
        public IngridientsRepository(PizzaDeliveryContext context)
        {
            this.context = context;
        }

        public async Task AddAsync(Ingridient ingridient)
        {
            if(context.Ingridients.Where(b => b.IngridientName == ingridient.IngridientName).Count() == 0)
            {
                await context.Ingridients.AddAsync(new Ingridient { IngridientName = ingridient.IngridientName });
                await context.SaveChangesAsync();
            }
        }

        public Task DeleteAsync(Ingridient item)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Ingridient>> GetAllAsync()
        {
            return await context.Ingridients.ToListAsync();
        }

        public Task UpdateAsync(Ingridient item)
        {
            throw new NotImplementedException();
        }
    }
}
