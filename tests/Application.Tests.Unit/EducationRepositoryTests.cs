using Application.DTOs;
using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Repositories;
using Moq;
using Newtonsoft.Json.Linq;

namespace Application.Tests.Unit
{
    public class EducationRepositoryTests
    {
        [Fact]
        public async Task GetById_ValidId_ReturnsEducationDTO()
        {
            // Arrange
            var expectedId = Guid.NewGuid();
            var educationMock = new Education
            {
                Id = expectedId,
                Degree = "a",
                FieldOfStudy = "b",
                School = "c",
                StartYear = "2020",
                EndYear = "2023",
                Description = "d"
            };

            var dbContextMock = new Mock<IPortfolioDbContext>();
            dbContextMock.Setup(db => db.Educations.FindAsync(It.IsAny<Guid>())).ReturnsAsync(educationMock);

            var educationRepository = new EducationRepository(dbContextMock.Object);

            // Act
            var result = await educationRepository.GetById(expectedId);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(expectedId, result.Id);
            Assert.IsType<EducationDTO>(result);
        }

        [Fact]
        public async Task GetById_InvalidId_ReturnsNull()
        {
            // Arrange
            var invalidId = Guid.NewGuid();
            var dbContextMock = new Mock<IPortfolioDbContext>();
            dbContextMock.Setup(db => db.Educations.FindAsync(It.IsAny<Guid>())).ReturnsAsync((Education)null);

            var educationRepository = new EducationRepository(dbContextMock.Object);

            // Act
            var result = await educationRepository.GetById(invalidId);

            // Assert
            Assert.Null(result);
        }
    }
}
