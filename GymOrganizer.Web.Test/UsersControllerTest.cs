using GymOrganizer.Data.Db;
using GymOrganizer.Data.Model;
using GymOrganizer.Web.Controllers;
using GymOrganizer.Web.Services;
using GymOrganizer.Web.Utils;
using GymOrganizer.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymOrganizer.Web.Test
{
    [TestClass]
    public class UsersControllerTest : IDisposable
    {
        private readonly GymOrganizerContext db;
        private readonly UserService userService;
        private readonly ILoggerFactory loggerFactory;

        public UsersControllerTest()
        {
            AutoMapperConfiguration.Configure();

            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .AddLogging()
                .BuildServiceProvider();

            var options = new DbContextOptionsBuilder<GymOrganizerContext>()
                .UseInMemoryDatabase()
                .UseInternalServiceProvider(serviceProvider)
                .Options;

            this.db = new GymOrganizerContext(options);
            this.db.Database.EnsureCreated();

            this.loggerFactory = serviceProvider.GetService<ILoggerFactory>();


            this.userService = new UserService(this.db);

            Seed(this.db);

        }

        private void Seed(GymOrganizerContext db)
        {
            var alan = new User()
            {
                Id = Guid.Parse("6ec38623-b502-4d6f-ba74-d399943521ec"),
                FirstName = "Alan",
                LastName = "Jagar",
                Email = "alan.jagar@gmail.com",
                Age = 23,
                PhoneNumber = "098487057",
                Type = UserType.BasicMember,
                Address = "Platana 10"
            };

            var lovro = new User()
            {
                Id = Guid.Parse("5ec38623-b502-4d6f-ba74-d399943521ec"),
                FirstName = "Lovro",
                LastName = "Krpan",
                Email = "djuro.pedalira@hotmail.com",
                Age = 23,
                PhoneNumber = "234234234",
                Type = UserType.Coach,
                Address = "Zaprešić"
            };


            db.Users.AddRange(alan, lovro);
            db.SaveChanges();
        }


        #region GetUsers
        [TestMethod]
        public async Task Get_ReturnsAllUsers()
        {
            //Arrange
            var controller = new UsersController(this.loggerFactory, this.userService);

            //Act
            var result = await controller.Get();


            //Assert
            Assert.AreEqual(2, result.Count());
        }

        [TestMethod]
        public async Task Get_ReturnsCorrectType()
        {
            //Arrange
            var controller = new UsersController(this.loggerFactory, this.userService);

            //Act
            var result = await controller.Get();


            //Assert
            Assert.IsInstanceOfType(result, typeof(List<UserVM>));
        }
        #endregion

        #region GetUserById
        [TestMethod]
        public async Task GetById_ReturnsExactUser()
        {
            //Arrange
            var controller = new UsersController(this.loggerFactory, this.userService);

            //Act
            var result = await controller.GetById(Guid.Parse("6ec38623-b502-4d6f-ba74-d399943521ec"));

            //Assert
            Assert.AreEqual("Alan", result.FirstName);
        }

        [TestMethod]
        public async Task GetById_ReturnsNullForInvalidId()
        {
            //Arrange
            var controller = new UsersController(this.loggerFactory, this.userService);

            //Act
            var result = await controller.GetById(Guid.NewGuid());


            //Assert
            Assert.IsNull(result);
        }
        #endregion
        
        #region AddUser
        [TestMethod]
        public async Task Post_ReturnsBadRequestForNullValuePased()
        {
            //Arrange
            var controller = new UsersController(this.loggerFactory, this.userService);

            //Act
            var result = await controller.Post(null);

            //Assert
            Assert.IsInstanceOfType(result, typeof(BadRequestResult));
        }


        [TestMethod]
        public async Task Post_CreatesUserAndSendsOkResult()
        {
            //Arrange
            var controller = new UsersController(this.loggerFactory, this.userService);

            //Act
            var result = await controller.Post(new UserVM()
            {
                FirstName = "First name",
                LastName = "Last name",
                Email = "fname.lname@domain.com",
                Address = "asdas 05",
                Age = 20,
                PhoneNumber = "31231",
                Type = 1
            });


            //Assert
            Assert.IsInstanceOfType(result, typeof(OkResult));
        }

        [TestMethod]
        public async Task Post_CreatesUser()
        {
            //Arrange
            var controller = new UsersController(this.loggerFactory, this.userService);

            //Act
            var result = await controller.Post(new UserVM()
            {
                FirstName = "First name",
                LastName = "Last name",
                Email = "fname.lname@domain.com",
                Address = "asdas 05",
                Age = 20,
                PhoneNumber = "31231",
                Type = 1
            });


            var usersCount = this.db.Users.Count();

            //Assert
            Assert.AreEqual(3, usersCount);
        }


        #endregion





        public void Dispose()
        {
            this.db.Database.EnsureDeleted();
            this.db.Dispose();
        }
    }
}
