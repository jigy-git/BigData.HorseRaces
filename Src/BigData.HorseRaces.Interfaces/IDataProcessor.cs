namespace BigData.HorseRaces.Interfaces;

public interface IDataProcessor
{
    public Task<object> ProcessAsync(IEnumerable<object> data);
}
