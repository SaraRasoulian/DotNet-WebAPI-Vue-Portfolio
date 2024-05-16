namespace WebApi.Tests.Integration.ControllersTests;

public class IdentityControllerTests : BaseControllerTest
{
    public IdentityControllerTests(IntegrationTestWebApplicationFactory factory) : base(factory)
    { }

    [Fact]
    public async Task Login_Returns_OK_With_Token()
    {
        // Arrange
        // Using the one user created by database seed
        UserLoginDto userLoginDto = new UserLoginDto
        {
            UserName = "admin",
            Password = "123456"
        };

        // Act
        var loginResponse = await _httpClient.PostAsJsonAsync("api/identity/login", userLoginDto);

        // Assert
        loginResponse.EnsureSuccessStatusCode();

        string token = await loginResponse.Content.ReadAsStringAsync();
        token.Should().NotBeEmpty();
        token.Should().NotBeNull();
    }

    [Fact]
    public async Task Login_With_Wrong_Password_Returns_NoContent()
    {
        // Arrange
        UserLoginDto userLoginDto = new UserLoginDto
        {
            UserName = "admin",
            Password = "aaa"
        };

        // Act
        var loginResponse = await _httpClient.PostAsJsonAsync("api/identity/login", userLoginDto);

        // Assert
        loginResponse.Should().HaveStatusCode(HttpStatusCode.NoContent);

        string token = await loginResponse.Content.ReadAsStringAsync();
        token.Should().BeEmpty();
    }

    [Fact]
    public async Task ChangePassword_Returns_OK()
    {
        // Arrange
        await AuthenticateAsync();

        // Using the one user created by database seed
        PasswordDto passwordDto = new PasswordDto
        {
            currentPassword = "123456",
            newPassword = "admin123456",
            confirmNewPassword = "admin123456",
        };

        // Act
        var response = await _httpClient.PutAsJsonAsync("api/identity/change-password", passwordDto);

        // Assert
        response.EnsureSuccessStatusCode();
    }

    [Fact]
    public async Task ChangePassword_With_Mismatch_Passwords_Returns_BadRequest()
    {
        // Arrange
        await AuthenticateAsync();

        // Using the one user created by database seed
        PasswordDto passwordDto = new PasswordDto
        {
            currentPassword = "123456",
            newPassword = "admin123456",
            confirmNewPassword = "admin1",
        };

        // Act
        var response = await _httpClient.PutAsJsonAsync("api/identity/change-password", passwordDto);

        // Assert
        response.Should().HaveStatusCode(HttpStatusCode.BadRequest);
    }
}
