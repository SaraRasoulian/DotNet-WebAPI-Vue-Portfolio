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
        public async Task Get_With_Data_Returns_Ok()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            var dummyEducationData = A.CollectionOfDummy<EducationDto>(3);
            A.CallTo(() => educationService.GetAll()).Returns(dummyEducationData);
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<EducationDto>>(okResult.Value);
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
        public async Task GetById_With_Valid_Id_Returns_Ok()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            var expectedDto = A.Dummy<EducationDto>();
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

        #region Post
        [Fact]
        public async Task Post_With_Valid_Model_Returns_Ok()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            var validEducationDto = A.Dummy<EducationDto>();
            A.CallTo(() => educationService.Add(validEducationDto)).Returns(validEducationDto);
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Post(validEducationDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_With_Null_Input_Returns_BadRequest()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Post(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.Add(A<EducationDto>._)).Throws(new Exception());

            var controller = new EducationsController(educationService);
            var validEducationDto = A.Dummy<EducationDto>();

            // Act
            var result = await controller.Post(validEducationDto);

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion

        #region Put
        [Fact]
        public async Task Put_For_Successful_Update_Returns_Ok()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.Update(A<Guid>._, A<EducationDto>._)).Returns(true);
            var controller = new EducationsController(educationService);
            var existingId = Guid.NewGuid();
            var educationDto = A.Dummy<EducationDto>();

            // Act
            var result = await controller.Put(existingId, educationDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_For_Failed_Update_Returns_BadRequest()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.Update(A<Guid>._, A<EducationDto>._)).Returns(false);
            var controller = new EducationsController(educationService);
            var existingId = Guid.NewGuid();
            var educationDto = A.Dummy<EducationDto>();

            // Act
            var result = await controller.Put(existingId, educationDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_With_Null_Input_Returns_BadRequest()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();

            var controller = new EducationsController(educationService);
            // Act
            var result = await controller.Put(Guid.NewGuid(), null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.Update(A<Guid>._, A<EducationDto>._)).Throws(new Exception());
            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Put(Guid.NewGuid(), A.Dummy<EducationDto>());

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion

        #region Delete
        [Fact]
        public async Task Delete_For_Successful_Deletion_Returns_Ok()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.Delete(A<Guid>._)).Returns(true);

            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_For_Failed_Deletion_Returns_BadRequest()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.Delete(A<Guid>._)).Returns(false);

            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            var educationService = A.Fake<IEducationService>();
            A.CallTo(() => educationService.Delete(A<Guid>._)).Throws(new Exception());

            var controller = new EducationsController(educationService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
