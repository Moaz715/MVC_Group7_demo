using MVC_Group7_demo_BLL.ModelVM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface ICustomerServices
    {
        public Task<(bool, string?)> CreateAsync(CustomerDTO customerDTO);
    }
}
