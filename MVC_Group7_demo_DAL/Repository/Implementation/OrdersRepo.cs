using Microsoft.EntityFrameworkCore;
using MVC_Group7_demo_DAL.DataBase;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Implementation
{
    public class OrdersRepo : IOrdersRepo
    {
        private readonly Context db;

        public OrdersRepo(Context db)
        {
            this.db = db;
        }

        public async Task save()
        {
            await db.SaveChangesAsync();
        }

        public async Task<(bool, string?)> CreateAsync(Orders order)
        {
            try
            {
                await db.Orders.AddAsync(order);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> EditAsync(int id, double total, int cnt)
        {
            try
            {
                var res = await db.Orders.Include(o=>o.customer).FirstOrDefaultAsync(a => a.Order_id == id);

                if (res == null)
                {

                    return (false, "Does not exist in db");
                }

                res.edit(total, cnt, res.customer.Name);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> DeleteAsync(int id)
        {
            try
            {
                var res = await db.Orders
                    .Include(o => o.customer)
                    .Include(o => o.ProductOrders) 
                    .FirstOrDefaultAsync(a => a.Order_id == id);

                if (res == null)
                {
                    return (false, "Does not exist in db");
                }

                res.delete(res.customer.Name);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(List<Orders>?, string?)> GetAllAsync()
        {
            try
            {
                var res = await db.Orders.Where(a => !a.isDeleted).ToListAsync();

                if (res == null || res.Count == 0)
                {
                    return (null, "Db empty no list");
                }

                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(Orders?, string?)> GetByIdAsync(int id)
        {
            try
            {
                var res = await db.Orders.Include(o => o.ProductOrders).ThenInclude(p => p.Product).FirstOrDefaultAsync(a => a.Order_id == id && a.isDeleted == false);

                if (res == null)
                {
                    return (null, "Id does not exist in db");
                }

                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(List<Orders>?, string?)> GetFinalizedOrders(string customerId)
        {
            try
            {
                var res = await db.Orders.Include(o => o.delivery).Include(o=>o.customer).Include(o => o.ProductOrders).Where(o => o.Customer_id == customerId && o.isFinalized && o.isDeleted == false).ToListAsync();

                if (res == null)
                {
                    Console.WriteLine("null in DAL");
                    return (null, "Id does not exist in db");
                }

                Console.WriteLine("correct in DAL");
                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

       
        public async Task<(bool,string?)> FinalizeOrderAsync(string customerId, string paymentMethod, string loc)
        {
            

            try
            {
                var order = await db.Orders
                    .Include(o => o.ProductOrders)
                    .ThenInclude(po => po.Product)
                    .Where(o=>o.isDeleted == false && o.isFinalized == false)
                    .FirstOrDefaultAsync(o => o.Customer_id == customerId);

                var deliveries = await db.Deliveries.Where(d => d.Destination == loc && d.IsDeleted == false).ToListAsync();

                int randomId = 0;

                if (deliveries.Any())
                {
                    var random = new Random();
                    int randomIndex = random.Next(deliveries.Count); 
                    randomId = deliveries[randomIndex].Delivery_id;       

                    Console.WriteLine($"Random Delivery ID: {randomId}");
                }
                else
                {
                    Console.WriteLine("No deliveries found for that location.");
                }

                if (order == null)
                {
                    Console.WriteLine("in dal ahhhhh");
                    return (false, "DAL : Order does not exist");
                }
                   

                
                foreach (var item in order.ProductOrders)
                {
                    if (item.Quantity > item.Product.Stock)
                        throw new InvalidOperationException(
                            $"Product {item.Product.Name} is out of stock."
                        );
                }

                
                foreach (var item in order.ProductOrders)
                {
                    var newStock = item.Product.Stock - item.Quantity;
                    if (newStock < 0)
                        throw new InvalidOperationException($"Not enough stock for product {item.Product.Name}.");

                   
                }

                foreach (var item in order.ProductOrders)
                {
                    var newStock2 = item.Product.Stock - item.Quantity;
                    if (newStock2 < 0)
                        throw new InvalidOperationException($"Not enough stock for product {item.Product.Name}.");

                    item.Product.UpdateStock(newStock2, modifiedBy: "System");
                }


                order.finalize(paymentMethod, randomId);

                await db.SaveChangesAsync();
                

                return (true,null);
            }
            catch(Exception ex)
            {
                
                return (false, ex.Message);
            }
        }
        

    }
}
