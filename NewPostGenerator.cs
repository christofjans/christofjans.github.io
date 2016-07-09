using System;
using System.IO;
using static System.Console;

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
            var postHeader = new PostHeader(Config.Author, DateTime.UtcNow, title);
            string fileName = GetCleanFileName(postHeader);
            File.WriteAllText(fileName, postHeader.Serialize());
            WriteLine($"code ./{fileName}");
        }

        public string GetCleanFileName(PostHeader postHeader)
        {
            return $"{Config.PostSubDir}/{postHeader.CleanTitle}.md";
        }
    }
}