using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductModule
{
    public class CategoryService
    {
        private DBManager db;

        public CategoryService()
        {
            db = new DBManager();
        }

        public CategoryDto GetCategory(int id)
        {
            Database.Category category = db.GetCategoryById(id);
            if (category != null)
            {
                return new CategoryDto(category.Category_Id, category.Name);
            }
            return null;
        }

        public void CreateCategory(CategoryDto category)
        {
            db.CreateCategory(category.name);
        }

        public void UpdateCategory(CategoryDto category)
        {
            db.UpdateCategoryById(category.categoryId, category.name);
        }

        public void DeleteCategory(int id)
        {
            db.DeleteCategoryById(id);
        }
    }
}
