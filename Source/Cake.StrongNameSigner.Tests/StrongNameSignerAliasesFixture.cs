using Cake.Core;
using Cake.Core.IO;
using Cake.Testing;
using Moq;

namespace Cake.StrongNameSigner.Tests
{
    internal class StrongNameSignerAliasesFixture : StrongNameSignerRunnerFixture
    {
        internal ICakeContext _context;

        public StrongNameSignerAliasesFixture()
        {
            var argumentsMoq = new Mock<ICakeArguments>();
            var registryMoq = new Mock<IRegistry>();
            var dataService = new Mock<ICakeDataService>();
            _context = new CakeContext(
                FileSystem,
                Environment,
                Globber,
                new FakeLog(),
                argumentsMoq.Object,
                ProcessRunner,
                registryMoq.Object,
                Tools,dataService.Object,
                Configuration);
        }

        protected override void RunTool()
        {
            StrongNameSignerAliases.StrongNameSigner(_context, Settings);
        }
    }
}
