using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class PromoCode
    {
        public int PromoCodeId { get; set;}
        public double Discount { get; set; }
        public int OrderId { get; set; }  
        public Order Order { get; set; }
    }
}
