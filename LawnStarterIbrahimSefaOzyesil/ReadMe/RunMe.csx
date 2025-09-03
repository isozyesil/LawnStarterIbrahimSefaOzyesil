#r "nuget: CliWrap, 3.6.6"

using System;
using System.Threading.Tasks;
using CliWrap;
using CliWrap.Buffered;

var withCoverage = args.Length > 0 && args[0].Equals("--with-coverage", StringComparison.OrdinalIgnoreCase);

async Task Exec(string cmd, string arguments)
{
    Console.WriteLine($">>> {cmd} {arguments}");
    var result = await Cli.Wrap(cmd).WithArguments(arguments).ExecuteBufferedAsync();
    if (result.ExitCode != 0)
        throw new Exception($"Command failed: {cmd} {arguments}\n{result.StandardError}");
    Console.WriteLine(result.StandardOutput);
}

Console.WriteLine("== LawnStarter Test Framework bootstrap (C# script) ==");
await Exec("dotnet", "--version");
await Exec("dotnet", "restore");
await Exec("dotnet", "build --configuration Release");
if (withCoverage)
{
    await Exec("dotnet", "test --configuration Release --collect:\"XPlat Code Coverage\"");
    Console.WriteLine("Coverage report(s) generated under TestResults/**/coverage.cobertura.xml");
}
else
{
    await Exec("dotnet", "test --configuration Release");
}
Console.WriteLine("== Done. Tests executed successfully. ==");
