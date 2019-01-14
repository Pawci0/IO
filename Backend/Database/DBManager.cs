using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace Database
{
    public class DBManager : IDBManager
    {
        #region UserCUD
        public void CreateUser(string username, string password, string email = null, string name = null, string surname = null)
        {
            using(var ctx = new katalogrzeczyEntities())
            {
                if(ctx.Users.Where(u=>u.Username == username).Count() != 0)
                {
                    throw new DBDuplicateException("User of same username already exists");
                }
                ctx.Users.Add(new User()
                {
                    Username = username,
                    Password = password,
                    Email = email,
                    Name = name,
                    Surname = surname,
                    IsEnabled = true
                });
                ctx.SaveChanges();
            }
        }

        public User GetUserById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from User user in ctx.Users
                        where user.User_Id == id
                        select user).Include(u=>u.Products)
                                    .Include(u=>u.Ratings)
                                    .FirstOrDefault();
            }
        }

        public User GetActiveUserById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from User user in ctx.Users
                    where user.User_Id == id && user.IsEnabled
                    select user).Include(u => u.Products)
                                .Include(u => u.Ratings)
                                .FirstOrDefault();
            }
        }
        
        public User GetUserByUsername(string username)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from User user in ctx.Users
                    where user.Username == username
                    select user).Include(u => u.Products)
                                .Include(u => u.Ratings)
                                .FirstOrDefault();
            }
        }
        
        public User GetUserByEmail(string email)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from User user in ctx.Users
                    where user.Email == email
                    select user).Include(u => u.Products)
                                .Include(u => u.Ratings)
                                .FirstOrDefault();
            }
        }

        public void DeleteUserById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                User user = GetUserById(id);
                if (user != null)
                {
                    ctx.Users.Attach(user);
                    user.IsEnabled = false;
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateUserById(int id, 
                                   string username = null, 
                                   string password = null, 
                                   string email = null, 
                                   string name = null, 
                                   string surname = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                User user = GetUserById(id);
                if(user != null)
                {
                    ctx.Users.Attach(user);
                    user.Username = username ?? user.Username;
                    user.Password = password ?? user.Password;
                    user.Email = email ?? user.Email;
                    user.Name = name ?? user.Name;
                    user.Surname = surname ?? user.Surname;
                    ctx.SaveChanges();
                }
            }
        }

        public List<User> GetAllUsers()
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return ctx.Users.Include(u => u.Products)
                                .Include(u => u.Ratings)
                                .ToList();
            }
        }
        #endregion

        #region ProductCUD

        public void CreateProduct(string name, int categoryId, int userId, string description = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Product product = new Product()
                {
                    Name = name,
                    Category_Id = categoryId,
                    User_Id = userId,
                    Description = description
                };
                ctx.Products.Add(product);
                ctx.SaveChanges();
            }
        }

        public Product GetProductById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from Product product in ctx.Products
                        where product.Product_Id == id
                        select product).Include(p => p.Ratings)
                                       .Include(p => p.Tags)
                                       .FirstOrDefault();
            }
        }

        public void DeleteProductById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Product product = GetProductById(id);
                if (product != null)
                {
                    ctx.Products.Attach(product);
                    ctx.Products.Remove(product);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateProductById(int id,
                                   string name = null,
                                   int categoryId = 0,
                                   int userId = 0,
                                   string description = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Product product = GetProductById(id);
                if (product != null)
                {
                    ctx.Products.Attach(product);
                    product.Name = name ?? product.Name;
                    product.Description = description ?? product.Description;

                    if (categoryId != 0)
                        product.Category_Id = categoryId;

                    if (userId != 0)
                        product.User_Id = userId;

                    ctx.SaveChanges();
                }
            }
        }

        public List<Product> GetAllProducts()
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return ctx.Products.Include(p => p.Ratings)
                                   .Include(p => p.Tags)
                                   .ToList();
            }
        }

        #endregion

        #region TagCUD

        public void CreateTag(string name)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                if (ctx.Tags.Where(t => t.Name == name).Count() != 0)
                {
                    throw new DBDuplicateException("Tag already exists");
                }
                ctx.Tags.Add(new Tag()
                {
                    Name = name
                });
                ctx.SaveChanges();
            }
        }

        public Tag GetTagById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from Tag tag in ctx.Tags
                        where tag.Tag_Id == id
                        select tag).Include(t=>t.Products)
                                   .FirstOrDefault();
            }
        }

        public void DeleteTagById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Tag tag = GetTagById(id);
                if (tag != null)
                {
                    ctx.Tags.Attach(tag);
                    ctx.Tags.Remove(tag);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateTagById(int id,
                                  string name = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Tag tag = GetTagById(id);
                if (tag != null)
                {
                    ctx.Tags.Attach(tag);
                    tag.Name = name ?? tag.Name;

                    ctx.SaveChanges();
                }
            }
        }

        public List<Tag> GetAllTags()
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return ctx.Tags.Include(t => t.Products)
                               .ToList();
            }
        }

        #endregion

        #region CategoryCUD

        public void CreateCategory(string name)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                if (ctx.Categories.Where(c => c.Name == name).Count() != 0)
                {
                    throw new DBDuplicateException("Category already exists");
                }
                ctx.Categories.Add(new Category()
                {
                    Name = name
                });
                ctx.SaveChanges();
            }
        }

        public Category GetCategoryById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from Category category in ctx.Categories
                        where category.Category_Id == id
                        select category).Include(c => c.Products)
                                        .FirstOrDefault();
            }
        }

        public void DeleteCategoryById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Category category = GetCategoryById(id);
                if (category != null)
                {
                    ctx.Categories.Attach(category);
                    ctx.Categories.Remove(category);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateCategoryById(int id,
                                  string name = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Category category = GetCategoryById(id);
                if (category != null)
                {
                    ctx.Categories.Attach(category);
                    category.Name = name ?? category.Name;

                    ctx.SaveChanges();
                }
            }
        }

        public List<Category> GetAllCategories()
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return ctx.Categories.Include(c=>c.Products)
                                     .ToList();
            }
        }

        #endregion

        #region RatingCUD

        public void CreateRating(int productId, int userId, int value, string comment = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                if (ctx.Ratings.Where(r => r.Product_Id == productId && r.User_id == userId).Count() != 0)
                {
                    throw new DBDuplicateException("Product already rated by this user");
                }
                ctx.Ratings.Add(new Rating()
                {
                    Product_Id = productId,
                    User_id = userId,
                    Value = value,
                    Comment = comment
                });
                ctx.SaveChanges();
            }
        }

        public Rating GetRatingById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return (from Rating rating in ctx.Ratings
                        where rating.Rating_Id == id
                        select rating).FirstOrDefault();
            }
        }

        public void DeleteRatingById(int id)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Rating rating = GetRatingById(id);
                if (rating != null)
                {
                    ctx.Ratings.Attach(rating);
                    ctx.Ratings.Remove(rating);
                    ctx.SaveChanges();
                }
            }
        }

        public void UpdateRatingById(int id,
                                   int productId = 0,
                                   int userId = 0,
                                   int value = 0,
                                   string comment = null)
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                Rating rating = GetRatingById(id);
                if (rating != null)
                {
                    ctx.Ratings.Attach(rating);
                    rating.Comment = comment ?? rating.Comment;

                    if (productId != 0)
                        rating.Product_Id = productId;

                    if (userId != 0)
                        rating.User_id = userId;

                    ctx.SaveChanges();
                }
            }
        }

        public List<Rating> GetAllRatings()
        {
            using (var ctx = new katalogrzeczyEntities())
            {
                return ctx.Ratings.ToList();
            }
        }

        #endregion

    }
}
