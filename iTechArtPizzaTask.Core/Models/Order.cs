using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class Order : BaseEntity
    {
        [Column(TypeName = "tinyint")]
        public OrderStatuses Status { get; set; }
        [Column(TypeName = "tinyint")]
        public DeliveryMethod DeliveryMethod { get; set; }
        [Column(TypeName = "tinyint")]
        public Payment Payment { get; set; }
        [Column(TypeName = "money")]
        public double OrderCost { get; set; }
        public string DestinationAddress { get; set; }
        public string OrderCommentary { get; set; }
        public Guid UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderedPizza> OrderedPizzas { get; set; }
    }
}
