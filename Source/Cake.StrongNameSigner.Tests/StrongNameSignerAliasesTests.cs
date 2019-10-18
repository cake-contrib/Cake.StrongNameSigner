using FluentAssertions;
using Xunit;

namespace Cake.StrongNameSigner.Tests
{
    public class StrongNameSignerAliasesTests
    {
        [Fact]
        public void Should_Use_Same_Settings_As_Specified()
        {
            var fixture = new StrongNameSignerAliasesFixture();

            var expected = new StrongNameSignerSettings
            {
                Password = "bob"
            };

            fixture.Settings = expected;

            var result = fixture.Run();

            result.Args.Should().ContainAll(new[]
            {
                $"-p \"{expected.Password}\""
            });
        }
    }
}
