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
    public class AdminRepo : IAdminRepo
    {
        private readonly Context db;
        public AdminRepo(Context db)
        {
            this.db = db;
        }

        public (bool, string?) CreateAdmin(Admin adminDTO)
        {
            try
            {
                // Updated to use a constructor that matches the required parameters
                var admin = new Admin(
                    userId:adminDTO.UserId,
                    name:adminDTO.Name,
                    createdBy:adminDTO.Name
                    
                );

                db.Admins.Add(admin);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (bool, string?) DeleteAdmin(string id, string deletedBy)
        {
            try
            {
                var admin = db.Admins.Where(c => c.UserId == id).FirstOrDefault();
                if (admin == null)
                    return (false, "Admin not found");

                admin.Delete(id, deletedBy);
                db.SaveChanges();
                return (true, null);
            }
            catch (Exception ex)
            {
                return (false, ex.Message);
            }
        }

        public (Admin?, string?) GetAdminById(string id)
        {
            try
            {
                var res = db.Admins.Where(c => c.UserId == id).FirstOrDefault();

                if (res == null)
                {
                    return (null, "Customer not found");
                }

                return (res, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
            ;
        }

        public (List<Admin>?, string?) GetAllAdmins()
        {
            try
            {
                var res = db.Admins.Where(c => c.IsDeleted == false).ToList();
                return (res, null);
            }
            catch (Exception ex)
            {
                return (new List<Admin>(), ex.Message);
            }
        }

        public (bool, string?) UpdateAdmin(string id, string adminName, string modifiedBy)
        {
            var existing = db.Admins.Where(c => c.UserId == id).FirstOrDefault();
            if (existing == null)
                return (false, "Admin not found");

            existing.UpdateName(adminName, modifiedBy);
            db.SaveChanges();
            return (true, null);
        }

        (Admin?, string?) IAdminRepo.GetAdminById(string id)
        {
            try
            {
                var res = db.Admins.Where(c => c.UserId == id).FirstOrDefault();

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
            ;
        }
    }
}
