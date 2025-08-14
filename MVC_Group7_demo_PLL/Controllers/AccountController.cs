using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using MVC_Group7_demo_BLL.Services.Implementation;
using MVC_Group7_demo_DAL.Entities;

namespace MVC_Group7_demo_PLL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICustomerServices customerServices;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly IAdminServices adminServices;
        private readonly IEmailSender emailSender;

        public AccountController(UserManager<ApplicationUser> userManager,
                         ICustomerServices customerServices,
                         SignInManager<ApplicationUser> signInManager,
                         IEmailSender emailSender, IAdminServices adminServices)
        {
            this.userManager = userManager;
            this.customerServices = customerServices;
            this.signInManager = signInManager;
            this.emailSender = emailSender;
            this.adminServices = adminServices;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> SignUp(RegisterVM registerVM)
        {
            //if (!ModelState.IsValid)
            //{
             //   return View("Index", registerVM);
            //}

            var user = new ApplicationUser
            {
                UserName = registerVM.Email,
                Email = registerVM.Email,
                PhoneNumber = registerVM.Phone,
                //EmailConfirmed = true
            };

            var res = await userManager.CreateAsync(user, registerVM.Password);

            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                    Console.WriteLine("" + error.Description);
                return View("Index", registerVM);
            }

            await userManager.AddToRoleAsync(user, "Customer");


            // Create the confirmation token
            var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

            // Generate a confirmation link
            var confirmationLink = Url.Action(nameof(ConfirmEmail), "Account",
                new { userId = user.Id, token = token }, Request.Scheme);

            // Send the email
            await emailSender.SendEmailAsync(user.Email, "Confirm your account",
                $"Please confirm your account by <a href='{confirmationLink}'>clicking here</a>.");




            var cusDTO = new CustomerDTO
            {
                UserId = user.Id,
                Name = registerVM.Name,
                Location = registerVM.Location
            };

            await customerServices.CreateAsync(cusDTO);


            return RedirectToAction("LoginPage");
        }


        //[Authorize(Roles = "Admin")]
        [HttpGet]
        public IActionResult RegisterAdmin()
        {
            return View();
        }

        //[Authorize(Roles = "Admin")]
        [HttpPost]
        public async Task<IActionResult> RegisterAdmin(RegisterAVM registerAVM)
        {
            if (!ModelState.IsValid)
            {
                return View("RegisterAdmin", registerAVM);
            }

            var user = new ApplicationUser
            {
                UserName = registerAVM.Email,
                Email = registerAVM.Email,
                EmailConfirmed = true
            };

            var res = await userManager.CreateAsync(user, registerAVM.Password);

            if (!res.Succeeded)
            {
                foreach (var error in res.Errors)
                    Console.WriteLine("" + error.Description);
                return View("RegisterAdmin", registerAVM);
            }

            await userManager.AddToRoleAsync(user, "Admin");



            var adminDTO = new AdminDTO
            {
                UserId = user.Id,
                Name = registerAVM.Name
            };

            await adminServices.CreateAsync(adminDTO);


            return RedirectToAction("Index", "Admin");
        }

        [HttpGet]
        public async Task<IActionResult> ConfirmEmail(string userId, string token)
        {
            if (userId == null || token == null)
            {
                return RedirectToAction("Index", "Home");
            }

            var user = await userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return NotFound("User not found");
            }

            var result = await userManager.ConfirmEmailAsync(user, token);

            if (result.Succeeded)
            {
                return View("ConfirmEmail");
            }
            else
            {
                return View("Error");
            }
        }



        [HttpGet]
        public async Task<IActionResult> LoginPage()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInVm model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var user = await userManager.FindByEmailAsync(model.Email);
            if (user == null)
            {
                ModelState.AddModelError("", "Invalid login attempt.");
                return View("LoginPage", model);
            }

            var result = await signInManager.PasswordSignInAsync(
                user.UserName,  
                model.Password,
                false,
                lockoutOnFailure: false
            );

            if (result.Succeeded)
            {
                var roles = await userManager.GetRolesAsync(user);

                if (roles.Contains("Admin"))
                {
                    return RedirectToAction("Index", "Admin");

                }else if (roles.Contains("Customer"))
                {
                    return RedirectToAction("GetAll", "Product");
                }
                    
            }

            ModelState.AddModelError("", "Invalid login attempt.");
            return View("LoginPage",model);
        }

        [Authorize]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("LoginPage");
        }

        [HttpGet]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            Response.Cookies.Append(
                CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions { Expires = DateTimeOffset.UtcNow.AddYears(1) }
            );

            return LocalRedirect(returnUrl);
        }
    }
}
