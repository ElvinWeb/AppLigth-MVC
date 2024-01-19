using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Core.Entities
{
    public class Setting : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string? Key { get; set; }
        [Required]
        [StringLength(maximumLength: 30, MinimumLength = 10)]
        public string Value { get; set; }
    }
}
