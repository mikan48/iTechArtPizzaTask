﻿using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class OrdersService : IOrdersService
    {
        private readonly IRepository<Order> repository;
        public OrdersService(IRepository<Order> repository)
        {
            this.repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }
        public async Task AddAsync(Order order)
        {
            await repository.AddAsync(order);
        }

        public async Task<List<Order>> GetAllAsync()
        {
            return await repository.GetAllAsync();
        }
    }
}