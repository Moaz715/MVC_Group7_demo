using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using MVC_Group7_demo_DAL.Repository.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MVC_Group7_demo_BLL.Services.Implementation
{
    public class CartServices : ICartServices
    {
        private readonly ICartRepo cartRepo;
        private readonly ICustomerRepo customerRepo;
        private readonly IProductCartRepo productCartRepo;
        private readonly IProductRepo productRepo;

        public CartServices(ICartRepo cartRepo, ICustomerRepo customerRepo, IProductCartRepo productCartRepo, IProductRepo productRepo)
        {
            this.cartRepo = cartRepo;
            this.customerRepo = customerRepo;
            this.productCartRepo = productCartRepo;
            this.productRepo = productRepo;
        }

        public async Task<(bool, string?)> AddProductToCartAsync(AddProductToCartDTO readproduct, string customerId)
        {
            var customerResult = await customerRepo.GetById(customerId);
            if (customerResult.Item1 == null)
                return (false, "Customer not found");

            string createdBy = customerResult.Item1.Name;

            var res = await cartRepo.GetAllAsync();

            if(res.Item1 == null)
            {
                Console.WriteLine("error in first if");
                return(false, "error in first if") ;
            }

            var cart = res.Item1.Where(c => c.CustomerId == customerId).FirstOrDefault();

            if(cart == null)
            {
                var newCart = new Cart(0, customerId, createdBy);
                var createRes = await cartRepo.CreateAsync(newCart);

                if(createRes.Item1 == false)
                {
                    return (false, "failed to create");
                }

               
            }

            var productRes = await productRepo.GetByIdAsync(readproduct.ProductId);
            if (productRes.Item1 == null)
            {
                //Console.WriteLine("dsadasd : " + readProduct.ProductId);
                return (false, "Product not found");
            }

            var product = productRes.Item1;

            var existingPC = cart.ProductCarts.FirstOrDefault(po => po.Productid == product.ProductId);

            if(existingPC == null)
            {
                var newPC = new ProductCart(cart.Cart_id, product.ProductId, createdBy);

                var createRes2 = await productCartRepo.Create(newPC);

                cart = (await cartRepo.GetByIdAsync(cart.Cart_id)).Item1;

            }else if (existingPC.isDeleted)
            {
                var ReactRes = await productCartRepo.Reactivate(existingPC.ProductCartId);
            }

            return (true, null);
        }

        public async Task<(bool, string?)> Delete(int id)
        {
            try
            {
                var res1 = await cartRepo.DeleteAsync(id);
                return res1;
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string) Create()
        {
            throw new NotImplementedException();
        }

        public (bool, string) Edit()
        {
            throw new NotImplementedException();
        }

        public (List<Cart>, string?) GetAll()
        {
            throw new NotImplementedException();
        }

        public (Cart, string) GetById(int id)
        {
            throw new NotImplementedException();
        }
    }
}
