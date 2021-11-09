using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public OrderStatuses Status { get; set; }
        [Column(TypeName = "money")]
        public int OrderCost { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderPizza> Pizzas { get; set; }
    }
}
