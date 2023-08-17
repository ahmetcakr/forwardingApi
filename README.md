
[![](https://img.shields.io/badge/.NET%20Core-512BD4?style=for-the-badge&logo=dotnet&logoColor=white)](https://learn.microsoft.com/tr-tr/dotnet/welcome)

## ⚙️ Getting Started

To get a local copy up and running follow these simple steps.

### Prerequisites

- .NET 7

### Installation

1. Clone the repo
   ```sh
   git clone --recurse-submodules https://github.com/kodlamaio-projects/nArchitecture.git
   ```
2. Configure `appsettings.json` in WebAPI.
3. Run `Update-Database` command with Package Manager Console in WebAPI to create tables in sql server.

- Run the following command to update submodules
  ```sh
   git submodule update --remote
   ```

## 🚀 Usage

1. Run example WebAPI project `dotnet run --project src\rentACar\WebAPI`

### Analysis

1. If not, Install dotnet tool `dotnet tool restore`.
2. Run anaylsis command `dotnet roslynator analyze`

### Format

1. If not, Install dotnet tool `dotnet tool restore`.
2. Run format command `dotnet csharpier .`
   
## 🤝 Contributing

Contributions are what make the open source community such an amazing place to be learn, inspire, and create. Any contributions you make are **greatly appreciated**.

1. Fork the project and clone your local machine
2. Create your Feature Branch (`git checkout -b <Feature>/<AmazingFeature>'`)
3. Develop
4. Commit your Changes (`git add . && git commit -m '<SemanticCommitType>(<Scope>): <AmazingFeature>'`)
   💡 Check [Semantic Commit Messages](./docs/Semantic%20Commit%20Messages.md)
5. Push to the Branch (`git push origin <Feature>/<AmazingFeature>`)
6. Open a Pull Request

Contributing on Core Packages With This Repo:

1. Fork the project
2. Locate to `src/corePackages` path (`cd .\src\corePackages\`)
3. Add your forked nArchitecture.Core repository remote address (`git remote add <YourUserName> https://github.com/<YourUserName>/nArchitecture.Core.git`)
4. Create your Feature Branch (`git checkout -b <Feature>/<AmazingFeature>'`)
5. Develop
6. Commit your changes (`git add . && git commit -m '<SemanticCommitType>(<Scope>): <AmazingFeature>'`)
   💡 Check [Semantic Commit Messages](./docs/Semantic%20Commit%20Messages.md)
7. Push to the branch (`git push <YourUserName> --set-upstream HEAD:refs/heads/<Feature>/<AmazingFeature>`)
8. Open a Pull Request

If your pull request is accepted and merged:

9. Locate to `src/corePackages` path (`cd .\src\corePackages\`)
10. Switch to main branch `git checkout main`
11. Locate root path `/` path (`cd ..\..\`)
12. Pull repo and submodule `git submodule update --remote`
13. Commit your changes (`git add . && git commit -m 'build(corePackages): update submodule'`)
14. Push to the Branch (`git push origin <Feature>/<AmazingFeature>`)
15. Open a Pull Request

## ⚖️ License

Distributed under the MIT License. See `LICENSE` for more information.
