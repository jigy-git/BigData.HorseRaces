namespace BigData.HorseRaces.Interfaces
{
    public interface IFileParserRegistry
    {
        public IFileParser? GetParser(string fileName);
    }
}
