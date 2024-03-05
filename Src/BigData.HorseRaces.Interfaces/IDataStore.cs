namespace BigData.HorseRaces.Interfaces;

public interface IDataStore
{
    //Returns Id of stored data
    public Task<string> StoreAsync(object data);
}
