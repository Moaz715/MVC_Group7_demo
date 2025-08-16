// In MVC_Group7_demo-BLL/ModelVM/DeliveryCreateDTO.cs
using System;
using System.ComponentModel.DataAnnotations;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class DeliveryCreateDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;

        
        public string Status { get; set; } = string.Empty;

        [Required]
        public string Destination { get; set; } = string.Empty;

        [Required]
        public DateTime EstimatedTime { get; set; }

        // REMOVE [Required] FROM THIS PROPERTY
        public string CreatedBy { get; set; } = string.Empty;
    }
}