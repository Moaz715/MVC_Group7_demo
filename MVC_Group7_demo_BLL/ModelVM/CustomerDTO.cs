using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class CustomerDTO
    {
        public string UserId { get; set; }

        public string Name { get; set; }

        public string Location { get;  set; }

        public List<OrdersDTO>? ordersDTOs { get; set; }
    }
}
