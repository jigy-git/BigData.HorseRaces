namespace BigData.HorseRaces.Interfaces;

public interface IIngestedData
{
    public Guid Id { get; set; }
    public IEnumerable<object> data { get; set; }
}

public interface IDataProcessor
{
    public Task<IIngestedData> PrepareDataForIngestationAsync(IEnumerable<object> data);
}
