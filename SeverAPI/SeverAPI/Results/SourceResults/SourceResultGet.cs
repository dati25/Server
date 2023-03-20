using SeverAPI.Database.Models;

namespace SeverAPI.Results.SourceResults
{
    public class SourceResultGet
    {
        public int id { get; set; }
        public string Path { get; set; }

        public SourceResultGet(Source source)
        {
            this.id = source.id;
            Path = source.Path;
        }
    }
}
