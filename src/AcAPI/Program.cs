using AcAPI;
using Microsoft.AspNetCore;

public class Program
{
    public static void Main(string[] args)
    {
        BuildWebHost(args).Run();
    }

    public static IWebHost BuildWebHost(string[] args)
    {
        var config = new ConfigurationBuilder()
                         .AddCommandLine(args)
                         .AddEnvironmentVariables(prefix: "ASPNETCORE_")
                         .Build();

        var host = WebHost.CreateDefaultBuilder(args)
                          .UseConfiguration(config)
                          .UseContentRoot(Directory.GetCurrentDirectory())
                          .UseIISIntegration()
                          .UseStartup<Startup>()
                          .Build();

        return host;
    }
}
