using Microsoft.VisualStudio.TestTools.UnitTesting;
using ProductionAccounting.BL.Controller;
using ProductionAccounting.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductionAccounting.BL.Controller.Tests
{
    [TestClass()]
    public class WorkControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var productivityName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var workController = new WorkController(userController.CurrentUser);
            var productivity = new Productivity(productivityName, rnd.Next(10,50));

            // Act

            workController.Add(productivity, DateTime.Now, DateTime.Now.AddHours(12));

            // Assert
            Assert.AreEqual(productivityName, workController.Productivities.First().Name);
        }
    }
}