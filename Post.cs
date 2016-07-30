namespace BlogCore
{
    public class Post
    {
        public PostHeader Header {get;}
        public string HtmlString {get;}
        public string Description {get;}

        public Post(PostHeader postHeader, string htmlString, string description)
        {
            this.Header = postHeader;
            this.HtmlString = htmlString;
            this.Description = description;
        }

        public string FriendlyDate
        {
            get
            {
                return Header.PubDate.ToString("yyyy-MM-dd");
            }
        }

        public string Url
        {
            get
            {
                return $"{Config.UrlPrefix}/{Header.CleanTitle}.html";
            }
        }
    }
}