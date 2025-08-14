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
    [Authorize(Roles ="Customer")]
    public class CartController : Controller
    {
        private readonly IProductService productService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ICartServices cartServices;

        public CartController(IProductService productService, UserManager<ApplicationUser> userManager, ICartServices cartServices)
        {
            this.productService = productService;
            this.userManager = userManager;
            this.cartServices = cartServices;
        }
        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> GetCart()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                TempData["Error"] = "You must be logged in to view Cart.";
                return RedirectToAction("Login", "Account");
            }

            var res = await cartServices.GetCart(user.Id);

            return View(res.Item1);
        }

        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var res = await cartServices.RemoveProductCart(id);

            if(res.Item1 == false)
            {
                return RedirectToAction("Index", "Home");
            }

            return View("GetCart");
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                TempData["Error"] = "You must be logged in to add products to your Cart.";
                return RedirectToAction("Login", "Account");
            }

            //Console.WriteLine("In Controller : " + user.Id);

            var res = await cartServices.AddProductToCartAsync(id, user.Id);

            if (!res.Item1)
                TempData["Error"] = res.Item2;
            else
                TempData["Success"] = "Product added to order!";

            return RedirectToAction("GetAll", "Product");
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
