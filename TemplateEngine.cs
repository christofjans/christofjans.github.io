using System;

namespace BlogCore
{
    public interface ITemplateEngine
    {
        string Merge<T>(string template, T data);
    }

    public class TemplateEngine : ITemplateEngine
    {
        public string Merge<T>(string template, T data)
        {
            throw new NotImplementedException();
        }
    }
}