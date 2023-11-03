using Application.DTOs;
using Application.Service.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class SocialLinksControllerTests
    {
        private readonly ISocialLinkService socialLinkService;
        public SocialLinksControllerTests()
        {
            socialLinkService = A.Fake<ISocialLinkService>();
        }

        #region Get
        [Fact]
        public async Task Get_With_Data_Returns_Ok()
        {
            // Arrange            
            var dummySocialLinkData = A.CollectionOfDummy<SocialLinkDto>(3);
            A.CallTo(() => socialLinkService.GetAll()).Returns(dummySocialLinkData);
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Get();

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var data = Assert.IsType<List<SocialLinkDto>>(okResult.Value);
            Assert.Equal(3, data.Count);
        }

        [Fact]
        public async Task Get_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => socialLinkService.GetAll()).Throws(new Exception());
            var controller = new SocialLinksController(socialLinkService);

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
            var expectedDto = A.Dummy<SocialLinkDto>();
            var validId = expectedDto.Id;
            A.CallTo(() => socialLinkService.GetById(validId)).Returns(expectedDto);
            var controller = new SocialLinksController(socialLinkService);

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
            A.CallTo(() => socialLinkService.GetById(id)).Throws(new Exception());
            var controller = new SocialLinksController(socialLinkService);

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
            var validSocialLinkDto = A.Dummy<SocialLinkDto>();
            A.CallTo(() => socialLinkService.Add(validSocialLinkDto)).Returns(validSocialLinkDto);
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Post(validSocialLinkDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
        }

        [Fact]
        public async Task Post_With_Null_Input_Returns_BadRequest()
        {
            // Arrange
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Post(null);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Post_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => socialLinkService.Add(A<SocialLinkDto>._)).Throws(new Exception());
            var controller = new SocialLinksController(socialLinkService);
            var validSocialLinkDto = A.Dummy<SocialLinkDto>();

            // Act
            var result = await controller.Post(validSocialLinkDto);

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
            A.CallTo(() => socialLinkService.Update(A<Guid>._, A<SocialLinkDto>._)).Returns(true);
            var controller = new SocialLinksController(socialLinkService);
            var existingId = Guid.NewGuid();
            var socialLinkDto = A.Dummy<SocialLinkDto>();

            // Act
            var result = await controller.Put(existingId, socialLinkDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_For_Failed_Update_Returns_BadRequest()
        {
            // Arrange
            A.CallTo(() => socialLinkService.Update(A<Guid>._, A<SocialLinkDto>._)).Returns(false);
            var controller = new SocialLinksController(socialLinkService);
            var existingId = Guid.NewGuid();
            var socialLinkDto = A.Dummy<SocialLinkDto>();

            // Act
            var result = await controller.Put(existingId, socialLinkDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_With_Null_Input_Returns_BadRequest()
        {
            // Arrange          
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Put(Guid.NewGuid(), null);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => socialLinkService.Update(A<Guid>._, A<SocialLinkDto>._)).Throws(new Exception());
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Put(Guid.NewGuid(), A.Dummy<SocialLinkDto>());

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
            A.CallTo(() => socialLinkService.Delete(A<Guid>._)).Returns(true);
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Delete_For_Failed_Deletion_Returns_BadRequest()
        {
            // Arrange
            A.CallTo(() => socialLinkService.Delete(A<Guid>._)).Returns(false);
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Delete_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => socialLinkService.Delete(A<Guid>._)).Throws(new Exception());
            var controller = new SocialLinksController(socialLinkService);

            // Act
            var result = await controller.Delete(Guid.NewGuid());

            // Assert
            var statusCodeResult = Assert.IsType<StatusCodeResult>(result);
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult.StatusCode);
        }
        #endregion
    }
}
