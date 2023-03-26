namespace SeverAPI.Commands.TestingCommands
{
    public class TestingString
    {
        public string ParamName { get; set; }
        public string Value { get; set; }
        
        public TestingString(string paramName, string value)
        {
            this.ParamName = paramName;
            this.Value = value;
        }

    }
}
