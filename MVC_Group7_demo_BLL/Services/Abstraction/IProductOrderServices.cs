using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface IProductOrderServices
    {
        public Task<(bool, string)> CreateAsync(ProductOrderDTO ordersDTO);

        public Task<(bool, string?)> EditAsync(ProductOrderDTO orderDTO);

        public Task<(ProductOrderDTO?, string?)> GetByIdAsync(int id);

        public Task<(List<ProductOrderDTO>?, string?)> GetAllAsync();

        public Task<(bool, string?)> DeleteAsync(int id);
    }
}
