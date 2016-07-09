using System;
using System.IO;

namespace BlogCore
{
    public interface INewPostGenerator
    {
        void NewPost(string title);
    }

    public class NewPostGenerator : INewPostGenerator
    {
        public void NewPost(string title)
        {
            var ph = new PostHeader(Config.Author, DateTime.Now, title);

            File.WriteAllText(GetCleanFileName(title), ph.Serialize());
        }

        public string GetCleanFileName(string title)
        {
            title = title
                .Replace(' ', '_')
                .Replace(',', '_')
                // ...
                ;
            return $"{title}.md";
        }
    }
}