
using NetCoreJwtAuthApi.Models;
using NetCoreJwtAuthApi.Services;
using Microsoft.Extensions.Configuration;
using Xunit;

public class JwtServiceTests
{
    [Fact]
    public void GenerateToken_ShouldReturnToken()
    {
        // Arrange
        var settings = new Dictionary<string, string>
        {
            {"Jwt:Key", "INI_KUNCI_RAHASIA_MINIMAL_32_CHAR"},
            {"Jwt:Issuer", "TestIssuer"},
            {"Jwt:Audience", "TestAudience"},
            {"Jwt:ExpireMinutes", "60"}
        };

        IConfiguration config = new ConfigurationBuilder()
            .AddInMemoryCollection(settings!)
            .Build();

        var jwtService = new JwtService(config);

        var user = new User
        {
            Username = "admin",
            Role = "Admin"
        };

        // Act
        var token = jwtService.GenerateToken(user);

        // Assert
        Assert.False(string.IsNullOrEmpty(token));
    }
}
