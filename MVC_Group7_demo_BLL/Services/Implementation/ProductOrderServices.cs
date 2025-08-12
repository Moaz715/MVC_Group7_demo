using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Implementation
{
    public class ProductOrderServices : IProductOrderServices
    {

        
        private readonly IProductOrderRepo productOrderRepo;

        public ProductOrderServices(IProductOrderRepo productOrderRepo)
        {
            
            this.productOrderRepo = productOrderRepo;
        }
        public Task<(bool, string)> CreateAsync(ProductOrderDTO ordersDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string?)> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<(bool, string?)> EditAsync(ProductOrderDTO orderDTO)
        {
            throw new NotImplementedException();
        }

        public Task<(List<ProductOrderDTO>?, string?)> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<(ProductOrderDTO?, string?)> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }
    }
}
