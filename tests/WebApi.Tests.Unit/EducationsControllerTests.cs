using Application.DTOs;
using Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using WebApi.Controllers;

namespace WebApi.Tests.Unit
{
    public class EducationsControllerTests
    {
        [Fact]
        public async Task Get_ReturnsOkResultWithEducationList()
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
    }
}
