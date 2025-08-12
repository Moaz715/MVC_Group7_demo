using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class ReadProductDto
    {

        public int ProductId { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public string? Image { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string CategoryName { get; set; }
        public DateTime? CreatedOn { get; set; }
    }
}
