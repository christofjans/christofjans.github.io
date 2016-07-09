using static System.Console;

namespace BlogCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var argParser = Services.GetInstance<IArgParser>();

            argParser.ParseArgs(args, error: (ex)=>
            {
                if (ex==null)
                {
                    WriteLine(@"
usage:
    new {title} : generate a new blog post with the given title
    gen         : convert all the blog posts to html
                    ");
                }
                else
                {
                    WriteLine($@"
The following error happened: 
{ex.GetType()}: {ex.Message}
{ex.StackTrace}
                    ");
                }
            });
        }
    }
}
