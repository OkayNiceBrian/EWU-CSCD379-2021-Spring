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
            UsersController controller = new(new UserRepository());

            // Act
            IEnumerable<User> users = controller.Get();

            // Assert
            Assert.IsTrue(users.Any());
            
        }

        [TestMethod]
        [DataRow(42)]
        public void Get_WithId_ReturnsUserRepositoryUser(int id) {
            // Arrange
            TestableUserRepository repo = new();
            UsersController controller = new(repo);
            User expectedUser = new();
            repo.GetItemUser = expectedUser;

            // Act
            ActionResult<User?> result = controller.Get(id);

            // Assert
            Assert.AreEqual(id, repo.GetItemId);
            Assert.AreEqual(expectedUser, result.Value);
        }

         private class TestableUserRepository : IUserRepository
        {
            public User Create(User item)
            {
                throw new System.NotImplementedException();
            }

            public User? GetItemUser{ get; set; }
            public int GetItemId { get; set; }
            public User? GetItem(int id)
            {
                GetItemId = id;
                return GetItemUser;
            }

            public ICollection<User> List()
            {
                throw new System.NotImplementedException();
            }

            public bool Remove(int id)
            {
                throw new System.NotImplementedException();
            }

            public void Save(User item)
            {
                throw new System.NotImplementedException();
            }
        }
    }
}