using Application.DTOs;
using Application.Service.Interfaces;
using FakeItEasy;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;

namespace WebApi.Tests
{
    public class IdentityControllerTests
    {
        [Fact]
        public async Task Login_With_Valid_User_Returns_OkResult_With_Token()
        {
            // Arrange
            var identityService = A.Fake<IIdentityService>();
            A.CallTo(() => identityService.Login(A<UserLoginDto>._)).Returns("fakeJwtToken");

            var controller = new IdentityController(identityService);
            var userLoginDto = new UserLoginDto
            {
                UserName = "testuser",
                Password = "testpassword"
            };

            // Act
            var result = await controller.Login(userLoginDto);

            // Assert
            Assert.IsType<OkObjectResult>(result);
            var okResult = (OkObjectResult)result;
            Assert.Equal(StatusCodes.Status200OK, okResult.StatusCode);
            Assert.Equal("fakeJwtToken", okResult.Value);
        }

        [Fact]
        public async Task Login_With_Invalid_User_Returns_NoContent()
        {
            // Arrange
            var identityService = A.Fake<IIdentityService>();
            var returnValue = null as string;
            A.CallTo(() => identityService.Login(A<UserLoginDto>._)).Returns(returnValue);

            var controller = new IdentityController(identityService);
            var userLoginDto = new UserLoginDto
            {
                UserName = "testuser",
                Password = "testpassword"
            };

            // Act
            var result = await controller.Login(userLoginDto);

            // Assert
            Assert.IsType<NoContentResult>(result);
        }
    }
}
