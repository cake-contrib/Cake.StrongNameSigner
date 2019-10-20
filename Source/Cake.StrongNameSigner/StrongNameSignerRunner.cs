using System;
using System.Collections.Generic;
using Cake.Core;
using Cake.Core.Diagnostics;
using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.StrongNameSigner
{
    internal sealed class StrongNameSignerRunner : Tool<StrongNameSignerSettings>
    {
        private readonly ICakeEnvironment _environment;
        private readonly ICakeLog _log;

        internal StrongNameSignerRunner(
            IFileSystem fileSystem,
            ICakeEnvironment environment,
            IProcessRunner processRunner,
            IToolLocator tools,
            ICakeLog log)
            : base(fileSystem, environment, processRunner, tools)
        {
            _environment = environment;
            _log = log;
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

            builder.Append("-l");

            if (settings.LogLevel.HasValue)
            {
                switch (settings.LogLevel.Value)
                {
                    case StrongNameSignerVerbosity.Default:
                        builder.Append(nameof(StrongNameSignerVerbosity.Default));
                        break;
                    case StrongNameSignerVerbosity.Verbose:
                        builder.Append(nameof(StrongNameSignerVerbosity.Verbose));
                        break;
                    case StrongNameSignerVerbosity.Changes:
                        builder.Append(nameof(StrongNameSignerVerbosity.Changes));
                        break;
                    case StrongNameSignerVerbosity.Summary:
                        builder.Append(nameof(StrongNameSignerVerbosity.Summary));
                        break;
                    case StrongNameSignerVerbosity.Silent:
                        builder.Append(nameof(StrongNameSignerVerbosity.Silent));
                        break;
                }
            }
            else
            {
                switch (_log.Verbosity)
                {
                    case Verbosity.Quiet:
                        builder.Append(nameof(StrongNameSignerVerbosity.Silent));
                        break;
                    case Verbosity.Normal:
                        builder.Append(nameof(StrongNameSignerVerbosity.Default));
                        break;
                    case Verbosity.Diagnostic:
                    case Verbosity.Verbose:
                        builder.Append(nameof(StrongNameSignerVerbosity.Verbose));
                        break;
                    case Verbosity.Minimal:
                        builder.Append(nameof(StrongNameSignerVerbosity.Summary));
                        break;
                }
            }

            return builder;
        }
    }
}
