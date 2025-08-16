using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MVC_Group7_demo_PLL.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly IAdminServices adminServices;
        private readonly IDeliveryService deliveryService; // Injected dependency

        public AdminController(IAdminServices adminServices, IDeliveryService deliveryService)
        {
            this.adminServices = adminServices;
            this.deliveryService = deliveryService; // Initialize it
        }

        // GET: Admin/Index
        public async Task<IActionResult> Index()
        {
            var (admins, error) = await adminServices.GetAllAsync();
            if (error != null) ViewBag.Error = error;
            return View(admins ?? new List<AdminDTO>());
        }

        // GET: Admin/ViewAllDeliveries
        [HttpGet]
        public async Task<IActionResult> ViewAllDeliveries()
        {
            ViewData["Title"] = "All System Deliveries";
            var (deliveries, error) = await deliveryService.GetAllAsync();

            if (error != null)
            {
                TempData["Error"] = error;
                return View(new List<DeliveryReadDTO>());
            }

            return View(deliveries);
        }

        // --- All your other Admin CRUD actions remain below ---

        // GET: Admin/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var (admin, error) = await adminServices.GetByIdAsync(id);
            if (error != null || admin == null) return NotFound(error ?? "Admin not found");
            return View(admin);
        }

        // GET: Admin/Create
        public IActionResult Create() => View();

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name")] AdminDTO adminDTO)
        {
            if (ModelState.IsValid)
            {
                adminDTO.CreatedBy = User.Identity?.Name ?? "system";
                adminDTO.CreatedOn = DateTime.Now;
                var (success, error) = await adminServices.CreateAsync(adminDTO);
                if (success)
                {
                    TempData["Success"] = "Admin created successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", error ?? "Error creating admin");
            }
            return View(adminDTO);
        }

        // GET: Admin/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var (admin, error) = await adminServices.GetByIdAsync(id);
            if (error != null || admin == null) return NotFound(error ?? "Admin not found");
            return View(admin);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,Name")] AdminDTO adminDTO)
        {
            if (id != adminDTO.UserId) return NotFound();
            if (ModelState.IsValid)
            {
                var modifiedBy = User.Identity?.Name ?? "system";
                var (success, error) = await adminServices.UpdateAsync(id, adminDTO.Name, modifiedBy);
                if (success)
                {
                    TempData["Success"] = "Admin updated successfully!";
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", error ?? "Error updating admin");
            }
            return View(adminDTO);
        }

        // GET: Admin/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id)) return NotFound();
            var (admin, error) = await adminServices.GetByIdAsync(id);
            if (error != null || admin == null) return NotFound(error ?? "Admin not found");
            return View(admin);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var deletedBy = User.Identity?.Name ?? "system";
            var (success, error) = await adminServices.DeleteAsync(id, deletedBy);
            if (success)
            {
                TempData["Success"] = "Admin deleted successfully!";
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Error = error ?? "Error deleting admin";
            // Must refetch the model to display the page again on failure
            var (admin, getError) = await adminServices.GetByIdAsync(id);
            if (admin == null) return RedirectToAction(nameof(Index));
            return View(admin);
        }
    }
}