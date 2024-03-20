using BigData.HorseRaces.Interfaces;
using BigData.HorseRaces.ViewModels;
using Microsoft.Extensions.Logging;

namespace BigData.HorseRaces.Application;

public class DataIngestionService(ILogger<DataIngestionService> logger, IFileParserRegistry fileParserRegistry, IDataProcessor dataProcessor, IDataStore dataStore, IEventPublisher eventPublisher) : IDataIngestionService
{
    private readonly ILogger<DataIngestionService> _logger = logger;
    private readonly IFileParserRegistry _fileParserRegistry = fileParserRegistry;
    private readonly IDataProcessor _dataProcessor = dataProcessor;
    private readonly IDataStore _dataStore = dataStore;
    private readonly IEventPublisher _eventPublisher = eventPublisher;

    public async Task IngestAsync(string filename, Stream stream)
    {
        var parser = _fileParserRegistry.GetParser(filename);

        if(parser == null)
        {
            //DO something - add 
            //Log ??
            return;
        }

        var data = await parser.ParseAsync(stream);

        var dataForIngestation = await _dataProcessor.PrepareDataForIngestationAsync(data);

        await _dataStore.StoreAsync(dataForIngestation);

        await _eventPublisher.PublishAsync(new DataRecievedEvent(filename, dataForIngestation.Id));

        _logger.LogInformation("Data from Name: {filename} ongested", filename);
    }
}
