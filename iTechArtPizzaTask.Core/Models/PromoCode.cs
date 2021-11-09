using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class PromoCode
    {
        [Key]
        public int PromoCodeId { get; set;}
        public double Discount { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
