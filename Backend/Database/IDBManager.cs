using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    public interface IDBManager
    {
        #region UserCUD

        void CreateUser(string username, string password, string email = null, string name = null, string surname = null);
        User GetUserById(int id);
        void DeleteUserById(int id);
        void UpdateUserById(int id,
                                   string username = null,
                                   string password = null,
                                   string email = null,
                                   string name = null,
                                   string surname = null);
        List<User> GetAllUsers();

        #endregion

        #region ProductCUD

        void CreateProduct(string name, int categoryId, int userId, string description = null);
        Product GetProductById(int id);
        void DeleteProductById(int id);
        void UpdateProductById(int id,
                                   string name = null,
                                   int categoryId = 0,
                                   int userId = 0,
                                   string description = null);
        List<Product> GetAllProducts();

        #endregion

        #region TagCUD

        void CreateTag(int tagId, string name);
        Tag GetTagById(int id);
        void DeleteTagById(int id);
        void UpdateTagById(int id,
                                  string name = null);
        List<Tag> GetAllTags();

        #endregion

        #region CategoryCUD

        void CreateCategory(int categoryId, string name);
        Category GetCategoryById(int id);
        void DeleteCategoryById(int id);
        void UpdateCategoryById(int id,
                                  string name = null);
        List<Category> GetAllCategories();

        #endregion


        #region RatingsCUD

        void CreateRating(int productId, int userId, int value, string comment = null);
        Rating GetRatingById(int id);
        void DeleteRatingById(int id);
        void UpdateRatingById(int id,
                                   int productId = 0,
                                   int userId = 0,
                                   int value = 0,
                                   string comment = null);
        List<Rating> GetAllRatings();

        #endregion
    }
}
