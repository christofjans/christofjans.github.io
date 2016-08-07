using Microsoft.AspNetCore.Html;

namespace BlogCore
{
    public class Post
    {
        public PostHeader Header {get;}
        public string HtmlString {get;}
        public string DescriptionHtmlString {get;}

        public Post(PostHeader postHeader, string htmlString, string descriptionHtmlString)
        {
            this.Header = postHeader;
            this.HtmlString = htmlString;
            this.DescriptionHtmlString = descriptionHtmlString;
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

        public HtmlString Raw(string s)
        {
            return new HtmlString(s);
        }
    }
}