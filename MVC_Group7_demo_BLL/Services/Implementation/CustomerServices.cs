using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using MVC_Group7_demo_DAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Implementation
{
    public class CustomerServices : ICustomerServices
    {

        private readonly ICustomerRepo customerRepo;

        public CustomerServices(ICustomerRepo customerRepo)
        {
            this.customerRepo = customerRepo;
        }

        public async Task<(bool, string?)> CreateAsync(CustomerDTO customerDTO)
        {
            try
            {
                


                var employee = new Customer(customerDTO.UserId, customerDTO.Name, customerDTO.Location, customerDTO.Name);
                var res = await customerRepo.Create(employee);
                Console.WriteLine("In services : " + res.Item1);
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine("In services ex : " + ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(CustomerDTO?, string?)> GetByIdAsync(string id)
        {
            try
            {
                var res = await customerRepo.GetById(id);

                if (res.Item1 == null)
                    return (null, "Customer not found");

                var customerEntity = res.Item1;

                List<OrdersDTO> ordersDTOs = new List<OrdersDTO>();

                foreach(var order in customerEntity.Orders)
                {
                    var productOrdersDTOs = new List<ProductOrderDTO>();
                    foreach (var po in order.ProductOrders)
                    {
                        productOrdersDTOs.Add(new ProductOrderDTO
                        {
                            ProductOrderId = po.ProductOrderId,
                            ProductId = po.Productid,
                            Quantity = po.Quantity
                        });
                    }

                    ordersDTOs.Add(new OrdersDTO
                    {
                        OrderId = order.Order_id,
                        TotalPrice = order.totalPrice,
                        NumOfItems = order.numOfItems,
                        CustomerId = order.Customer_id,
                        DeliveryId = order.Delivery_id,
                        ProductOrders = productOrdersDTOs
                    });
                }


                var customerDTO = new CustomerDTO
                {
                    UserId = res.Item1.UserId,
                    Name = res.Item1.Name,
                    Location = res.Item1.Location,
                    ordersDTOs = ordersDTOs
                };

                return (customerDTO, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }
    }

    
}
