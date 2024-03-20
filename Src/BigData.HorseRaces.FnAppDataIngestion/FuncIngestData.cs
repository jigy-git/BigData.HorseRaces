using BigData.HorseRaces.Interfaces;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BigData.HorseRaces.FnAppDataIngestion;

public class FuncIngestData(ILogger<FuncIngestData> logger, IDataIngestionService dataIngestionService)
{
    private readonly ILogger<FuncIngestData> _logger = logger;
    private readonly IDataIngestionService _dataIngestionService = dataIngestionService;

    [Function(nameof(FuncIngestData))]
    public async Task Run([BlobTrigger("datasources/{name}", Connection = "AzureStorageConnectionString")] Stream stream, string name)
    {
        try
        {
            await _dataIngestionService.IngestAsync(name, stream);
        }
        catch (Exception ex)
        {
            //Put into another bucket? 
            //Create error message?
            _logger.LogError("Unhandled exception for file {file}: {ex}", name, ex);
        }
    }
}
