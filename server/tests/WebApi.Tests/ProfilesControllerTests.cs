using Application.DTOs;
using Application.Service.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class ProfilesControllerTests
    {
        IProfileService profileService;
        public ProfilesControllerTests()
        {
            profileService = A.Fake<IProfileService>();
        }

        #region Get
        [Fact]
        public async Task Get_With_Data_Returns_Ok()
        {
            // Arrange
            var profileDto = A.Dummy<ProfileDto>();
            A.CallTo(() => profileService.Get()).Returns(Task.FromResult(profileDto));

            var controller = new ProfilesController(profileService);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = result as OkObjectResult;
            Assert.Same(profileDto, okResult?.Value);
        }

        [Fact]
        public async Task Get_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => profileService.Get()).Throws(new Exception());
            var controller = new ProfilesController(profileService);

            // Act
            var result = await controller.Get();

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult?.StatusCode);
        }
        #endregion

        #region Put
        [Fact]
        public async Task Put_For_Successful_Update_Returns_Ok()
        {
            // Arrange
            A.CallTo(() => profileService.Update(A<ProfileDto>._)).Returns(Task.FromResult(true));
            var controller = new ProfilesController(profileService);
            var profileDto = A.Dummy<ProfileDto>();

            // Act
            var result = await controller.Put(profileDto);

            // Assert
            Assert.IsType<OkResult>(result);
        }

        [Fact]
        public async Task Put_For_Failed_Update_Returns_BadRequest()
        {
            // Arrange
            A.CallTo(() => profileService.Update(A<ProfileDto>._)).Returns(Task.FromResult(false));
            var controller = new ProfilesController(profileService);
            var profileDto = A.Dummy<ProfileDto>();

            // Act
            var result = await controller.Put(profileDto);

            // Assert
            Assert.IsType<BadRequestResult>(result);
        }

        [Fact]
        public async Task Put_With_Invalid_Model_Returns_BadRequest()
        {
            // Arrange
            var controller = new ProfilesController(profileService);
            var invalidProfileDto = A.Dummy<ProfileDto>();
            controller.ModelState.AddModelError("Name", "Name is required");

            // Act
            var result = await controller.Put(invalidProfileDto);

            // Assert
            Assert.IsType<BadRequestObjectResult>(result);
        }

        [Fact]
        public async Task Put_On_Exception_Returns_InternalServerError()
        {
            // Arrange
            A.CallTo(() => profileService.Update(A<ProfileDto>._)).Throws(new Exception());
            var controller = new ProfilesController(profileService);

            // Act
            var result = await controller.Put(A.Dummy<ProfileDto>());

            // Assert
            Assert.IsType<StatusCodeResult>(result);
            var statusCodeResult = result as StatusCodeResult;
            Assert.Equal(StatusCodes.Status500InternalServerError, statusCodeResult?.StatusCode);
        }
        #endregion
    }
}
