using Cake.Core.Diagnostics;
using Cake.Testing.Fixtures;
using Moq;

namespace Cake.StrongNameSigner.Tests
{
    internal class StrongNameSignerRunnerFixture : ToolFixture<StrongNameSignerSettings>
    {
        public ICakeLog Log { get; set; }

        public StrongNameSignerRunnerFixture()
            : base("StrongNameSigner.Console.exe")
        {
            Log = new Mock<ICakeLog>().Object;
            Log.Verbosity = Verbosity.Normal;
        }

        protected override void RunTool()
        {
            var tool = new StrongNameSignerRunner(FileSystem, Environment, ProcessRunner, Tools, Log);
            tool.Run(Settings);
        }
    }
}
