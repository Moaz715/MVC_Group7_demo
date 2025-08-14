using MVC_Group7_demo_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_DAL.Repository.Abstraction
{
    public interface IAdminRepo
    {
        Task<(Admin?, string?)> GetById(string id);
        public Task<(List<Admin>?, string?)> GetAll();
        Task<(bool, string?)> Create(Admin admin);
        public Task<(bool, string?)> Update(string id, string adminName, string modifiedBy);
        public Task<(bool, string?)> Delete(string id, string deletedBy);
    }
}
