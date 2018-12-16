using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product
{
    public class ProductService
    {
        private DBManager db;

        public ProductService()
        {
            db = new DBManager();
        }

        public ProductDto GetProduct(int id)
        {
            Database.Product product = db.GetProductById(id);
            if (product != null)
            {
                if (product.Category_Id.HasValue)
                { 
                    return new ProductDto(product.Product_Id, product.Name,
                    product.Category_Id.Value, product.User_Id, product.Description);
                }
                return new ProductDto(product.Product_Id, product.Name,
                    product.User_Id, product.Description);
            }
            return null;
        }

        public void CreateProduct(ProductDto product)
        {
            db.CreateProduct(product.name, product.categoryId, product.userId, 
                product.description);
        }

        public void UpdateProduct(ProductDto product)
        {
            db.UpdateProductById(product.productId, product.name, product.categoryId,
                product.userId, product.description);
        }

        public void DeleteProduct(int id)
        {
            db.DeleteProductById(id);
        }
    }
}
