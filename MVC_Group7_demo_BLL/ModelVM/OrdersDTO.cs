using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class OrdersDTO
    {
        public int OrderId { get; set; }

        public double TotalPrice { get; set; }

        public int NumOfItems { get; set; }

       
        public string CustomerId { get; set; } 

        public int? DeliveryId { get; set; }

        

        public List<ProductOrderDTO> ProductOrders { get; set; } = new List<ProductOrderDTO>();
    }
}
