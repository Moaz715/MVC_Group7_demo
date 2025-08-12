using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Entities
{
    public class Cart
    {
        [Key]
        public int Cart_id { get; private set; }

        public int numOfItems { get; private set; }


        [Required, ForeignKey("Customer")]
        public string CustomerId { get; private set; }

        
        public Customer Customer { get; private set; }

        public List<ProductCart> ProductCarts { get; private set; } = new List<ProductCart>();


        [Required]
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        public string? CreatedBy { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        public string? ModifiedBy { get; private set; }

        public bool isDeleted { get; private set; } = false;

        public DateTime? DeletedOn { get; private set; }

        public string? DeletedBy { get; private set; }

        

        public void delete()
        {
            this.isDeleted = true;
            this.DeletedOn = DateTime.Now;

        }
    }
}
