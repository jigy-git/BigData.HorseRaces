using BigData.HorseRaces.Infrastructure;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace BigData.HorseRaces.DataProcessor
{
    public class FuncProcessData(ILogger<FuncProcessData> logger, IFileProcessingService fileProcessingService)
    {
        private readonly ILogger<FuncProcessData> _logger = logger;
        private readonly IFileProcessingService _fileProcessingService = fileProcessingService;

        [Function(nameof(FuncProcessData))]
        public async Task Run([BlobTrigger("datasources/{name}", Connection = "AzureStorageConnectionString")] Stream stream, string name)
        {
            try
            {
                await _fileProcessingService.ProcessAsync(name, stream);               
            }
            catch(Exception ex)
            {
                //Put into another bucket? 
                //Create error message?
                _logger.LogError("Unhandled exception for file {file}: {ex}", name, ex);
            }
        }
    }
}
