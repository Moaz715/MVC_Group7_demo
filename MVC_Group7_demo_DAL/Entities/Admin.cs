using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Entities
{
    public class Admin
    {
        [Key]
        [ForeignKey("User")]
        public string UserId { get; private set; }

        public ApplicationUser User { get; private set; }
        [Required]
        public string Name { get; private set; }
        //public string Phone { get; private set; }
        //public string Email { get; private set; }
        //public string Password { get; private set; }
        public DateTime CreatedOn { get; private set; }
        public string CreatedBy { get; private set; }
        public DateTime? ModifiedOn { get; private set; }
        public string? ModifiedBy { get; private set; }
        public DateTime? DeletedOn { get; private set; }
        public string? DeletedBy { get; private set; }
        public bool? IsDeleted { get; private set; }
        public Admin(string userId, string name, string createdBy)
        {
            UserId = userId;
            Name = name;
            CreatedOn = DateTime.Now;   
            CreatedBy = createdBy;
            IsDeleted = false;
        }
        public void Delete(string id, string? deletedBy)
        {
            IsDeleted = true;
            DeletedOn = DateTime.Now;
            DeletedBy = deletedBy;
        }
        public void UpdateName(string name, string modifiedBy)
        {
            Name = name;
            ModifiedOn = DateTime.Now;
            ModifiedBy = modifiedBy;
        }
    }
}
