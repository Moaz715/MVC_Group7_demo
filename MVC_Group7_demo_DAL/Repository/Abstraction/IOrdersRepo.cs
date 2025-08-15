using MVC_Group7_demo_DAL.Entities;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface IOrdersRepo
    {
        Task<(bool, string?)> CreateAsync(Orders order);

        Task<(bool, string?)> EditAsync(int id, double total, int cnt);

        Task<(Orders?, string?)> GetByIdAsync(int id);

        Task<(List<Orders>?, string?)> GetAllAsync();

        Task<(bool, string?)> DeleteAsync(int id);

        Task save();

        Task<(List<Orders>?, string?)> GetFinalizedOrders(string customerId);

        Task<(bool, string?)> FinalizeOrderAsync(string customerId, string paymentMethod, string loc);

    }
}
