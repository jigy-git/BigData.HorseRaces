
using BigData.HorseRaces.Application;
using BigData.HorseRaces.Domain;
using BigData.HorseRaces.Infrastructure;
using BigData.HorseRaces.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var host = new HostBuilder()
    .ConfigureFunctionsWebApplication()
    .ConfigureServices(services =>
    {
        services.AddApplicationInsightsTelemetryWorkerService();
        services.ConfigureFunctionsApplicationInsights();

        services.AddSingleton<IFileProcessingService, FileProcessingService>();

        //Register Domain Services
        services.AddSingleton<IFileParserRegistry, FileParserRegistry>();

        //Register Infrastructure Services
        services.AddSingleton<IFileParser, XmlParser>();
        services.AddSingleton<IFileParser, JsonParser>();

    })
.Build();



host.Run();
