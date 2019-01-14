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
            int exectedCount = manager.GetAllUsers().Count;
            if(manager.GetUserByUsername("a") == null)
            {
                manager.CreateUser("a", "b");
                exectedCount++;
            }
            int countAfter = manager.GetAllUsers().Count;
            Assert.AreEqual(exectedCount, countAfter);
        }

        [TestMethod()]
        public void DeleteUserByIdTest()
        {
            var id = manager.GetAllUsers().First().User_Id;
            manager.DeleteUserById(id);
            Assert.IsFalse(manager.GetUserById(id).IsEnabled);
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
        }
    }
}