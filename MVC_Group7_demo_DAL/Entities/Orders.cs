using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Entities
{
    public class Orders
    {
        [Key]
        public int Order_id { get; private set; }

        public double totalPrice { get; private set; }

        public int numOfItems { get; private set; }

        

        [ForeignKey("customer")]
        public string Customer_id { get; private set; }

        public Customer customer { get; private set; }

        [ForeignKey("delivery")]
        public int? Delivery_id { get; private set; }

        public Delivery delivery { get; private set; }

        public List<ProductOrder> ProductOrders { get; private set; } = new List<ProductOrder>();

        [Required]
        public DateTime CreatedOn { get; private set; } = DateTime.Now;

        public string? CreatedBy { get; private set; }

        public DateTime? ModifiedOn { get; private set; }

        public string? ModifiedBy { get; private set; }

        public bool isDeleted { get; private set; } = false;

        public DateTime? DeletedOn { get; private set; }

        public string? DeletedBy { get; private set; }

        public bool isFinalized { get; private set; } = false;

        public DateTime? finalizedOn { get; private set; }

        public string? paymentMethod { get; private set; }

        public Orders(double totalPrice, int numOfItems, string customer_id, string? createdBy, int? delivery_id, List<ProductOrder> productOrders)
        {
            
            this.totalPrice = totalPrice;
            this.numOfItems = numOfItems;
            this.Customer_id = customer_id;
            Delivery_id = delivery_id;
            ProductOrders = productOrders;
            this.CreatedOn = DateTime.Now;
            this.CreatedBy = createdBy;
        }

        public Orders()
        {

        }

        public void delete(string deletedBy)
        {
            this.isDeleted = true;
            this.DeletedOn = DateTime.Now;
            this.DeletedBy = deletedBy;
            if (ProductOrders != null)
            {
                foreach (var po in ProductOrders)
                {
                    po.delete(deletedBy);
                }
            }

        }

        public void edit(double totalprice, int num, string modifiedBy)
        {
            this.totalPrice = totalprice;
            this.numOfItems = num;
            this.ModifiedBy = modifiedBy;
            this.ModifiedOn = DateTime.Now;
        }

        public void finalize(string paymentMethod)
        {
            this.isFinalized = true;
            this.finalizedOn = DateTime.Now;
            this.paymentMethod = paymentMethod;
        }
    }
}
