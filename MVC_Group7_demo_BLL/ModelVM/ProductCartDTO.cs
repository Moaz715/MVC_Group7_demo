using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class ProductCartDTO
    {
        public int ProductCartId { get; set; }
        public int ProductId { get; set; }

        public string ProductName { get; set; }
        public double UnitPrice { get; set; }
        public string? ProductImage { get; set; }

       
    }
}
