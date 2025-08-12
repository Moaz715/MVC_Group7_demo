using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface IDeliveryRepo
    {
        Task<(List<Delivery>, string?)> GetAllAsync();
        Task<(Delivery?, string?)> GetByIdAsync(int id);
        Task<(bool, string?)> CreateAsync(Delivery delivery);
        Task<(bool, string?)> UpdateAsync(int id, string name, string modifiedBy);
        Task<(bool, string?)> DeleteAsync(int id, string deletedBy);
    }
}
