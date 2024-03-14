namespace BigData.HorseRaces.Interfaces
{
    public interface IFileParser
    {
        //List of file extensions the parser can parse
        public string ICanParseExtension();

        //Each line read as generic object
        public Task<IEnumerable<object>> ParseAsync(Stream stream);
    }
}
