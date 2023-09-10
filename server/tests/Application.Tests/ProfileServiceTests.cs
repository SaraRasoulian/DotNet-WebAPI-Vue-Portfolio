using Application.DTOs;
using Application.Interfaces;
using Application.Service;
using Domain.Entities;
using Domain.Interfaces;
using FakeItEasy;

namespace Application.Tests
{
    public class ProfileServiceTests
    {
        IUnitOfWork unitOfWork;
        IProfileRepository profileRepository;

        public ProfileServiceTests()
        {
            unitOfWork = A.Fake<IUnitOfWork>();
            profileRepository = A.Fake<IProfileRepository>();
            A.CallTo(() => unitOfWork.Profile).Returns(profileRepository);
        }

        [Fact]
        public async Task Get_With_Data_Returns_ProfileDto()
        {
            // Arrange
            var existingProfile = A.Dummy<Profile>();
            A.CallTo(() => profileRepository.Get()).Returns(existingProfile);
            var profileService = new ProfileService(unitOfWork);

            // Act
            var result = await profileService.Get();

            // Assert
            Assert.NotNull(result);
            Assert.IsType<ProfileDto>(result);
        }

        [Fact]
        public async Task Update_For_Successful_Update_Returns_True()
        {
            // Arrange
            var existingProfile = A.Dummy<Profile>();
            A.CallTo(() => profileRepository.Get()).Returns(existingProfile);
            var updatedProfileDto = A.Dummy<ProfileDto>();
            updatedProfileDto.Id = existingProfile.Id;
            var profileService = new ProfileService(unitOfWork);

            // Act
            var result = await profileService.Update(updatedProfileDto);

            // Assert
            Assert.True(result);
            A.CallTo(() => unitOfWork.Profile.Update(A<Profile>.That.Matches(p => p.Id == existingProfile.Id))).MustHaveHappenedOnceExactly();
            A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
        }
    }
}
