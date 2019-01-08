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
    }
}