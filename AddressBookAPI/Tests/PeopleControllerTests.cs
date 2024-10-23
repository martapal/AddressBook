using AddressBookAPI.Controllers;
using AddressBookAPI.Models;
using AddressBookAPI.Services;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using Moq;

namespace AddressBookAPI.Tests
{
    public class PeopleControllerTests
    {
        private readonly Mock<IPeopleService> _mockPeopleService;
        private readonly PeopleController _controller;

        public PeopleControllerTests()
        {
            // Create a mock of the IPeopleService
            _mockPeopleService = new Mock<IPeopleService>();

            // Inject the mocked service into the PeopleController
            _controller = new PeopleController(_mockPeopleService.Object);
        }

        // Test for GetPeople() - GET: api/people
        [Fact]
        public async Task GetPeople_ReturnsOkResult_WithListOfPeople()
        {
            // Arrange: Set up mock service to return a list of people
            var mockPeopleList = new List<Person>
        {
            new Person { Id = 1, Name = "John Doe", Address = "123 Main St" },
            new Person { Id = 2, Name = "Jane Smith", Address = "456 Elm St" }
        };

            _mockPeopleService.Setup(service => service.GetPeopleAsync()).ReturnsAsync(mockPeopleList);

            // Act: Call the GetPeople() method
            var result = await _controller.GetPeople();

            // Assert: Verify the result
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnPeople = Assert.IsType<List<Person>>(okResult.Value);
            Assert.Equal(2, returnPeople.Count);
        }

        // Test for GetPerson(id) - GET: api/people/{id}
        [Fact]
        public async Task GetPerson_ReturnsOkResult_WithPerson()
        {
            // Arrange: Set up mock service to return a person
            var mockPerson = new Person { Id = 1, Name = "John Doe", Address = "123 Main St" };
            _mockPeopleService.Setup(service => service.GetPersonByIdAsync(1)).ReturnsAsync(mockPerson);

            // Act: Call the GetPerson() method
            var result = await _controller.GetPerson(1);

            // Assert: Verify the result
            var okResult = Assert.IsType<OkObjectResult>(result.Result);
            var returnPerson = Assert.IsType<Person>(okResult.Value);
            Assert.Equal(1, returnPerson.Id);
            Assert.Equal("John Doe", returnPerson.Name);
        }

        [Fact]
        public async Task GetPerson_ReturnsNotFound_WhenPersonDoesNotExist()
        {
            // Arrange: Set up mock service to return null
            _mockPeopleService.Setup(service => service.GetPersonByIdAsync(100)).ReturnsAsync((Person)null);

            // Act: Call the GetPerson() method
            var result = await _controller.GetPerson(100);

            // Assert: Verify that it returns a NotFound result
            Assert.IsType<NotFoundResult>(result.Result);
        }
    }
    //Unit tests for simpler controler
    //[Fact]
    //public void GetPeople_ReturnsAllPeople()
    //{
    //    // Arrange
    //    var controller = new PeopleController();

    //    // Act
    //    var result = controller.GetPeople();

    //    // Assert
    //    var actionResult = Assert.IsType<ActionResult<IEnumerable<Person>>>(result);
    //    var returnValue = Assert.IsType<List<Person>>(actionResult.Value);
    //    Assert.Equal(3, returnValue.Count);
    //}

    //[Fact]
    //public void GetPerson_ReturnsPersonById()
    //{
    //    // Arrange
    //    var controller = new PeopleController();

    //    // Act
    //    var result = controller.GetPerson(1);

    //    // Assert
    //    var actionResult = Assert.IsType<ActionResult<Person>>(result);
    //    var returnValue = Assert.IsType<Person>(actionResult.Value);
    //    Assert.Equal(1, returnValue.Id);
    //    Assert.Equal("John Doe", returnValue.Name);
    //}

    //[Fact]
    //public void GetPerson_ReturnsNotFoundForInvalidId()
    //{
    //    // Arrange
    //    var controller = new PeopleController();

    //    // Act
    //    var result = controller.GetPerson(999);

    //    // Assert
    //    Assert.IsType<NotFoundResult>(result.Result);
    //}
}