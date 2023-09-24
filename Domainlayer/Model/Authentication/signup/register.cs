using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domainlayer.Model.Authentication.signup
{
    public class register
    {
        [Required(ErrorMessage ="Username is required")]
        public string? Username { get; set;}

        [EmailAddress]
        [Required(ErrorMessage = "Email is required")]
        public string? Email { get; set;}

        [Required(ErrorMessage = "password is required")]
        public string? Password { get; set;}
    }
}
