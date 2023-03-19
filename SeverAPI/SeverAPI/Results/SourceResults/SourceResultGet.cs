using SeverAPI.Database.Models;

namespace SeverAPI.Results.SourceResults
{
    public class SourceResultGet
    {
        public string Path { get; set; }

        public SourceResultGet(Source source)
        {
            Path = source.Path;
        }


    }
}
