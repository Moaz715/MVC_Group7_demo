using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class DeliveryUpdateDTO
    {
        [Required]
        public int DeliveryId { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public string? Phone { get; set; }

        public string? Status { get; set; }

        public string? Destination { get; set; }

        public DateTime? EstimatedTime { get; set; }

        
        public string ModifiedBy { get; set; } = string.Empty;
    }
}
