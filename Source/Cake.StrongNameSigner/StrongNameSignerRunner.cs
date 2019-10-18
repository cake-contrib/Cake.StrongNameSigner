namespace Cake.StrongNameSigner
{
    using System;
    using System.Collections.Generic;
    using Cake.Core;
    using Cake.Core.IO;
    using Cake.Core.Tooling;

    public sealed class StrongNameSignerRunner : Tool<StrongNameSignerSettings>
    {
        public StrongNameSignerRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
        }

        public void Run(StrongNameSignerSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.Run(settings, GetArguments(settings));
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "StrongNameSigner.exe";
            yield return "StrongNameSigner";
        }

        protected override string GetToolName()
        {
            return "StrongNameSigner";
        }

        private static ProcessArgumentBuilder GetArguments(StrongNameSignerSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            // TODO: Add the necessary arguments based on the settings class

            return builder;
        }
    }
}
