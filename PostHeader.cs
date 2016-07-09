using System;
using Newtonsoft.Json;

namespace BlogCore
{
    public class PostHeader
    {
        public string Author {get;}
        public DateTime PubDate {get;}
        public string Title {get;}

        public PostHeader(string author, DateTime pubDate, string title)
        {
            this.Author = author;
            this.PubDate = pubDate;
            this.Title = title;
        }

        public static PostHeader Deserialize(string line)
        {
            return JsonConvert.DeserializeObject<PostHeader>(line);
        }

        public string Serialize()
        {
            return JsonConvert.SerializeObject(this, Formatting.None);
        }
    }
}