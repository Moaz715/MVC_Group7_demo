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
        (List<Admin>?, string?) GetAllAdmins();
        (Admin?, string?) GetAdminById(string id);
        (bool, string?) CreateAdmin(Admin admin);
        (bool, string?) UpdateAdmin(string id, string adminName, string modifiedBy);
        (bool, string?) DeleteAdmin(string id, string deletedBy);
    }
}
