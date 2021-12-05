using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class OrderedPizza : BaseEntity
    {
        public Guid PizzaId { get; set; }
        public Pizza Pizza { get; set; }
        public int Quantity { get; set; }
    }
}
