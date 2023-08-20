using Application.DTOs;
using Application.Service;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class EducationsControllerTests
    {
        #region Get
        [Fact]
        public async Task Get_With_Data_Returns_OkResult()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            var dummyEducationData = A.CollectionOfDummy<EducationDTO>(3);
            A.CallTo(() => educationService.GetAll()).Returns(dummyEducationData);
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<EducationDTO>>(okResult.Value);
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public async Task Get_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.GetAll()).Throws(new Exception());
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Get();

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(500, statusCodeResult.StatusCode);
        }

        [Fact]
        public async Task GetById_With_Valid_Id_Returns_OkResult()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            var expectedDto = A.Dummy<EducationDTO>();
            var validId = expectedDto.Id;
            A.CallTo(() => educationService.GetById(validId)).Returns(expectedDto);
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Get(validId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            var id = Guid.NewGuid();
            A.CallTo(() => educationService.GetById(id)).Throws(new Exception());
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Get(id);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
