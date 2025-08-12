using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface IProductOrderRepo
    {
        Task<(List<ProductOrder>?, string?)> GetAll();
        Task<(ProductOrder?, string?)> GetById(int id);
        Task<(bool, string?)> Create(ProductOrder productOrder);
        Task<(bool, string?)> Update(int id, int qty, string modifiedBy);
        Task<(bool, string?)> Delete(int id, string deletedBy);

        Task<(bool, string?)> Reactivate(int id);
    }
}
