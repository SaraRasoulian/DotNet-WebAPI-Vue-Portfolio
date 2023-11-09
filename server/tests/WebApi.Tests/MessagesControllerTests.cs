using Application.DTOs;
using Application.Service.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class MessagesControllerTests
    {
        private readonly IMessageService messageService;
        public MessagesControllerTests()
        {
            messageService = A.Fake<IMessageService>();
        }

        #region Get
        [Fact]
        public async Task Get_With_Data_Returns_Ok()
        {
            // Arrange            
            var dummyData = A.CollectionOfDummy<MessageDto>(5);
            A.CallTo(() => messageService.GetAll()).Returns(dummyData);
            var controller = new MessagesController(messageService);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<MessageDto>>(okResult.Value);
            Assert.Equal(5, data.Count);
        }

        [Fact]
        public async Task Get_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => messageService.GetAll()).Throws(new Exception());
            var controller = new MessagesController(messageService);

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
            var expectedDto = A.Dummy<MessageDto>();
            var validId = expectedDto.Id;
            A.CallTo(() => messageService.GetById(validId)).Returns(expectedDto);
            var controller = new MessagesController(messageService);

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
            A.CallTo(() => messageService.GetById(id)).Throws(new Exception());
            var controller = new MessagesController(messageService);

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
            var validMessageDto = A.Dummy<MessageDto>();
            A.CallTo(() => messageService.Add(validMessageDto)).Returns(validMessageDto);
            var controller = new MessagesController(messageService);

            // Act
            var result = await controller.Post(validMessageDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_With_Null_Input_Returns_BadRequest()
        {
            // Arrange
            var controller = new MessagesController(messageService);

            // Act
            var result = await controller.Post(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => messageService.Add(A<MessageDto>._)).Throws(new Exception());
            var controller = new MessagesController(messageService);
            var validMessageDto = A.Dummy<MessageDto>();

            // Act
            var result = await controller.Post(validMessageDto);

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
            A.CallTo(() => messageService.Delete(A<Guid>._)).Returns(true);
            var controller = new MessagesController(messageService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_For_Failed_Deletion_Returns_BadRequest()
        {
            // Arrange
            A.CallTo(() => messageService.Delete(A<Guid>._)).Returns(false);
            var controller = new MessagesController(messageService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => messageService.Delete(A<Guid>._)).Throws(new Exception());
            var controller = new MessagesController(messageService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
