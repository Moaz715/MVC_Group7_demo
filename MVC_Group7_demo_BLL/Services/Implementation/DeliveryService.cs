using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Implementation
{
    public class DeliveryService : IDeliveryService
    {
        private readonly IDeliveryRepo _deliveryRepo;

        public DeliveryService(IDeliveryRepo deliveryRepo)
        {
            _deliveryRepo = deliveryRepo;
        }

        public async Task<(List<DeliveryReadDTO>?, string?)> GetAvailableDeliveriesAsync()
        {
            var (deliveries, error) = await _deliveryRepo.GetAllAsync();
            if (error != null) return (null, error);

            var available = deliveries
                .Where(d => d.IsDeleted == false && d.status == "Available")
                .Select(d => new DeliveryReadDTO
                {
                    DeliveryId = d.Delivery_id,
                    Name = d.Name,
                    Phone = d.Phone,
                    Status = d.status,
                    Destination = d.Destination,
                    EstimatedTime = d.Estimated_time
                })
                .ToList();

            return (available, null);
        }

        public async Task<(List<DeliveryReadDTO>?, string?)> GetAllAsync()
        {
            var (deliveries, error) = await _deliveryRepo.GetAllAsync();
            if (error != null) return (null, error);

            var deliveryDtos = deliveries.Select(d => new DeliveryReadDTO
            {
                DeliveryId = d.Delivery_id,
                Name = d.Name,
                Phone = d.Phone,
                Status = d.status,
                Destination = d.Destination,
                EstimatedTime = d.Estimated_time,
                CreatedOn = d.CreatedOn,
                CreatedBy = d.CreatedBy,
                ModifiedOn = d.ModifiedOn,
                ModifiedBy = d.ModifiedBy
            }).ToList();

            return (deliveryDtos, null);
        }

        public async Task<(DeliveryReadDTO?, string?)> GetByIdAsync(int id)
        {
            var (delivery, error) = await _deliveryRepo.GetByIdAsync(id);
            if (error != null) return (null, error);
            if (delivery == null) return (null, "Delivery not found");

            var dto = new DeliveryReadDTO
            {
                DeliveryId = delivery.Delivery_id,
                Name = delivery.Name,
                Phone = delivery.Phone,
                Status = delivery.status,
                Destination = delivery.Destination,
                EstimatedTime = delivery.Estimated_time,
                CreatedOn = delivery.CreatedOn,
                CreatedBy = delivery.CreatedBy,
                ModifiedOn = delivery.ModifiedOn,
                ModifiedBy = delivery.ModifiedBy
            };
            return (dto, null);
        }

        public async Task<(bool, string?)> CreateAsync(DeliveryCreateDTO dto)
        {
            var delivery = new Delivery(
                delivery_id: 0, // Will be set by DB
                name: dto.Name,
                status: dto.Status,
                destination: dto.Destination,
                estimated_time: dto.EstimatedTime,
                createdBy: dto.CreatedBy,
                modifiedOn: null,
                modifiedBy: null
            );

            // This is not the preferred way to set optional properties.
            // Consider adding Phone to the constructor or using an object initializer.
            // For now, we fix it to call the entity's update method.
            delivery.UpdatePhone(dto.Phone, dto.CreatedBy);

            return await _deliveryRepo.CreateAsync(delivery);
        }

        public async Task<(bool, string?)> UpdateAsync(DeliveryUpdateDTO dto)
        {
            var (delivery, error) = await _deliveryRepo.GetByIdAsync(dto.DeliveryId);
            if (error != null) return (false, error);
            if (delivery == null) return (false, "Delivery not found");

            // --- THIS IS THE CORRECTED LOGIC ---
            // The Service Layer is responsible for mapping DTO to Entity
            if (!string.IsNullOrEmpty(dto.Name))
                delivery.UpdateName(dto.Name, dto.ModifiedBy);

            if (dto.Phone != null)
                delivery.UpdatePhone(dto.Phone, dto.ModifiedBy);

            if (dto.Status != null)
                delivery.UpdateStatus(dto.Status, dto.ModifiedBy);

            if (dto.Destination != null)
                delivery.UpdateDestination(dto.Destination, dto.ModifiedBy);

            if (dto.EstimatedTime.HasValue)
                delivery.UpdateEstimatedTime(dto.EstimatedTime.Value, dto.ModifiedBy);

            // Now call the repository to save the updated entity
            return await _deliveryRepo.UpdateAsync(delivery);
        }

        public async Task<(bool, string?)> DeleteAsync(int id, string deletedBy)
        {
            return await _deliveryRepo.DeleteAsync(id, deletedBy);
        }

        public async Task<(bool, string?)> RequestDeliveryAsync(int deliveryId, string requestedBy)
        {
            var (delivery, error) = await _deliveryRepo.GetByIdAsync(deliveryId);
            if (delivery == null) return (false, error ?? "Delivery not found");

            if (delivery.status.Equals("Requested", StringComparison.OrdinalIgnoreCase) ||
                delivery.status.Equals("Completed", StringComparison.OrdinalIgnoreCase))
            {
                return (false, "This delivery is already requested or completed.");
            }

            delivery.UpdateStatus("Requested", requestedBy);

            return await _deliveryRepo.UpdateAsync(delivery);
        }
    }
}