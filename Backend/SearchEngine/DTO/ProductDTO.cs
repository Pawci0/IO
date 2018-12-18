using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SearchEngine.DTO
{
    public class ProductDTO : ISearchItemDTO
    {
        public int Product_Id { get; }
        public string Name { get; }
        public string Category_Name { get; }
        public string User_Username { get; }
        public string Description { get; }
        public float Score { get; }

        internal ProductDTO(Product product, float searchScore)
        {
            Product_Id = product.Product_Id;
            Name = product.Name;
            Description = product.Description;
            Category_Name = product.Category?.Name ?? "No category";
            User_Username = product.User.Username;
            Score = searchScore;
        }
    }
}
