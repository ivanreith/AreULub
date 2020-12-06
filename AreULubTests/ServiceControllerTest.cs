using AreULub.Controllers;
using AreULub.Models;
using AreULub.Repositories;
using System;
using Xunit;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Channels;

namespace AreULubTests
{
    public class ServiceControllerTests
    {
       ServiceContext Context { get; set; }
        [Fact]
        public void TestAdd()
        {
            //Arrange
            ServiceContext c = new ServiceContext();
            var fakeRepo = new FakeServicesRepository();
            var controller = new ServicesController(fakeRepo, c); 
            var Service = new ServiceModel()
            {
                ServiceID = 0,
                ServiceName = "SomeJob",
                ServiceDescription = "FAKE REPO TEST",
                ServiceEstimated = "more for testing the repo fake",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast ="Fake2" },

            };
            //Act
            controller.Edit(Service);

            // Assert Checking that story was added.
            var retrievedService = fakeRepo.service.ToList()[0];
            Assert.NotNull(retrievedService.ServiceName);
        }

        [Fact]
        public void TestRemove()
        {
            //Arrange
            ServiceContext c = new ServiceContext();
            var fakeRepo = new FakeServicesRepository();
            var controller = new ServicesController(fakeRepo, c);
            var Service = new ServiceModel()
            {
                ServiceID = 0,
                ServiceName = "SomeJob",
                ServiceDescription = "FAKE REPO TEST",
                ServiceEstimated = "more for testing the repo fake",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast = "Fake2" },
            };

            //Act
            controller.Edit(Service); // adds
            controller.Delete(Service); // and deletes

            // Assert Checking that story was added.
            
            Assert.Empty(fakeRepo.service);
        }
        [Fact]
        public void TestUpdateService()
        {
            ServiceContext c = new ServiceContext();
            var fakeRepo = new FakeServicesRepository();
            var controller = new ServicesController(fakeRepo, c);
            var Service = new ServiceModel()
            {
                ServiceID = 0,
                ServiceName = "SomeJob",
                ServiceDescription = "FAKE REPO TEST",
                ServiceEstimated = "more for testing the repo fake",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast = "Fake2" },
            };
            var Service2 = new ServiceModel()
            {
                ServiceID = 1,
                ServiceName = "Test2",
                ServiceDescription = "FAKE REPO TEST2",
                ServiceEstimated = "more for testing the repo fake2",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast = "Fake2" },
            };
            var Service3 = new ServiceModel()
            {
                ServiceID = 1,
                ServiceName = "Test3",
                ServiceDescription = "FAKE REPO TEST3",
                ServiceEstimated = "more for testing the repo fake3",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast = "Fake2" },
            };
            //Act
            controller.Edit(Service);
            controller.Edit(Service2);
            controller.Edit(Service3);
            //Assert
            // Assert Checking that story was added.
            ServiceModel retrievedService = fakeRepo.service.ToList()[0];
            Assert.Equal("FAKE REPO TEST3", retrievedService.ServiceDescription);

        }
        [Fact]
        public void TestGetByIdService()
        {
            ServiceContext c = new ServiceContext();
            var fakeRepo = new FakeServicesRepository();
            var controller = new ServicesController(fakeRepo, c);
            var Service = new ServiceModel()
            {
                ServiceID = 0,// Add the item will put the count for that
                ServiceName = "SomeJob",
                ServiceDescription = "FAKE REPO TEST",
                ServiceEstimated = "more for testing the repo fake",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast = "Fake2" },
            };
            var Service2 = new ServiceModel()
            {
                ServiceID = 0,// Add the item will put the count for that
                ServiceName = "Test2",
                ServiceDescription = "FAKE REPO TEST2",
                ServiceEstimated = "more for testing the repo fake2",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast = "Fake2" },
            };
            var Service3 = new ServiceModel()
            {
                ServiceID = 0,// Add the item will put the count for that
                ServiceName = "Test3",
                ServiceDescription = "FAKE REPO TEST3",
                ServiceEstimated = "more for testing the repo fake3",
                ServicePrice = 80,
                User = new User() { UserId = "1", UserName = "Testing user99", UserLast = "Fake2" },
            };
            //Act
            controller.Edit(Service);
            controller.Edit(Service2);
            controller.Edit(Service3);
            //Assert
            // Assert Checking that story was added.            
            ServiceModel Service4 = fakeRepo.GetServiceById(2); // that should retrieve Service3
            Assert.Equal("FAKE REPO TEST3", Service4.ServiceDescription);

        }


    }
}
