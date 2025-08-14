using MVC_Group7_demo_DAL.DataBase;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Implementation
{
    public class AdminRepo : IAdminRepo
    {
        private readonly Context db;
        public AdminRepo(Context db)
        {
            this.db = db;
        }

        public async Task<(bool, string?)> Create(Admin adminDTO)
        {
            try
            {
                var admin = new Admin(
                    userId: adminDTO.UserId,
                    name: adminDTO.Name,
                    createdBy: adminDTO.Name
                );

                await db.Admins.AddAsync(admin);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> Delete(string id, string deletedBy)
        {
            try
            {
                var admin = await db.Admins.Where(c => c.UserId == id).FirstOrDefaultAsync();
                if (admin == null)
                    return (false, "Admin not found");

                admin.Delete(id, deletedBy);
                await db.SaveChangesAsync();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public async Task<(Admin?, string?)> GetById(string id)
        {
            try
            {
                var res = await db.Admins
                    .Include(a => a.User)
                    .FirstOrDefaultAsync(c => c.UserId == id);

                if (res == null)
                {
                    return (null, "Admin not found");
                }

                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(List<Admin>?, string?)> GetAll()
        {
            try
            {
                var res = await db.Admins
                    .Include(a => a.User)
                    .Where(c => c.IsDeleted == false)
                    .ToListAsync();
                return (res, null);
            }
            catch (Exception ex)
            {
                return (new List<Admin>(), ex.Message);
            }
        }

        public async Task<(bool, string?)> Update(string id, string adminName, string modifiedBy)
        {
            try
            {
                var existing = await db.Admins.Where(c => c.UserId == id).FirstOrDefaultAsync();
                if (existing == null)
                    return (false, "Admin not found");

                existing.UpdateName(adminName, modifiedBy);
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
