using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class PizzasIngridient : BaseEntity
    {
        public Guid IngridientId { get; set; }
        public Ingridient Ingridient { get; set; }
        public Guid PizzaId { get; set; }
        public Pizza Pizza { get; set; }
    }
}
