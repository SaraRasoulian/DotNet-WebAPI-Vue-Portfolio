using Application.DTOs;
using Application.Interfaces;
using Application.Service;
using Domain.Entities;
using Domain.Interfaces;
using FakeItEasy;
namespace Application.Tests
{
    public class EducationServiceTests
    {
        [Fact]
        public async Task GetAll_With_Data_Should_Return_List_Of_EducationDTO()
        {
            // Arrange
            var unitOfWork = A.Fake<IUnitOfWork>();
            var educationRepository = A.Fake<IEducationRepository>();
            A.CallTo(() => unitOfWork.Education).Returns(educationRepository);
            var educationData = new List<Education>();
            A.CallTo(() => educationRepository.GetAll()).Returns(educationData);
            var educationService = new EducationService(unitOfWork);

            // Act
            var result = await educationService.GetAll();

            // Assert
            Assert.NotNull(result);
            Assert.IsAssignableFrom<IEnumerable<EducationDTO>>(result);
            Assert.Equal(educationData.Count, result.Count());
        }
    }
}
