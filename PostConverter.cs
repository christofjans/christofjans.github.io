using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace BlogCore
{
    public interface IPostConverter
    {
        void ConvertAllPosts();
    }

    public class PostConverter : IPostConverter
    {
        public PostConverter(IMarkdownConverter markdownConverter, ITemplateEngine templateEngine)
        {
            this.markdownConverter = markdownConverter;
            this.templateEngine = templateEngine;
        }

        public void ConvertAllPosts()
        {
            var allPosts = new List<Post>();

            // Convert the blog posts.
            string postTemplate = File.ReadAllText(Config.PostTemplate);
            var merge = templateEngine.CreateMerger(postTemplate);
            foreach (string postFile in Directory.EnumerateFiles(Config.PostSubDir, "*.md"))
            {
                var post = ConvertPost(merge, postFile);
                var fileName = $"{Config.PostSubDir}/{Path.GetFileNameWithoutExtension(postFile)}.html";
                File.WriteAllText(fileName, post.HtmlString);

                allPosts.Add(post);
            }

            // Generate index.html
            /*string indexTemplate = File.ReadAllText(Config.IndexTemplate);
            merge = templateEngine.CreateMerger(indexTemplate);
            File.WriteAllText("index.html", merge(allPosts));*/
        }

        private Post ConvertPost(Func<object, string> merge, string postFile)
        {
            var lines = File.ReadAllLines(postFile);

            // Retrieve the post header from the first line of the post and the markdown from the rest.
            var postHeader = PostHeader.Deserialize(lines[0]);
            string markdownString = string.Join("\r\n", lines.Skip(1));

            // Convert markdown to html.
            string htmlString = markdownConverter.Convert(markdownString);

            // Merge html with the template.
            var post = new Post(postHeader, htmlString); // temporary post object whose html still needs to be merged with the template
            htmlString = merge(post);

            // Return the final post.
            return new Post(postHeader, htmlString);
        }

        private IMarkdownConverter markdownConverter;
        private ITemplateEngine templateEngine;
    }
}