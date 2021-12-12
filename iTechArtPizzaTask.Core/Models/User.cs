using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.Core.Models
{
    public class User : IdentityUser<Guid>
    {
        public string Name { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}
