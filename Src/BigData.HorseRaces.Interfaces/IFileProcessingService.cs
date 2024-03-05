namespace BigData.HorseRaces.Infrastructure
{
    public interface IFileProcessingService
    {
        public Task ProcessAsync(string filename, Stream file);
    }
}
