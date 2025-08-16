using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class DeliveryReadDTO
    {
        public int DeliveryId { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Status { get; set; } = string.Empty;
        public string Destination { get; set; } = string.Empty;
        public DateTime EstimatedTime { get; set; }
        public DateTime? CreatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
    }
}
