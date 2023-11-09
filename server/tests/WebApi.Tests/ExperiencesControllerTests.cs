using Application.DTOs;
using Application.Service.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class ExperiencesControllerTests
    {
        private readonly IExperienceService experienceService;
        public ExperiencesControllerTests()
        {
            experienceService = A.Fake<IExperienceService>();
        }

        #region Get
        [Fact]
        public async Task Get_With_Data_Returns_Ok()
        {
            // Arrange            
            var dummyData = A.CollectionOfDummy<ExperienceDto>(5);
            A.CallTo(() => experienceService.GetAll()).Returns(dummyData);
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<ExperienceDto>>(okResult.Value);
            Assert.Equal(5, data.Count);
        }

        [Fact]
        public async Task Get_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => experienceService.GetAll()).Throws(new Exception());
            var controller = new ExperiencesController(experienceService);

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
            var expectedDto = A.Dummy<ExperienceDto>();
            var validId = expectedDto.Id;
            A.CallTo(() => experienceService.GetById(validId)).Returns(expectedDto);
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Get(validId);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task GetById_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            var id = Guid.NewGuid();
            A.CallTo(() => experienceService.GetById(id)).Throws(new Exception());
            var controller = new ExperiencesController(experienceService);

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
            var validExperienceDto = A.Dummy<ExperienceDto>();
            A.CallTo(() => experienceService.Add(validExperienceDto)).Returns(validExperienceDto);
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Post(validExperienceDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_With_Null_Input_Returns_BadRequest()
        {
            // Arrange
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Post(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => experienceService.Add(A<ExperienceDto>._)).Throws(new Exception());
            var controller = new ExperiencesController(experienceService);
            var validExperienceDto = A.Dummy<ExperienceDto>();

            // Act
            var result = await controller.Post(validExperienceDto);

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
            A.CallTo(() => experienceService.Update(A<Guid>._, A<ExperienceDto>._)).Returns(true);
            var controller = new ExperiencesController(experienceService);
            var existingId = Guid.NewGuid();
            var experienceDto = A.Dummy<ExperienceDto>();

            // Act
            var result = await controller.Put(existingId, experienceDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_For_Failed_Update_Returns_BadRequest()
        {
            // Arrange
            A.CallTo(() => experienceService.Update(A<Guid>._, A<ExperienceDto>._)).Returns(false);
            var controller = new ExperiencesController(experienceService);
            var existingId = Guid.NewGuid();
            var experienceDto = A.Dummy<ExperienceDto>();

            // Act
            var result = await controller.Put(existingId, experienceDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_With_Null_Input_Returns_BadRequest()
        {
            // Arrange          
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Put(Guid.NewGuid(), null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => experienceService.Update(A<Guid>._, A<ExperienceDto>._)).Throws(new Exception());
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Put(Guid.NewGuid(), A.Dummy<ExperienceDto>());

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
            A.CallTo(() => experienceService.Delete(A<Guid>._)).Returns(true);
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_For_Failed_Deletion_Returns_BadRequest()
        {
            // Arrange
            A.CallTo(() => experienceService.Delete(A<Guid>._)).Returns(false);
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => experienceService.Delete(A<Guid>._)).Throws(new Exception());
            var controller = new ExperiencesController(experienceService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
