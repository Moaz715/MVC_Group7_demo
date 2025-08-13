using MVC_Group7_demo_BLL.ModelVM;
using MVC_Group7_demo_BLL.Services.Abstraction;
using MVC_Group7_demo_DAL.Entities;
using MVC_Group7_demo_DAL.Repository.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.Services.Implementation
{
    public class AdminServices : IAdminServices
    {
        private readonly IAdminRepo adminRepo;

        public AdminServices(IAdminRepo adminRepo)
        {
            this.adminRepo = adminRepo;
        }

        public async Task<(bool, string?)> CreateAsync(AdminDTO adminDTO)
        {
            try
            {
                // إنشاء Admin entity من AdminDTO
                var admin = new Admin(
                    userId: adminDTO.UserId,
                    name: adminDTO.Name,
                    createdBy: adminDTO.CreatedBy
                );

                // استدعاء Repository لإنشاء Admin
                var result = await adminRepo.Create(admin);
                
                Console.WriteLine("In AdminServices Create: " + result.Item1);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("In AdminServices Create Exception: " + ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(AdminDTO?, string?)> GetByIdAsync(string id)
        {
            try
            {
                // استدعاء Repository لجلب Admin بواسطة ID
                var result = await adminRepo.GetById(id);

                if (result.Item1 == null)
                    return (null, "Admin not found");

                var adminEntity = result.Item1;

                // تحويل Admin entity إلى AdminDTO
                var adminDTO = new AdminDTO
                {
                    UserId = adminEntity.UserId,
                    Name = adminEntity.Name,
                    CreatedOn = adminEntity.CreatedOn,
                    CreatedBy = adminEntity.CreatedBy,
                    ModifiedOn = adminEntity.ModifiedOn,
                    ModifiedBy = adminEntity.ModifiedBy,
                    DeletedOn = adminEntity.DeletedOn,
                    DeletedBy = adminEntity.DeletedBy,
                    IsDeleted = adminEntity.IsDeleted
                };

                return (adminDTO, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(List<AdminDTO>?, string?)> GetAllAsync()
        {
            try
            {
                // استدعاء Repository لجلب جميع Admins
                var result = adminRepo.GetAll();

                if (result.Item1 == null)
                    return (null, "No admins found");

                var adminEntities = result.Item1;
                var adminDTOs = new List<AdminDTO>();

                // تحويل كل Admin entity إلى AdminDTO
                foreach (var adminEntity in adminEntities)
                {
                    var adminDTO = new AdminDTO
                    {
                        UserId = adminEntity.UserId,
                        Name = adminEntity.Name,
                        CreatedOn = adminEntity.CreatedOn,
                        CreatedBy = adminEntity.CreatedBy,
                        ModifiedOn = adminEntity.ModifiedOn,
                        ModifiedBy = adminEntity.ModifiedBy,
                        DeletedOn = adminEntity.DeletedOn,
                        DeletedBy = adminEntity.DeletedBy,
                        IsDeleted = adminEntity.IsDeleted
                    };

                    adminDTOs.Add(adminDTO);
                }

                return (adminDTOs, null);
            }
            catch (Exception ex)
            {
                return (null, ex.Message);
            }
        }

        public async Task<(bool, string?)> UpdateAsync(string id, string name, string modifiedBy)
        {
            try
            {
                // استدعاء Repository لتحديث Admin
                var result = adminRepo.Update(id, name, modifiedBy);
                
                Console.WriteLine("In AdminServices Update: " + result.Item1);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("In AdminServices Update Exception: " + ex.Message);
                return (false, ex.Message);
            }
        }

        public async Task<(bool, string?)> DeleteAsync(string id, string deletedBy)
        {
            try
            {
                // استدعاء Repository لحذف Admin
                var result = adminRepo.Delete(id, deletedBy);
                
                Console.WriteLine("In AdminServices Delete: " + result.Item1);
                return result;
            }
            catch (Exception ex)
            {
                Console.WriteLine("In AdminServices Delete Exception: " + ex.Message);
                return (false, ex.Message);
            }
        }
    }
} 