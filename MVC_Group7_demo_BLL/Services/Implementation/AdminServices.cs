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
                
                var admin = new Admin(
                    userId: adminDTO.UserId,
                    name: adminDTO.Name,
                    createdBy: adminDTO.CreatedBy
                );

                
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
                
                var result = await adminRepo.GetById(id);

                if (result.Item1 == null)
                    return (null, "Admin not found");

                var adminEntity = result.Item1;

                
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
                
                var result = await adminRepo.GetAll();

                if (result.Item1 == null)
                    return (null, "No admins found");

                var adminEntities = result.Item1;
                var adminDTOs = new List<AdminDTO>();

                
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
                
                var result = await adminRepo.Update(id, name, modifiedBy);

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
                
                var result = await adminRepo.Delete(id, deletedBy);

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
