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
        public async Task GetAll_With_Data_Returns_List_Of_EducationDto()
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
            Assert.IsAssignableFrom<IEnumerable<EducationDto>>(result);
            Assert.Equal(educationData.Count, result.Count());
        }

        [Fact]
        public async Task GetById_With_Data_Returns_EducationDto()
        {
            // Arrange
            var unitOfWork = A.Fake<IUnitOfWork>();
            var educationRepository = A.Fake<IEducationRepository>();
            A.CallTo(() => unitOfWork.Education).Returns(educationRepository);
            var educationId = Guid.NewGuid();
            var educationData = A.Dummy<Education>();
            A.CallTo(() => educationRepository.GetById(educationId)).Returns(educationData);
            var educationService = new EducationService(unitOfWork);

            // Act
            var result = await educationService.GetById(educationId);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EducationDto>(result);
        }

        [Fact]
        public async Task Delete_With_Existing_Id_Returns_True()
        {
            // Arrange
            var unitOfWork = A.Fake<IUnitOfWork>();
            var educationRepository = A.Fake<IEducationRepository>();
            A.CallTo(() => unitOfWork.Education).Returns(educationRepository);

            var existingId = Guid.NewGuid();
            var existingEducation = A.Dummy<Education>();
            A.CallTo(() => educationRepository.GetById(existingId)).Returns(existingEducation);

            var educationService = new EducationService(unitOfWork);

            // Act
            var result = await educationService.Delete(existingId);

            // Assert
            Assert.True(result);
            A.CallTo(() => unitOfWork.Education.Delete(existingEducation)).MustHaveHappenedOnceExactly();
            A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
        }
    }
}
