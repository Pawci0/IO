using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModule
{
    public class ProductDto
    {
        public int productId { get; set; }
        public string name { get; set; }
        public int categoryId { get; set; }
        public int userId { get; set; }
        public string description { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(int productId, string name, int categoryId, int userId, string description)
        {
            this.productId = productId;
            this.name = name;
            this.categoryId = categoryId;
            this.userId = userId;
            this.description = description;
        }

        public ProductDto(int productId, string name, int userId, string description)
        {
            this.productId = productId;
            this.name = name;
            this.userId = userId;
            this.description = description;
        }
    }
}
