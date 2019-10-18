using System;
using Cake.Core;
using Cake.Testing;
using FluentAssertions;
using Xunit;

namespace Cake.StrongNameSigner.Tests
{
    public class StrongNameSignerRunnerTests
    {
        [Fact]
        public void Should_Throw_If_Settings_Are_Null()
        {
            var fixture = new StrongNameSignerRunnerFixture { Settings = null };

            Action result = () => fixture.Run();

            Assert.Throws<ArgumentNullException>(result);
        }

        [Fact]
        public void Should_Throw_If_StrongNameSigner_Executable_Was_Not_Found()
        {
            var fixture = new StrongNameSignerRunnerFixture();
            fixture.GivenDefaultToolDoNotExist();
            const string expectedMessage = "StrongNameSigner: Could not locate executable.";

            Action result = () => fixture.Run();

            var ex = Assert.Throws<CakeException>(result);
            Assert.Equal(expectedMessage, ex.Message);
        }

        [Theory]
        [InlineData("/bin/tools/StrongNameSigner/StrongNameSigner.Console.exe", "/bin/tools/StrongNameSigner/StrongNameSigner.Console.exe")]
        [InlineData("./tools/StrongNameSigner/StrongNameSigner.Console.exe", "/Working/tools/StrongNameSigner/StrongNameSigner.Console.exe")]
        public void Should_Use_StrongNameSigner_Runner_From_Tool_Path_If_Provided(string toolPath, string expected)
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture { Settings = { ToolPath = toolPath } };
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.Should().Be(expected);
        }

        [Theory]
        [InlineData("C:/StrongNameSigner/StrongNameSigner.Console.exe", "C:/StrongNameSigner/StrongNameSigner.Console.exe")]
        public void Should_Use_StrongNameSigner_Runner_From_Tool_Path_If_Provided_On_Windows(string toolPath, string expected)
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture { Settings = { ToolPath = toolPath } };
            fixture.GivenSettingsToolPathExist();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.Should().Be(expected);
        }

        [Fact]
        public void Should_Find_StrongNameSigner_Runner_If_Tool_Path_Not_Provided()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            result.Path.FullPath.Should().Be("/Working/tools/StrongNameSigner.Console.exe");
        }

                [Fact]
        public void Should_Set_Working_Directory()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture();

            // When
            var result = fixture.Run();

            // Then
            result.Process.WorkingDirectory.FullPath.Should().Be("/Working");
        }

        [Fact]
        public void Should_Throw_If_Process_Was_Not_Started()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture();
            fixture.GivenProcessCannotStart();

            // When
            Action result = () => fixture.Run();

            // Then
            result.Should().Throw<CakeException>().WithMessage("StrongNameSigner: Process was not started.");
        }

        [Fact]
        public void Should_Throw_If_Process_Has_A_Non_Zero_Exit_Code()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture();
            fixture.GivenProcessExitsWithCode(1);

            // When
            Action result = () => fixture.Run();

            // Then
            result.Should().Throw<CakeException>().WithMessage("StrongNameSigner: Process returned an error (exit code 1).");
        }

        [Fact]
        public void Should_Set_AssemblyFile()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture { Settings = { AssemblyFile = "./test.dll" }};

            // When
            var result = fixture.Run();

            // Then
            result.Args.Should().Be(@"-a ""/Working/test.dll""");
        }

        [Fact]
        public void Should_Set_KeyFile()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture { Settings = { KeyFile = "./test.snk" }};

            // When
            var result = fixture.Run();

            // Then
            result.Args.Should().Be(@"-k ""/Working/test.snk""");
        }

        [Fact]
        public void Should_Set_Password()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture { Settings = { Password = "bob" }};

            // When
            var result = fixture.Run();

            // Then
            result.Args.Should().Be(@"-p ""bob""");
        }

                [Fact]
        public void Should_Set_InputDirectory()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture { Settings = { InputDirectory = "input" }};

            // When
            var result = fixture.Run();

            // Then
            result.Args.Should().Be(@"-in ""input""");
        }

        [Fact]
        public void Should_Set_OutputDirectory()
        {
            // Given
            var fixture = new StrongNameSignerRunnerFixture { Settings = { OutputDirectory = "./output" }};

            // When
            var result = fixture.Run();

            // Then
            result.Args.Should().Be(@"-out ""/Working/output""");
        }
    }
}
