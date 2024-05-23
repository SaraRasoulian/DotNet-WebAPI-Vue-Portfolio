namespace Application.Tests;

public class SocialLinkServiceTests
{
    private readonly IUnitOfWork unitOfWork;
    private readonly ISocialLinkRepository socialLinkRepository;

    public SocialLinkServiceTests()
    {
        unitOfWork = A.Fake<IUnitOfWork>();
        socialLinkRepository = A.Fake<ISocialLinkRepository>();
        A.CallTo(() => unitOfWork.SocialLink).Returns(socialLinkRepository);
    }

    [Fact]
    public async Task GetAll_With_Data_Returns_List_Of_SocialLinkDto()
    {
        // Arrange
        var SocialLinkData = new List<SocialLink>();
        A.CallTo(() => socialLinkRepository.GetAll()).Returns(SocialLinkData);
        var SocialLinkService = new SocialLinkService(unitOfWork);

        // Act
        var result = await SocialLinkService.GetAll();

        // Assert
        Assert.NotNull(result);
        Assert.IsAssignableFrom<IEnumerable<SocialLinkDto>>(result);
        Assert.Equal(SocialLinkData.Count, result.Count());
    }

    [Fact]
    public async Task GetById_With_Data_Returns_SocialLinkDto()
    {
        // Arrange
        var SocialLinkId = Guid.NewGuid();
        var SocialLinkData = A.Dummy<SocialLink>();
        A.CallTo(() => socialLinkRepository.GetById(SocialLinkId)).Returns(SocialLinkData);
        var SocialLinkService = new SocialLinkService(unitOfWork);

        // Act
        var result = await SocialLinkService.GetById(SocialLinkId);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<SocialLinkDto>(result);
    }

    [Fact]
    public async Task Add_Returns_Added_SocialLinkDto()
    {
        // Arrange
        var SocialLinkDto = A.Dummy<SocialLinkDto>();
        var addedSocialLink = SocialLinkDto.Adapt<SocialLink>();
        addedSocialLink.Id = Guid.NewGuid();
        A.CallTo(() => socialLinkRepository.Add(A<SocialLink>._)).Returns(addedSocialLink);

        var SocialLinkService = new SocialLinkService(unitOfWork);

        // Act
        var result = await SocialLinkService.Add(SocialLinkDto);

        // Assert
        Assert.NotNull(result);
        Assert.IsType<SocialLinkDto>(result);
        Assert.Equal(addedSocialLink.Id, result.Id);
    }

    [Fact]
    public async Task Update_For_Successful_Update_Returns_True()
    {
        // Arrange
        var existingId = Guid.NewGuid();
        var existingSocialLink = A.Dummy<SocialLink>();
        existingSocialLink.Id = existingId;
        A.CallTo(() => socialLinkRepository.GetById(existingId)).Returns(existingSocialLink);

        var updatedSocialLinkDto = A.Dummy<SocialLinkDto>();
        updatedSocialLinkDto.Id = existingId;
        var SocialLinkService = new SocialLinkService(unitOfWork);

        // Act
        var result = await SocialLinkService.Update(existingId, updatedSocialLinkDto);

        // Assert
        Assert.True(result);
        A.CallTo(() => unitOfWork.SocialLink.Update(A<SocialLink>.That.Matches(e => e.Id == existingId))).MustHaveHappenedOnceExactly();
        A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
    }

    [Fact]
    public async Task Update_For_Id_Mismatch_Returns_False()
    {
        // Arrange
        var SocialLinkService = new SocialLinkService(unitOfWork);
        var invalidSocialLinkDto = A.Dummy<SocialLinkDto>();
        var existingId = Guid.NewGuid();

        // Act
        var result = await SocialLinkService.Update(existingId, invalidSocialLinkDto);

        // Assert
        Assert.False(result);
        A.CallTo(() => unitOfWork.SocialLink.GetById(A<Guid>._)).MustNotHaveHappened();
        A.CallTo(() => unitOfWork.SocialLink.Update(A<SocialLink>._)).MustNotHaveHappened();
        A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustNotHaveHappened();
    }

    [Fact]
    public async Task Delete_With_Existing_Id_Returns_True()
    {
        // Arrange
        var existingId = Guid.NewGuid();
        var existingSocialLink = A.Dummy<SocialLink>();
        A.CallTo(() => socialLinkRepository.GetById(existingId)).Returns(existingSocialLink);

        var SocialLinkService = new SocialLinkService(unitOfWork);

        // Act
        var result = await SocialLinkService.Delete(existingId);

        // Assert
        Assert.True(result);
        A.CallTo(() => unitOfWork.SocialLink.Delete(existingSocialLink)).MustHaveHappenedOnceExactly();
        A.CallTo(() => unitOfWork.SaveChangesAsync(default)).MustHaveHappenedOnceExactly();
    }
}
