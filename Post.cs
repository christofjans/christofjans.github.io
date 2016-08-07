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

        public string RssDate
        {
            get
            {
                string rssDate = Header.PubDate.ToString("ddd, dd MMM yyyy hh:mm:ss");
                return $"{rssDate} GMT";
            }
        }

        public string Url
        {
            get
            {
                return $"{Config.UrlPrefix}/{Header.CleanTitle}.html";
            }
        }

        public string RssUrl
        {
            get
            {
                return $"<link>{Url}</link>";
            }
        }

        public string IndexLink
        {
            get
            {
                return $@"<a href='{Url}'>{Header.Title}</a><span style=""float:right;"">{FriendlyDate}</span><br/>";
            }
        }

        public HtmlString Raw(string s)
        {
            return new HtmlString(s);
        }
    }
}