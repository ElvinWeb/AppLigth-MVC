using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Core.Entities
{
    public class User : IdentityUser
    {
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 5)]
        public string FullName { get; set; }
    }
}
