namespace BlogCore
{
    public interface IMarkdownConverter
    {
        string Convert(string markdownString);
    }

    public class MarkdownConverter : IMarkdownConverter
    {
        public string Convert(string markdownString)
        {
            return markdownString;
        }
    }
}