using Moq;
using NetCoreJwtAuthApi.Data.Repositories;
using NetCoreJwtAuthApi.DTOs;
using NetCoreJwtAuthApi.Models;
using NetCoreJwtAuthApi.Services;
using Microsoft.Extensions.Configuration;
using NetCoreJwtAuthApi.Helpers;
using Xunit;

public class AuthServiceTests
{
    [Fact]
    public void Login_ValidUser_ReturnsToken()
    {
        var password = "123";
        // Arrange
        var user = new User
        {
            Username = "admin",
            Role = "Admin",
            PasswordHash = PasswordHasher.Hash(password)
        };

        var userRepoMock = new Mock<IUserRepository>();
        userRepoMock
            .Setup(r => r.GetByUsername("admin"))
            .Returns(user);

        var settings = new Dictionary<string, string>
        {
            { "Jwt:Key", "INI_KUNCI_RAHASIA_MINIMAL_32_CHAR" },
            { "Jwt:Issuer", "TestIssuer" },
            { "Jwt:Audience", "TestAudience" },
            { "Jwt:ExpireMinutes", "60" }
        };

        IConfiguration config = new ConfigurationBuilder()
            .AddInMemoryCollection(settings!)
            .Build();

        var jwtService = new JwtService(config);

        var authService = new AuthService(
            userRepoMock.Object,
            jwtService
        );

        var dto = new LoginDto
        {
            Username = "admin",
            Password = "123"
        };

        // Act
        var token = authService.Login(dto);

        // Assert
        Assert.False(string.IsNullOrEmpty(token));
    }
}
