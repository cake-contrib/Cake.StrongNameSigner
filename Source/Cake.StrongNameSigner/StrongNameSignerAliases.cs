namespace Cake.StrongNameSigner
{
    using Cake.Core;
    using Cake.Core.Annotations;
    using Cake.Core.IO;

    [CakeAliasCategory("StrongNameSigner")]
    public static class StrongNameSignerAliases
    {
        [CakeMethodAlias]
        public static void StrongNameSigner(this ICakeContext context)
        {
            StrongNameSigner(context, new StrongNameSignerSettings());
        }

        [CakeMethodAlias]
        public static void StrongNameSigner(this ICakeContext context, StrongNameSignerSettings settings)
        {
            var runner = new StrongNameSignerRunner(
                context.FileSystem,
                context.Environment,
                context.ProcessRunner,
                context.Tools);
            runner.Run(settings);
        }
    }
}
