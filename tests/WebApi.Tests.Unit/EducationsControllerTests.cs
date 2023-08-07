using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Unit
{
    public class EducationsControllerTests
    {
        #region Get
        [Fact]
        public async Task Get_ExistingList_Should_Return_OkResult_With_List()
        {
            // Arrange
            var expectedEducations = new List<EducationDTO>
        {
            new EducationDTO { Id = Guid.NewGuid(), },
            new EducationDTO { Id = Guid.NewGuid(), },
            new EducationDTO { Id = Guid.NewGuid(), }
        };

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            educationsRepositoryMock.Setup(repo => repo.GetAll()).ReturnsAsync(expectedEducations);

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducations = Assert.IsAssignableFrom<IEnumerable<EducationDTO>>(okResult.Value);
            Assert.Equal(expectedEducations.Count, returnedEducations.Count());
        }

        [Fact]
        public async Task Get_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var educationsRepositoryMock = new Mock<IEducationRepository>();
            educationsRepositoryMock.Setup(repo => repo.GetAll()).ThrowsAsync(new Exception("Simulated exception"));

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get();

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetById_ExistingId_Should_Return_OkResult_With_Education()
        {
            // Arrange
            var expectedId = Guid.NewGuid();
            var expectedEducation = new EducationDTO { Id = expectedId, };

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            educationsRepositoryMock.Setup(repo => repo.GetById(expectedId)).ReturnsAsync(expectedEducation);

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get(expectedId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
            Assert.Equal(expectedId, returnedEducation.Id);
        }

        [Fact]
        public async Task GetById_NonExistingId_Should_Return_NoContentResult()
        {
            // Arrange
            var nonExistingId = Guid.NewGuid();

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            educationsRepositoryMock.Setup(repo => repo.GetById(nonExistingId)).ReturnsAsync((EducationDTO)null);

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get(nonExistingId);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status204NoContent, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetById_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var existingId = Guid.NewGuid();

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            educationsRepositoryMock.Setup(repo => repo.GetById(existingId)).ThrowsAsync(new Exception("Simulated exception"));

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Get(existingId);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }

        #endregion

        #region Post
        [Fact]
        public async Task Post_Valid_Model_Should_Return_OkResult_With_Education()
        {
            // Arrange
            var validModel = new EducationDTO { /* initialize valid properties */ };
            var expectedResult = new EducationDTO { Id = Guid.NewGuid(), /* add other necessary properties */ };

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            educationsRepositoryMock.Setup(repo => repo.Add(validModel)).ReturnsAsync(expectedResult);

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Post(validModel);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var returnedEducation = Assert.IsType<EducationDTO>(okResult.Value);
            Assert.Equal(expectedResult.Id, returnedEducation.Id);
            // Add other assertions for property values if needed
        }

        [Fact]
        public async Task Post_Invalid_Model_Should_Return_BadRequest()
        {
            // Arrange
            var invalidModel = new EducationDTO { /* initialize invalid properties */ };

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            var educationController = new EducationsController(educationsRepositoryMock.Object);
            educationController.ModelState.AddModelError("PropertyName", "Some error message");

            // Act
            var result = await educationController.Post(invalidModel);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_Null_Input_Should_Return_BadRequest()
        {
            // Arrange
            //var validModel = new EducationDTO { /* initialize valid properties */ };

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            //educationsRepositoryMock.Setup(repo => repo.Add(validModel)).ReturnsAsync((EducationDTO)null);

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Post(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_On_Exception_Should_Return_InternalServerError()
        {
            // Arrange
            var validModel = new EducationDTO { /* initialize valid properties */ };

            var educationsRepositoryMock = new Mock<IEducationRepository>();
            educationsRepositoryMock.Setup(repo => repo.Add(validModel)).ThrowsAsync(new Exception("Simulated exception"));

            var educationController = new EducationsController(educationsRepositoryMock.Object);

            // Act
            var result = await educationController.Post(validModel);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
