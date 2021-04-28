//using Microsoft.NET.Test.Sdk;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using SecretSanta.Api.Controllers;
using System.Collections.Generic;
using SecretSanta.Business;
using SecretSanta.Data;
using Microsoft.AspNetCore.Mvc;
using System;

namespace SecretSanta.Api.Tests.Controllers
{
    [TestClass]
    public class UsersControllerTests 
    {
        [TestMethod]
        public void Get_WithData_ReturnsUsers()
        {
            // Arrange
            UsersController controller = new();

            // Act
            IEnumerable<string> events = controller.Get();

            // Assert
            Assert.IsTrue(users.Any());
        }
    }
}