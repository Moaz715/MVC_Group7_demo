using Microsoft.EntityFrameworkCore;
using MVC_Group7_demo_DAL.DataBase;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Implementation
{
    public class ProductCartRepo : IProductCartRepo
    {
        private readonly Context db;

        public ProductCartRepo(Context db)
        {
            this.db = db;
        }
        public async Task<(bool, string?)> Create(ProductCart productCart)
        {
            try
            {
                await db.productCarts.AddAsync(productCart);
                await db.SaveChangesAsync();
                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> Delete(int id, string deletedBy)
        {
            try
            {
                var res = await db.productCarts.Where(po => po.ProductCartId == id).FirstOrDefaultAsync();

                if (res == null)
                {
                    return (false, "Does not exist");
                }

                res.delete(deletedBy);
                await db.SaveChangesAsync();
                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> Reactivate(int id)
        {
            try
            {
                var res = await db.productCarts.Where(po => po.ProductCartId == id).FirstOrDefaultAsync();

                if (res == null)
                {
                    return (false, "Does not exist");
                }

                res.reactivate();
                await db.SaveChangesAsync();

                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (List<ProductCart>?, string?) GetAll()
        {
            try
            {
                var res = db.productCarts.ToList();

                if (res == null || res.Count == 0)
                {
                    return (null, "Empty OrderProducts Table");
                }

                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public (ProductCart?, string?) GetById(int id)
        {
            try
            {
                var res = db.productCarts.Where(po => po.ProductCartId == id).FirstOrDefault();
                    
                if (res == null)
                {
                    return (null, "Does not exist");
                }


                return (res, null);

            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        /*
        public (bool, string?) Update(int id, int qty)
        {
            try
            {
                var res = db.productCarts.Where(po => po.ProductCartId == id).FirstOrDefault();

                if (res == null)
                {
                    return (false, "Does not exist");
                }

                res.edit(qty);

                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }
        */
    }
}
