using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface IOrdersServices
    {
        public Task<(bool, string)> CreateAsync(OrdersDTO ordersDTO);

        public Task<(bool, string?)> EditAsync(OrdersDTO orderDTO);

        public Task<(Orders?, string?)> GetByIdAsync(int id);

        public Task<(List<Orders>?, string?)> GetAllAsync();

        public Task<(bool, string?)> DeleteAsync(int id);

        public Task<(bool, string?)> AddProductOrderAsync(AddProductToOrderDTO readProduct, string customerId);

        public Task<(OrdersDTO?, string?)> GetCurrentOrder(string customerId);

        public  Task<(bool, string?)> ApplyChanges(OrderEditDTO orderEditDTO, string customerId);

        public  Task<(List<FinalizedOrder>?, string?)> GetFinalizedOrders(string customerId);

        public Task<(bool, string?)> finalizeOrderAsync(string customerId, string paymentMethod);

        public Task<(bool, string?)> CancelOrder(int id);
    }
}
