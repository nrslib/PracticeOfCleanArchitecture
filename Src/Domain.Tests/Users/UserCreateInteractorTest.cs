using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Linq;
using Domain.Application.Users;
using InMemoryInfrastructure.Users;
using UseCase.Users.Create;

namespace Domain.Tests.Users
{
    [TestClass]
    public class UserCreateInteractorTest
    {
        [TestMethod]
        public void TestCreateUser() {
            var repository = new InMemoryUserRepository();
            var presenter = new UserCreateCollector();
            var interactor = new UserCreateInteractor(repository, presenter);
            var request = new UserCreateRequest("TestUser");

            interactor.Handle(request);
            var expectedPercentages = new List<int> {
                10,
                30,
                50,
                80
            };
            Assert.IsTrue(expectedPercentages.SequenceEqual(presenter.Percentages));
            Assert.IsNotNull(presenter.Response);
            Assert.IsNotNull(presenter.Response.UserId);
            var inserted = repository.FindByUserName("TestUser");
            Assert.IsNotNull(inserted);
        }
    }
}
