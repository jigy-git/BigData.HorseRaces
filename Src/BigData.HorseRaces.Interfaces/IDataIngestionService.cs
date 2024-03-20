namespace BigData.HorseRaces.Interfaces
{
    public interface IDataIngestionService
    {
        public Task IngestAsync(string filename, Stream file);
    }
}
