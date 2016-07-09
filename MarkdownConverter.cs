using MarkdownSharp;

namespace BlogCore
{
    public interface IMarkdownConverter
    {
        string Convert(string markdownString);
    }

    public class MarkdownConverter : IMarkdownConverter
    {
        public MarkdownConverter()
        {
            markdown = new Markdown();
        }

        public string Convert(string markdownString)
        {
            return markdown.Transform(markdownString);
        }

        private Markdown markdown;
    }
}