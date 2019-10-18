namespace Cake.StrongNameSigner.Tests
{
    using Cake.Testing.Fixtures;

    public class StrongNameSignerRunnerFixture : ToolFixture<StrongNameSignerSettings>
    {
        public StrongNameSignerRunnerFixture()
            : base("StrongNameSigner.exe")
        {
        }

        protected override void RunTool()
        {
            var tool = new StrongNameSignerRunner(FileSystem, Environment, ProcessRunner, Tools);
            tool.Run(Settings);
        }
    }
}
