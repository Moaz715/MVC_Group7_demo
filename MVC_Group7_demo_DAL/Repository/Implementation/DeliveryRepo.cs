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
    public class DeliveryRepo : IDeliveryRepo
    {
        private readonly Context db;
        public DeliveryRepo(Context db)
        {
            this.db = db;
        }

        public async Task<(bool, string?)> CreateAsync(Delivery delivery)
        {
            try
            {
                await db.Deliveries.AddAsync(delivery);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(Delivery?, string?)> GetByIdAsync(int id)
        {
            try
            {
                var res = await db.Deliveries.FirstOrDefaultAsync(c => c.Delivery_id == id && c.IsDeleted == false);
                if (res == null)
                {
                    return (null, "Delivery not found");
                }
                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(bool, string?)> UpdateAsync(Delivery delivery)
        {
            try
            {
                db.Deliveries.Update(delivery);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> DeleteAsync(int id, string deletedBy)
        {
            try
            {
                var delivery = await db.Deliveries.FirstOrDefaultAsync(c => c.Delivery_id == id);
                if (delivery == null)
                    return (false, "Delivery not found");

                delivery.Delete(deletedBy);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(List<Delivery>, string?)> GetAllAsync()
        {
            try
            {
                var res = await db.Deliveries.Where(c => c.IsDeleted == false).ToListAsync();
                return (res, null);
            }
            catch (Exception ex)
            {
                return (new List<Delivery>(), ex.Message);
            }
        }
    }
}