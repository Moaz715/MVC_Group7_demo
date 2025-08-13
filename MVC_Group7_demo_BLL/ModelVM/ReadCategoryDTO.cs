using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_Group7_demo_BLL.ModelVM
{
    public class ReadCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<string> Products { get; set; } = new List<string>();

    }
}
