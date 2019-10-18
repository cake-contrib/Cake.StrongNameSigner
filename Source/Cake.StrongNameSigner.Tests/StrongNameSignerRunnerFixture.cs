using Cake.Testing.Fixtures;

namespace Cake.StrongNameSigner.Tests
{
    internal class StrongNameSignerRunnerFixture : ToolFixture<StrongNameSignerSettings>
    {
        public StrongNameSignerRunnerFixture()
            : base("StrongNameSigner.Console.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new StrongNameSignerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
