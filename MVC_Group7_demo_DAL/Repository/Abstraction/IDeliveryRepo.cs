using MVC_Group7_demo_DAL.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface IDeliveryRepo
    {
        Task<(List<Delivery>, string?)> GetAllAsync();
        Task<(Delivery?, string?)> GetByIdAsync(int id);
        Task<(bool, string?)> CreateAsync(Delivery delivery);
        Task<(bool, string?)> UpdateAsync(Delivery delivery); // Changed from specific fields
        Task<(bool, string?)> DeleteAsync(int id, string deletedBy);
    }
}