using NetCoreJwtAuthApi.Helpers;
using Xunit;

namespace NetCoreJwtAuthApi.Tests.Helpers
{
    public class PasswordHasherTests
    {
        [Fact]
        public void Hash_And_Verify_ShouldMatch()
        {
            var password = "secret123";
            var hash = PasswordHasher.Hash(password);

            var result = PasswordHasher.Verify(password, hash);

            Assert.True(result);
        }

        [Fact]
        public void Verify_WrongPassword_ShouldFail()
        {
            var hash = PasswordHasher.Hash("secret123");

            var result = PasswordHasher.Verify("wrong", hash);

            Assert.False(result);
        }
    }
}
