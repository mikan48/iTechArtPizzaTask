using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class PromoCode : BaseEntity
    {
        [Required(ErrorMessage = "Please enter the code")]
        public string Code { get; set; }

        [Required(ErrorMessage = "Promo code must have a discount")]
        public double Discount { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime StartDate { get; set; }

        [Column(TypeName = "smalldatetime")]
        public DateTime EndDate { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
