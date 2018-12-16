using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class CategoryDto
    {
        public int categoryId { get; set; }
        public string name { get; set; }

        public CategoryDto()
        {
        }

        public CategoryDto(int categoryId, string name)
        {
            this.categoryId = categoryId;
            this.name = name;
        }
    }
}
