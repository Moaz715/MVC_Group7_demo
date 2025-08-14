using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class CartDTO
    {
        public int Cart_id { get;  set; }

        public int numOfItems { get;  set; }

       

        public List<ProductCartDTO> ProductCart { get; set; } = new List<ProductCartDTO>();
    }
}
