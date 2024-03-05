namespace BigData.HorseRaces.Interfaces
{
    public interface IFileParser
    {
        //List of file extensions the parser can parse
        public List<string> ICanParse();

        //Each line read as generic object
        public Task<IEnumerable<object>> ParseAsync(Stream stream);
    }
}
