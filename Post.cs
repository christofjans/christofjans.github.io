namespace BlogCore
{
    public class Post
    {
        public PostHeader Header {get;}
        public string HtmlString {get;}

        public Post(PostHeader postHeader, string htmlString)
        {
            this.Header = postHeader;
            this.HtmlString = htmlString;
        }
    }
}