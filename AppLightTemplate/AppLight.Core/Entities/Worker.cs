using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Core.Entities
{
    public class Worker : BaseEntity
    {
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 5)]
        public string FullName { get; set; }
        [Required]
        [StringLength(maximumLength: 25, MinimumLength = 3)]
        public string Position { get; set; }
        [StringLength(maximumLength: 100, MinimumLength = 10)]
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
