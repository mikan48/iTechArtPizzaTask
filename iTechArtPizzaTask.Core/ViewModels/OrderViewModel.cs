using iTechArtPizzaTask.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.ViewModels
{
    public class OrderViewModel
    {
        public OrderStatuses Status { get; set; }
        public double OrderCost { get; set; }
        public string DestinationAddress { get; set; }
    }
}
