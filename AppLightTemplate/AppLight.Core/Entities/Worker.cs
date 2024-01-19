using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLight.Core.Entities
{
    public class Worker : BaseEntity
    {
        public string FullName { get; set; }
        public string Position { get; set; }
        public string? ImgUrl { get; set; }
        [NotMapped]
        public IFormFile Image { get; set; }

    }
}
