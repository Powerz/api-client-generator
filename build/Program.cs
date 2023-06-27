using static Bullseye.Targets;
using static SimpleExec.Command;

Target("clean up", () => RunAsync("rm", "-rf WeatherApiClient", "src"));

Target("build", DependsOn("clean up"), () => RunAsync("dotnet", "build WeatherApi --configuration Debug --nologo --verbosity quiet", "src"));

//? Create Api client project

Target("create api client project",
    DependsOn("build"),
    () => RunAsync("dotnet", "new classlib -n WeatherApiClient", "src"));

Target("clean up stuff",
    DependsOn("create api client project"),
    () => RunAsync("rm", "Class1.cs", "src/WeatherApiClient"));

Target("add Newtonsoft.Json",
    DependsOn("clean up stuff"),
    () => RunAsync("dotnet", "add package Newtonsoft.Json", "src/WeatherApiClient"));


//? Generate Api client

Target("generate api client",
    DependsOn("Add Newtonsoft.Json"),
    () => RunAsync("nswag", "run nswag.json"));

Target("build api client",
    DependsOn("generate api client"),
    () => RunAsync("dotnet", "build WeatherApiClient --configuration Debug --nologo --verbosity quiet", "src"));


//? nuget pack, push

Target("default", DependsOn("build api client"));

await RunTargetsAndExitAsync(args, ex => ex is SimpleExec.ExitCodeException);