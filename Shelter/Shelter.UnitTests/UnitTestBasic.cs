using NUnit.Framework;
using MyAspMvc.Controllers;
using Moq;
using MyAspMvc;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Shelter.UnitTests
{
  public class Tests
  {
    private Mock<IShelterDataAccess> _mockedDataAccess;
    private Mock<ILogger<ApiController>> _mockedLogger;
    private ApiController _controller;

    [SetUp]
    public void Setup()
    {
      _mockedDataAccess = new Mock<IShelterDataAccess>(MockBehavior.Strict);
      _mockedLogger = new Mock<ILogger<ApiController>>(MockBehavior.Strict);
      _controller = new ApiController(_mockedLogger.Object, _mockedDataAccess.Object);
    }

    [TearDown]
    public void TearDown()
    {
      _mockedDataAccess.VerifyAll();
      _mockedLogger.VerifyAll();
    }

    // These tests can be run using dotnet test

    [Test]
    public void Test_GetAll()
    {
      var shelters = new List<Shelter.Shared.Shelter>();

      _mockedDataAccess.Setup(x => x.GetAllShelters()).Returns(shelters);
      // uncomment the next line, run the test, read the exception message.
      //_mockedDataAccess.Setup(x => x.GetAllSheltersFull()).Returns(shelters);

      var result = _controller.GetAllShelters();

      // uncomment this obviously wrong line, see what happens
      // Assert.IsInstanceOf(typeof(NotFoundResult), result);

      Assert.IsInstanceOf(typeof(OkObjectResult), result);
      Assert.AreEqual(((OkObjectResult)result).Value, shelters);

    }

    [Test]
    public void Test_GetOneHappyFlow()
    {
      var shelter = new Shelter.Shared.Shelter()
      {
        Name = "abc"
      };
      
      _mockedDataAccess.Setup(x => x.GetShelterById(12)).Returns(shelter);

      var result = _controller.GetShelter(12);

      Assert.IsInstanceOf(typeof(OkObjectResult), result);
      Assert.AreEqual(((OkObjectResult)result).Value, shelter);
    }

    [Test]
    public void Test_GetOneNotFound()
    {
      _mockedDataAccess.Setup(x => x.GetShelterById(12)).Returns(default(Shelter.Shared.Shelter));

      var result = _controller.GetShelter(12);

      Assert.IsInstanceOf(typeof(NotFoundResult), result);
    }
  }
}