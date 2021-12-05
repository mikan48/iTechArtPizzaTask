﻿using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Interfaces
{
    public interface IOrdersService
    {
        Task<List<Order>> GetAllAsync();
        Task AddAsync(Order order);
    }
}