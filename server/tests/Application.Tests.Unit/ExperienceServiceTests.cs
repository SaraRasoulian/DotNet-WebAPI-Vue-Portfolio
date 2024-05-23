namespace Application.Tests;

public class ExperienceServiceTests
{
    private readonly IUnitOfWork unitOfWork;
    private readonly IExperienceRepository educationRepository;

    public ExperienceServiceTests()
    {
        unitOfWork = A.Fake<IUnitOfWork>();
        educationRepository = A.Fake<IExperienceRepository>();
        A.CallTo(() => unitOfWork.Experience).Returns(educationRepository);
    }

    [Fact]
    public async Task GetAll_With_Data_Returns_List_Of_ExperienceDto()
    {
        // Arrange
        var educationData = new List<Experience>();
        A.CallTo(() => educationRepository.GetAll()).Returns(educationData);
        var educationService = new ExperienceService(unitOfWork);

        // Act
        var result = await educationService.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<ExperienceDto>>(result);
        Assert.Equal(educationData.Count, result.Count());
    }

    [Fact]
    public async Task GetById_With_Data_Returns_ExperienceDto()
    {
        // Arrange
        var educationId = Guid.NewGuid();
        var educationData = A.Dummy<Experience>();
        A.CallTo(() => educationRepository.GetById(educationId)).Returns(educationData);
        var educationService = new ExperienceService(unitOfWork);

        // Act
        var result = await educationService.GetById(educationId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ExperienceDto>(result);
    }

    [Fact]
    public async Task Add_Returns_Added_ExperienceDto()
    {
        // Arrange
        var educationDto = A.Dummy<ExperienceDto>();
        var addedExperience = educationDto.Adapt<Experience>();
        addedExperience.Id = Guid.NewGuid();
        A.CallTo(() => educationRepository.Add(A<Experience>._)).Returns(addedExperience);

        var educationService = new ExperienceService(unitOfWork);

        // Act
        var result = await educationService.Add(educationDto);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<ExperienceDto>(result);
        Assert.Equal(addedExperience.Id, result.Id);
    }

    [Fact]
    public async Task Update_For_Successful_Update_Returns_True()
    {
        // Arrange
        var existingId = Guid.NewGuid();
        var existingExperience = A.Dummy<Experience>();
        existingExperience.Id = existingId;
        A.CallTo(() => educationRepository.GetById(existingId)).Returns(existingExperience);

        var updatedExperienceDto = A.Dummy<ExperienceDto>();
        updatedExperienceDto.Id = existingId;
        var educationService = new ExperienceService(unitOfWork);

        // Act
        var result = await educationService.Update(existingId, updatedExperienceDto);

        // Assert
        Assert.True(result);
        A.CallTo(() => unitOfWork.Experience.Update(A<Experience>.That.Matches(e => e.Id == existingId))).MustHaveHappenedOnceExactly();
        A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task Update_For_Id_Mismatch_Returns_False()
    {
        // Arrange
        var educationService = new ExperienceService(unitOfWork);
        var invalidExperienceDto = A.Dummy<ExperienceDto>();
        var existingId = Guid.NewGuid();

        // Act
        var result = await educationService.Update(existingId, invalidExperienceDto);

        // Assert
        Assert.False(result);
        A.CallTo(() => unitOfWork.Experience.GetById(A<Guid>._)).MustNotHaveHappened();
        A.CallTo(() => unitOfWork.Experience.Update(A<Experience>._)).MustNotHaveHappened();
        A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustNotHaveHappened();
    }

    [Fact]
    public async Task Delete_With_Existing_Id_Returns_True()
    {
        // Arrange
        var existingId = Guid.NewGuid();
        var existingExperience = A.Dummy<Experience>();
        A.CallTo(() => educationRepository.GetById(existingId)).Returns(existingExperience);

        var educationService = new ExperienceService(unitOfWork);

        // Act
        var result = await educationService.Delete(existingId);

        // Assert
        Assert.True(result);
        A.CallTo(() => unitOfWork.Experience.Delete(existingExperience)).MustHaveHappenedOnceExactly();
        A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
    }
}
