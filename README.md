# Cake.StrongNameSigner

[![standard-readme compliant][]][standard-readme]
[![Appveyor build][appveyorimage]][appveyor]
[![Codecov Report][codecovimage]][codecov]
[![NuGet package][nugetimage]][nuget]

> Cake.StrongNameSigner is an Addin for Cake which allows the execution of the StrongNameSigner.Console.exe.

## Table of Contents

- [Install](#install)
- [Usage](#usage)
- [Maintainer](#maintainer)
- [Contributing](#contributing)
- [License](#license)

## Install

```cs
#addin nuget:?package=Cake.StrongNameSigner
```

## Usage

```cs
#addin nuget:?package=Cake.StrongNameSigner

Task("MyTask").Does(() => {
  StrongNameSigner();
});
```

## Maintainer

[Gary Ewan Park @gep13][maintainer]

## Contributing

Cake.StrongNameSigner follows the [Contributor Covenant][contrib-covenant] Code of Conduct.

We accept Pull Requests.
Please see [the contributing file][contributing] for how to contribute to Cake.StrongNameSigner.

Small note: If editing the Readme, please conform to the [standard-readme][] specification.

## License

[MIT License © Cake Contributions][license]

[appveyor]: https://ci.appveyor.com/project/cakecontrib/cake-strongnamesigner
[appveyorimage]: https://img.shields.io/appveyor/ci/cakecontrib/cake-strongnamesigner.svg?logo=appveyor&style=flat-square
[codecov]: https://codecov.io/gh/cake-contrib/Cake.StrongNameSigner
[codecovimage]: https://img.shields.io/codecov/c/github/cake-contrib/Cake.StrongNameSigner.svg?logo=codecov&style=flat-square
[contrib-covenant]: https://www.contributor-covenant.org/version/1/4/code-of-conduct
[contributing]: CONTRIBUTING.md
[maintainer]: https://github.com/gep13
[nuget]: https://nuget.org/packages/Cake.StrongNameSigner
[nugetimage]: https://img.shields.io/nuget/v/Cake.StrongNameSigner.svg?logo=nuget&style=flat-square
[license]: LICENSE.txt
[standard-readme]: https://github.com/RichardLitt/standard-readme
[standard-readme compliant]: https://img.shields.io/badge/readme%20style-standard-brightgreen.svg?style=flat-square
