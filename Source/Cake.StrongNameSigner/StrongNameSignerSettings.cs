using Cake.Core.IO;
using Cake.Core.Tooling;

namespace Cake.StrongNameSigner
{
    /// <summary>
    /// Contains settings used by <see cref="StrongNameSignerRunner"/>. See <see
    /// href="https://github.com/brutaldev/StrongNameSigner#screenshots">screenshots</see> or run following command for more information.
    /// <code>
    /// .\StrongNameSigner.Console.exe -h
    /// </code>
    /// </summary>
    public sealed class StrongNameSignerSettings : ToolSettings
    {
        /// <summary>
        /// Gets or sets the assembly file to strong-name sign.
        /// </summary>
        /// <value>The assemble to be strong-name signed.</value>
        public FilePath AssemblyFile { get; set; }

        /// <summary>
        /// Gets or sets a strong-name key file to use.  If not specified, one will be generated.
        /// </summary>
        /// <value>The strong-name key file to use.</value>
        public FilePath KeyFile { get; set; }

        /// <summary>
        /// Gets or sets the password (if any) for teh provided strong-name key file.
        /// </summary>
        /// <value>The password for the strong-name key file.</value>
        public string Password { get; set; }

        /// <summary>
        /// Gets or sets a directory for assemblies to strong-name sign.
        /// </summary>
        /// <value>The input directory.</value>
        public string InputDirectory { get; set; }

        /// <summary>
        /// Gets or sets the output directory for strong-name signed assemblies.  Default to current directory.
        /// </summary>
        /// <value>The output directory.</value>
        public DirectoryPath OutputDirectory { get; set; }
    }
}
