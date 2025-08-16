
using Microsoft.AspNetCore.Http;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class CreateCategoryDto
    {
        public string Name { get; set; }
        public string CreatedBy { get; set; }
        public IFormFile? Image { get; set; }
    }
}
