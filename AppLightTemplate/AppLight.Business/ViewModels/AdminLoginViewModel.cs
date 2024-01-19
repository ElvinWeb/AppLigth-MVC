using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Business.ViewModels
{
    public class AdminLoginViewModel
    {
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string Username { get; set; }
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 8)]
        public string Password { get; set; }
    }
}
