using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using System.Threading.Tasks;

namespace MVC_Group7_demo_PLL.Controllers
{
    [Authorize]
    public class DeliveryController : Controller
    {
        private readonly IDeliveryService _deliveryService;

        public DeliveryController(IDeliveryService deliveryService)
        {
            _deliveryService = deliveryService;
        }

        // A helper method to get the current logged-in user's name (or email)
        private string GetCurrentUserName() => User.Identity?.Name ?? "system_user";

        // GET: Delivery/Index
        public async Task<IActionResult> Index()
        {
            var (deliveries, errorMessage) = await _deliveryService.GetAllAsync();
            if (!string.IsNullOrEmpty(errorMessage))
            {
                TempData["Error"] = errorMessage;
            }
            return View(deliveries);
        }

        // GET: Delivery/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Delivery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(DeliveryCreateDTO deliveryDto)
        {
            if (!ModelState.IsValid)
            {
                return View(deliveryDto);
            }

            // --- ADD THESE TWO LINES ---
            deliveryDto.CreatedBy = GetCurrentUserName();
            deliveryDto.Status = "Pending"; // Set the default status here!

            var (isCreated, errorMessage) = await _deliveryService.CreateAsync(deliveryDto);

            if (!isCreated)
            {
                ModelState.AddModelError("", errorMessage ?? "Failed to create delivery.");
                return View(deliveryDto);
            }

            TempData["Success"] = "Delivery created successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Delivery/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var (delivery, error) = await _deliveryService.GetByIdAsync(id);
            if (delivery == null)
            {
                return NotFound(error ?? "Delivery not found.");
            }

            // Map the Read DTO to an Update DTO for the form
            var updateDto = new DeliveryUpdateDTO
            {
                DeliveryId = delivery.DeliveryId,
                Name = delivery.Name,
                Phone = delivery.Phone,
                Status = delivery.Status,
                Destination = delivery.Destination,
                EstimatedTime = delivery.EstimatedTime
            };
            return View(updateDto);
        }

        // POST: Delivery/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, DeliveryUpdateDTO deliveryDto)
        {
            if (id != deliveryDto.DeliveryId)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return View(deliveryDto);
            }

            deliveryDto.ModifiedBy = GetCurrentUserName(); // Set the modifier automatically

            var (isUpdated, error) = await _deliveryService.UpdateAsync(deliveryDto);

            if (!isUpdated)
            {
                ModelState.AddModelError("", error ?? "Failed to update delivery.");
                return View(deliveryDto);
            }

            TempData["Success"] = "Delivery updated successfully!";
            return RedirectToAction(nameof(Index));
        }

        // GET: Delivery/Delete/5
        public async Task<IActionResult> Delete(int id)
        {
            var (delivery, error) = await _deliveryService.GetByIdAsync(id);
            if (delivery == null)
            {
                return NotFound(error ?? "Delivery not found.");
            }
            return View(delivery);
        }

        // POST: Delivery/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var deletedBy = GetCurrentUserName();
            var (isDeleted, error) = await _deliveryService.DeleteAsync(id, deletedBy);

            if (!isDeleted)
            {
                TempData["Error"] = error ?? "Failed to delete delivery.";
            }
            else
            {
                TempData["Success"] = "Delivery has been successfully deleted.";
            }
            return RedirectToAction(nameof(Index));
        }
    }
}