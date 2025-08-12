using Microsoft.EntityFrameworkCore;
using MVC_Group7_demo_DAL.DataBase;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Implementation
{
    public class ProductOrderRepo : IProductOrderRepo
    {
        private readonly Context db;

        public ProductOrderRepo(Context db)
        {
            this.db = db;
        }
        public async Task<(bool, string?)> Create(ProductOrder productOrder)
        {
            try
            {
                await db.productOrders.AddAsync(productOrder);
                await db.SaveChangesAsync();
                return (true, null);

            }catch(Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> Delete(int id, string deletedBy)
        {
            try
            {
                var res = await db.productOrders.Where(po => po.ProductOrderId == id).FirstOrDefaultAsync();

                if(res == null)
                {
                    return (false, "Does not exist");
                }

                res.delete(deletedBy);
                await db.SaveChangesAsync();
                return (true, null);

            }catch(Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(List<ProductOrder>?, string?)> GetAll()
        {
            try
            {
                var res = await db.productOrders.ToListAsync();

                if(res == null || res.Count == 0)
                {
                    return (null, "Empty OrderProducts Table");
                }

                return (res, null);
            }catch(Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(ProductOrder?, string?)> GetById(int id)
        {
            try
            {
                var res = await db.productOrders.Where(po => po.ProductOrderId == id).Include(po => po.Product).FirstOrDefaultAsync();

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

        public async Task<(bool, string?)> Update(int id, int qty, string modifiedBy)
        {
            try
            {
                var res = await db.productOrders.Where(po => po.ProductOrderId == id).FirstOrDefaultAsync();

                if (res == null)
                {
                    return (false, "Does not exist");
                }

                res.edit(qty, modifiedBy);
                await db.SaveChangesAsync();

                return (true, null);

            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool,string?)> Reactivate(int id)
        {
            try
            {
                var res = await db.productOrders.Where(po => po.ProductOrderId == id).FirstOrDefaultAsync();

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
    }
}
