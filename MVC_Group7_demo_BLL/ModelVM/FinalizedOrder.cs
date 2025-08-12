using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class FinalizedOrder
    {
        public int OrderId { get; set; }

        public double TotalPrice { get; set; }

        public int NumOfItems { get; set; }


        public string CustomerLocation { get; set; }

        public string DeliveryName { get; set; }

        public DateTime? FinalizedOn { get; set; }

        public string PaymentMethod { get; set; }
    }
}
