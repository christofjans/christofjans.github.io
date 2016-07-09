using System;

namespace BlogCore
{
    public interface IArgParser
    {
        void ParseArgs(string[] args, Action<Exception> error);
    }

    public class ArgParser : IArgParser
    {
        public ArgParser(INewPostGenerator newPostGenerator, IPostConverter postConverter)
        {
            this.newPostGenerator = newPostGenerator;
            this.postConverter = postConverter;
        }

        public void ParseArgs(string[] args, Action<Exception> error)
        {
            try
            {
                ParseArgsImpl(args, error);
            }
            catch (Exception ex)
            {
                error(ex);
            }
        }

        private void ParseArgsImpl(string[] args, Action<Exception> error)
        {
            if (args.Length==0 || args.Length>2)
            {
                error(null);
            }
            else
            {
                string cmd = args[0];
                switch (cmd)
                {
                    case "new":
                        if (args.Length==1)
                        {
                            error(null);
                        }
                        else
                        {
                            this.newPostGenerator.NewPost(args[1]);
                        }
                        break;

                    case "gen":
                        if (args.Length==2)
                        {
                            error(null);
                        }
                        else
                        {
                            this.postConverter.ConvertAllPosts();
                        }
                        break;

                    default:
                        error(null);
                        break;
                }
            }
        }

        private INewPostGenerator newPostGenerator;
        private IPostConverter postConverter;
    }
}