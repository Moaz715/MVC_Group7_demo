using Microsoft.AspNetCore.Mvc;
using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;

namespace MVC_Group7_demo_PLL.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminServices adminServices;

        public AdminController(IAdminServices adminServices)
        {
            this.adminServices = adminServices;
        }

        // GET: Admin
        public async Task<IActionResult> Index()
        {
            try
            {
                var (admins, error) = await adminServices.GetAllAsync();
                
                if (error != null)
                {
                    ViewBag.Error = error;
                    return View(new List<AdminDTO>());
                }
                
                return View(admins);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred while loading admins: " + ex.Message;
                return View(new List<AdminDTO>());
            }
        }

        // GET: Admin/Details
        public async Task<IActionResult> Details(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var (admin, error) = await adminServices.GetByIdAsync(id);
                
                if (error != null || admin == null)
                {
                    ViewBag.Error = error ?? "Admin not found";
                    return NotFound();
                }

                return View(admin);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return NotFound();
            }
        }

        // GET: Admin/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("UserId,Name")] AdminDTO adminDTO)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    adminDTO.CreatedBy = User.Identity?.Name ?? "system";
                    adminDTO.CreatedOn = DateTime.Now;
                    adminDTO.IsDeleted = false;
                    
                    var (success, error) = await adminServices.CreateAsync(adminDTO);
                    
                    if (success)
                    {
                        TempData["Success"] = "Admin created successfully!";
                        return RedirectToAction(nameof(Index));
                    }
                    
                    ModelState.AddModelError("", error ?? "Error creating admin");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
            }
            
            return View(adminDTO);
        }

        // GET: Admin/Edit
        public async Task<IActionResult> Edit(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var (admin, error) = await adminServices.GetByIdAsync(id);
                
                if (error != null || admin == null)
                {
                    ViewBag.Error = error ?? "Admin not found";
                    return NotFound();
                }

                return View(admin);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return NotFound();
            }
        }

        // POST: Admin/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("UserId,Name")] AdminDTO adminDTO)
        {
            if (id != adminDTO.UserId)
            {
                return NotFound();
            }

            try
            {
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
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "An error occurred: " + ex.Message);
            }
            
            return View(adminDTO);
        }

        // GET: Admin/Delete
        public async Task<IActionResult> Delete(string id)
        {
            if (string.IsNullOrEmpty(id))
            {
                return NotFound();
            }

            try
            {
                var (admin, error) = await adminServices.GetByIdAsync(id);
                
                if (error != null || admin == null)
                {
                    ViewBag.Error = error ?? "Admin not found";
                    return NotFound();
                }

                return View(admin);
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return NotFound();
            }
        }

        // POST: Admin/Delete
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            try
            {
                var deletedBy = User.Identity?.Name ?? "system";
                var (success, error) = await adminServices.DeleteAsync(id, deletedBy);
                
                if (success)
                {
                    TempData["Success"] = "Admin deleted successfully!";
                    return RedirectToAction(nameof(Index));
                }
                
                ViewBag.Error = error ?? "Error deleting admin";
                return View();
            }
            catch (Exception ex)
            {
                ViewBag.Error = "An error occurred: " + ex.Message;
                return View();
            }
        }
    }
} 