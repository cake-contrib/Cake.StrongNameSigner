using Cake.Core;
using Cake.Core.Annotations;

namespace Cake.StrongNameSigner
{
    /// <summary>
    /// <para>
    /// Automatic strong-name signing of referenced assemblies. Aliases to strong-name sign .NET assemblies, including assemblies you do not have the source code for.
    /// <see href="https://brutaldev.com/post/net-assembly-strong-name-signer">More information</see>.
    /// </para>
    /// <para>
    /// In order to use the commands for this addin, you will need to have StrongNameSigner installed on the machine it is
    /// running on:
    /// <code>
    /// #tool nuget:?package=Brutal.Dev.StrongNameSigner
    /// </code>
    /// </para>
    /// <para>
    /// also you will need the following in your cake file:
    /// <code>
    /// #addin nuget:?package=Cake.StrongNameSigner
    /// </code>
    /// </para>
    /// </summary>
    [CakeAliasCategory("StrongNameSigner")]
    public static class StrongNameSignerAliases
    {
        /// <summary>
        /// Executes <see href="https://brutaldev.com/post/net-assembly-strong-name-signer">StrongNameSigner.Console.exe</see> on a collection of assemblies using the specified settings..
        /// </summary>
        /// <param name="context">The Cake context.</param>
        /// <param name="settings">The settings to pass to the tool as arguments.</param>
        [CakeMethodAlias]
        public static void StrongNameSigner(this ICakeContext context, StrongNameSignerSettings settings)
        {
            var runner = new StrongNameSignerRunner(
                context.FileSystem,
                context.Environment,
                context.ProcessRunner,
                context.Tools,
                context.Log);

            runner.Run(settings);
        }
    }
}
