using iTechArtPizzaTask.Core.Models;
using iTechArtPizzaTask.Infrastructure.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Infrastructure.Repositories
{
    public class PizzasRepository
    {
        private readonly PizzaDeliveryContext context;
        public List<Pizza> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
