using BigData.HorseRaces.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using BigData.HorseRaces.Domain.Extensions;

namespace BigData.HorseRaces.Domain
{
    public class FileParserRegistry : IFileParserRegistry
    {
        private readonly IDictionary<string, IFileParser> _fileParsers = new Dictionary<string, IFileParser>();

        public FileParserRegistry(IServiceProvider serviceProvider) {

            var fileParsers = serviceProvider.GetServices(typeof(IFileParser))?.Where(f => f as IFileParser != null).Select(f => f as IFileParser) ?? [];

            foreach (var fileParser in fileParsers)
            {
                _fileParsers.Add(fileParser!.ICanParseExtension().ToLower(), fileParser);
            }
        }

        public IFileParser? GetParser(string fileName)
        {
            var fileExten = fileName.GetFileExtension();
            
            var hasRegisteredParser = _fileParsers.TryGetValue(fileExten.ToLower(), out var fileParser);

            return hasRegisteredParser ? fileParser : null;
        }
    }
}
