using System;
using System.Collections.Generic;

namespace BlogCore
{
    public static class Services
    {
        public static T GetInstance<T>()
        {
            var mapping = new Dictionary<Type, Func<object>>
            {
                [typeof(IArgParser)]            = () => new ArgParser(GetInstance<INewPostGenerator>(), GetInstance<IPostConverter>()),
                [typeof(INewPostGenerator)]     = () => new NewPostGenerator(),
                [typeof(IPostConverter)]        = () => new PostConverter(GetInstance<IMarkdownConverter>(), GetInstance<ITemplateEngine>()),
                [typeof(IMarkdownConverter)]    = () => new MarkdownConverter(),
                [typeof(ITemplateEngine)]       = () => new TemplateEngine()
            };

            return (T)mapping[typeof(T)]();
        }
    }
}