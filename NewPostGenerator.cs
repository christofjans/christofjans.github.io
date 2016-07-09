using System;
using System.IO;
using System.Collections.Generic;
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
            var ph = new PostHeader(Config.Author, DateTime.UtcNow, title);
            string fileName = GetCleanFileName(title);
            File.WriteAllText(fileName, ph.Serialize());
            WriteLine($"code ./{fileName}");
        }

        public string GetCleanFileName(string title)
        {
            var replacements = new Dictionary<string, string>()
            {
                [" "] = "_",
                ["'"] = "",
                ["."] = "",
                [","] = "",
                ["?"] = "",
                ["!"] = "",
            };

            foreach (var kvp in replacements)
            {
                title = title.Replace(kvp.Key, kvp.Value);
            }

            return $"{Config.PostSubDir}/{title}.md";
        }
    }
}