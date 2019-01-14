using Microsoft.VisualStudio.TestTools.UnitTesting;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database.Tests
{
    [TestClass()]
    public class DBManagerTests
    {
        DBManager manager = new DBManager();

        [TestMethod()]
        public void CreateUserTest()
        {
            int countBefore = manager.GetAllUsers().Count;
            manager.CreateUser("a", "b");
            int countAfter = manager.GetAllUsers().Count;
            Assert.AreEqual(countBefore + 1, countAfter);
        }

        [TestMethod()]
        public void DeleteUserByIdTest()
        {
            int countBefore = manager.GetAllUsers().Count;
            manager.DeleteUserById(countBefore-1);
            int countAfter = manager.GetAllUsers().Count;
            Assert.AreEqual(countBefore - 1, countAfter);
        }

        [TestMethod()]
        public void BlaBla()
        {
            var v = manager.GetAllCategories();
            manager.CreateCategory("test11");
            var cat = manager.GetAllCategories().Find(c => c.Name == "test11");
            Assert.AreEqual(0, cat.Products.Count);
            manager.CreateProduct("a thing", cat.Category_Id, 1);
            cat = manager.GetAllCategories().Find(c => c.Name == "test11");
            Assert.AreEqual(1, cat.Products.Count);
        }

        [TestMethod()]
        public void UserProducts()
        {
            var user = manager.GetUserById(1);
            Assert.AreNotEqual(0, user.Products);
        }

        [TestMethod()]
        public void DuplicationCheck()
        {
            if (manager.GetUserByUsername("testDuplikatu") == null)
            {
                manager.CreateUser("testDuplikatu", "testoweHaslo");
            }
            Assert.ThrowsException<DBDuplicateException>(()=>manager.CreateUser("testDuplikatu", "testoweHaslo"));
            var x = manager.GetAllTags();

            if (manager.GetAllTags().Find(tag => tag.Name == "testDuplikatu") == null)
            {
                manager.CreateTag("testDuplikatu");
            }
            Assert.ThrowsException<DBDuplicateException>(() => manager.CreateTag("testDuplikatu"));

            if (manager.GetAllCategories().Find(cat => cat.Name == "testDuplikatu") == null)
            {
                manager.CreateCategory("testDuplikatu");
            }
            Assert.ThrowsException<DBDuplicateException>(() => manager.CreateCategory("testDuplikatu"));

            var userId = manager.GetAllUsers().First().User_Id;
            var productId = manager.GetAllProducts().First().Product_Id;

            if (manager.GetAllRatings().Find(r => r.Product_Id == productId && r.User_id == userId) == null)
            {
                manager.CreateRating(productId, userId, 5, "testDuplikatu");
            }
            Assert.ThrowsException<DBDuplicateException>(() => manager.CreateRating(productId, userId, 5, "testDuplikatu"));
        }
    }
}