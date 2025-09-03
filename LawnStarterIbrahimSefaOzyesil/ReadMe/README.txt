# Getting Started with RunMe.csx

This folder contains **RunMe.csx**, a C# script that makes it easy to get the LawnStarter Test Framework running. 
Instead of typing multiple commands, you can run this script to handle setup and execution.

---

## Requirements
- .NET 8 SDK installed  
  Check with:
  ```bash
  dotnet --version
  ```
  (The version should start with `8.`)

- dotnet-script (one-time install)  
  This is required to run `.csx` C# scripts:
  ```bash
  dotnet tool install -g dotnet-script
  dotnet script --version
  ```

Optional: Visual Studio 2022 if you prefer running tests through the IDE.

---

## Configure the framework
Before running tests, edit `appsettings.json` in the solution root and set values for your environment:

```json
{
  "AppSettings": {
    "BaseUrl": "https://YOUR-TEST-ENV-URL IN this case I have used URL in hometask assignment.", 
    "Browser": "Chrome",
    "DefaultTimeoutSeconds": 30
  }
}
```

- `BaseUrl`: the site you want to test  
- `Browser`: choose `Chrome`, `Edge`, or `Firefox`  
- `DefaultTimeoutSeconds`: how long to wait for elements/pages  

---

## Run all tests with one command
From the solution root (where the `.sln` file is located), run:

```bash
dotnet script readme/RunMe.csx
```

The script will:
1. Check your .NET version  
2. Restore NuGet packages  
3. Build the solution  
4. Run all tests  

---

## Run with code coverage
If you also want to generate a coverage report, run:

```bash
dotnet script readme/RunMe.csx -- --with-coverage
```

The report will be saved under:
```
TestResults/**/coverage.cobertura.xml
```

---

## Results
- Console output shows a pass/fail summary  
- Visual Studio Test Explorer shows detailed results  
- Screenshots on failure:  
  ```
  bin/<Debug|Release>/net8.0/Screenshots
  ```
- Coverage reports: `TestResults/**/coverage.cobertura.xml` if coverage is enabled  

---

## Tips
- Run a single test with a filter:  
  ```bash
  dotnet test --filter "FullyQualifiedName~LawnStarterIbrahimSefaOzyesil.Tests.Registration.SignUp"
  ```
- Selenium Manager automatically downloads drivers, no manual setup required.  
- If you are behind a proxy, configure `HTTP_PROXY` and `HTTPS_PROXY`.  

---

This script helps newcomers quickly restore dependencies, build the solution, and run tests without additional setup.
