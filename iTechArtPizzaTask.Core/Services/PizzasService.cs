﻿using iTechArtPizzaTask.Core.Interfaces;
using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Services
{
    public class PizzasService : IPizzasService
    {
        private readonly IPizzasRepository pizzasRepository;
        public PizzasService(IPizzasRepository pizzasRepository)
        {
            this.pizzasRepository = pizzasRepository ?? throw new ArgumentNullException(nameof(pizzasRepository));
        }
        public async Task<List<Pizza>> GetAllAsync()
        {
            return await pizzasRepository.GetAllAsync();
        }
    }
}