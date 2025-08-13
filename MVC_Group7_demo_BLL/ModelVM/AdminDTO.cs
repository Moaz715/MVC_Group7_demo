using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class AdminDTO
    {
        public string UserId { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Admin name is required")]
        public string Name { get; set; } = string.Empty;
        
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; } = string.Empty;
        public DateTime? ModifiedOn { get; set; }
        public string? ModifiedBy { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string? DeletedBy { get; set; }
        public bool? IsDeleted { get; set; }
        
        public AdminDTO()
        {
            CreatedOn = DateTime.Now;
            IsDeleted = false;
        }
        
        public AdminDTO(string userId, string name)
        {
            UserId = userId;
            Name = name;
            CreatedOn = DateTime.Now;
            IsDeleted = false;
        }
    }
}
