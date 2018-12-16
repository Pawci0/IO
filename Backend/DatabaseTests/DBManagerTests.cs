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
    }
}