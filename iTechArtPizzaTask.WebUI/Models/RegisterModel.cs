using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace iTechArtPizzaTask.WebUI.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessage = "Email is required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "User First Name is required")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "User Last Name is required")]
        public string LastName { get; set; }
    }
}
