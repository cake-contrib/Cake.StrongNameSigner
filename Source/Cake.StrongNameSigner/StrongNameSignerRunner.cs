using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.StrongNameSigner
{
    internal sealed class StrongNameSignerRunner : Tool<StrongNameSignerSettings>
    {
        private readonly ICakeEnvironment _environment;

        internal StrongNameSignerRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
        }

        internal void Run(StrongNameSignerSettings settings)
        {
            if (settings == null)
            {
                throw new ArgumentNullException(nameof(settings));
            }

            this.Run(settings, GetArguments(settings));
        }

        protected override IEnumerable<string> GetToolExecutableNames()
        {
            yield return "StrongNameSigner.Console.exe";
        }

        protected override string GetToolName()
        {
            return "StrongNameSigner";
        }

        private ProcessArgumentBuilder GetArguments(StrongNameSignerSettings settings)
        {
            var builder = new ProcessArgumentBuilder();

            if (settings.AssemblyFile != null)
            {
                builder.Append("-a");
                builder.AppendQuoted(settings.AssemblyFile.MakeAbsolute(_environment).FullPath);
            }

            if (settings.KeyFile != null)
            {
                builder.Append("-k");
                builder.AppendQuoted(settings.KeyFile.MakeAbsolute(_environment).FullPath);
            }

            if (!string.IsNullOrWhiteSpace(settings.Password))
            {
                builder.Append("-p");
                builder.AppendQuotedSecret(settings.Password);
            }

            if (!string.IsNullOrWhiteSpace(settings.InputDirectory))
            {
                builder.Append("-in");
                builder.AppendQuoted(settings.InputDirectory);
            }

            if (settings.OutputDirectory != null)
            {
                builder.Append("-out");
                builder.AppendQuoted(settings.OutputDirectory.MakeAbsolute(_environment).FullPath);
            }

            return builder;
        }
    }
}
