namespace Cake.StrongNameSigner.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Testing;
    using Cake.Testing.Fixtures;
    using Moq;

    public class StrongNameSignerAliasesFixture : StrongNameSignerRunnerFixture
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
            if (Settings == null)
            {
                StrongNameSignerAliases.StrongNameSigner(_context);
            }
            else
            {
                StrongNameSignerAliases.StrongNameSigner(_context, Settings);
            }
        }
    }
}
