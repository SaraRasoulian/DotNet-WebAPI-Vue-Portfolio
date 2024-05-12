namespace Application.Tests
{
    public class EducationServiceTests
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IEducationRepository educationRepository;

        public EducationServiceTests()
        {
            unitOfWork = A.Fake<IUnitOfWork>();
            educationRepository = A.Fake<IEducationRepository>();
            A.CallTo(() => unitOfWork.Education).Returns(educationRepository);
        }

        [Fact]
        public async Task GetAll_With_Data_Returns_List_Of_EducationDto()
        {
            // Arrange
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
        public async Task Add_Returns_Added_EducationDto()
        {
            // Arrange
            var educationDto = A.Dummy<EducationDto>();
            var addedEducation = educationDto.Adapt<Education>();
            addedEducation.Id = Guid.NewGuid();
            A.CallTo(() => educationRepository.Add(A<Education>._)).Returns(addedEducation);

            var educationService = new EducationService(unitOfWork);

            // Act
            var result = await educationService.Add(educationDto);

            // Assert
            Assert.NotNull(result);
            Assert.IsType<EducationDto>(result);
            Assert.Equal(addedEducation.Id, result.Id);
        }

        [Fact]
        public async Task Update_For_Successful_Update_Returns_True()
        {
            // Arrange
            var existingId = Guid.NewGuid();
            var existingEducation = A.Dummy<Education>();
            existingEducation.Id = existingId;
            A.CallTo(() => educationRepository.GetById(existingId)).Returns(existingEducation);

            var updatedEducationDto = A.Dummy<EducationDto>();
            updatedEducationDto.Id = existingId;
            var educationService = new EducationService(unitOfWork);

            // Act
            var result = await educationService.Update(existingId, updatedEducationDto);

            // Assert
            Assert.True(result);
            A.CallTo(() => unitOfWork.Education.Update(A<Education>.That.Matches(e => e.Id == existingId))).MustHaveHappenedOnceExactly();
            A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
        }

        [Fact]
        public async Task Update_For_Id_Mismatch_Returns_False()
        {
            // Arrange
            var educationService = new EducationService(unitOfWork);
            var invalidEducationDto = A.Dummy<EducationDto>();
            var existingId = Guid.NewGuid();

            // Act
            var result = await educationService.Update(existingId, invalidEducationDto);

            // Assert
            Assert.False(result);
            A.CallTo(() => unitOfWork.Education.GetById(A<Guid>._)).MustNotHaveHappened();
            A.CallTo(() => unitOfWork.Education.Update(A<Education>._)).MustNotHaveHappened();
            A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustNotHaveHappened();
        }

        [Fact]
        public async Task Delete_With_Existing_Id_Returns_True()
        {
            // Arrange
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
