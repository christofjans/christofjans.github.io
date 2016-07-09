using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace BlogCore
{
    public class PostHeader
    {
        public string Author {get;}
        public DateTime PubDate {get;}
        public string Title {get;}

        public string CleanTitle
        {
            get
            {
                string cleanTitle = Title;

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
                    cleanTitle = cleanTitle.Replace(kvp.Key, kvp.Value);
                }

                return cleanTitle;
            }
        }

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