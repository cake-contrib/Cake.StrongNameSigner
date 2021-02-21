#load nuget:?package=Cake.Recipe&version=2.2.0

Environment.SetVariableNames();

BuildParameters.SetParameters(
    context: Context,
    buildSystem: BuildSystem,
    sourceDirectoryPath: "./Source",
    title: "Cake.StrongNameSigner",
    repositoryOwner: "cake-contrib",
    repositoryName: "Cake.StrongNameSigner",
    appVeyorAccountName: "cakecontrib",
    shouldRunDotNetCorePack: true,
    preferredBuildProviderType: BuildProviderType.GitHubActions);

BuildParameters.PrintParameters(Context);

ToolSettings.SetToolSettings(context: Context);

Build.RunDotNetCore();
