using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class CreateProductDto
    {
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public string CreatedBy { get; set; }
        public IFormFile? File { get; set; }
    }
}
