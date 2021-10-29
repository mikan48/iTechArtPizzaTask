using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public enum OrderStatuses
    {
        INCOMPLETE, //pizzas in cart, not ordered
        ORDERED,
        INPROCESS,
        DELIVERED
    }
}
