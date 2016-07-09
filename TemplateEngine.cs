using System;
using HandlebarsDotNet;

namespace BlogCore
{
    public interface ITemplateEngine
    {
        Func<object, string> CreateMerger(string template);
    }

    public class TemplateEngine : ITemplateEngine
    {
        public Func<object, string> CreateMerger(string template)
        {
            return Handlebars.Compile(template);
        }
    }
}