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
    public class ProductionControllerTests
    {
        [TestMethod()]
        public void AddTest()
        {
            // Arrange
            var userName = Guid.NewGuid().ToString();
            var tareName = Guid.NewGuid().ToString();
            var rnd = new Random();
            var userController = new UserController(userName);
            var productionController = new ProductionController(userController.CurrentUser);
            var tare = new Tare(tareName, rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500), rnd.Next(50, 500));

            // Act

            productionController.Add(tare, 100);

            // Assert
            //Assert.AreEqual(tare.Name, productionController.Production.Tares.First().Key.Name);
        }
    }
}