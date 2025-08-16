using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Abstraction
{
    public interface IDeliveryService
    {
        // Public/customer facing
        Task<(List<DeliveryReadDTO>?, string?)> GetAvailableDeliveriesAsync();
        Task<(DeliveryReadDTO?, string?)> GetByIdAsync(int id);

        // Admin operations
        Task<(bool, string?)> CreateAsync(DeliveryCreateDTO dto);
        Task<(bool, string?)> UpdateAsync(DeliveryUpdateDTO dto);
        Task<(bool, string?)> DeleteAsync(int id, string deletedBy);

        // For listing all deliveries (admin only)
        Task<(List<DeliveryReadDTO>?, string?)> GetAllAsync();

        Task<(bool, string?)> RequestDeliveryAsync(int deliveryId, string requestedBy);


    }
}
