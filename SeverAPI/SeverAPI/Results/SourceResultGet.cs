using SeverAPI.Database.Models;

namespace SeverAPI.Results
{
    public class SourceResultGet
    {
        public string Path { get; set; }

        public SourceResultGet(Source source)
        {
            this.Path = source.Path;
        }


    }
}
