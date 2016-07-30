using System;
using RazorLight;

namespace BlogCore
{
    public interface ITemplateEngine
    {
        Func<object, string> CreateMerger(string template);
    }

    public class TemplateEngine : ITemplateEngine
    {
        public TemplateEngine()
        {
            engine = new RazorLightEngine();
        }

        public Func<object, string> CreateMerger(string template)
        {
            return (dynamic model) =>
            {
                try
                {
                    return this.engine.ParseString(template, model);
                }
                catch (RazorLightCompilationException ex)
                {
                    foreach (var err in ex.CompilationErrors)
                    {
                        Console.WriteLine(err);
                    }
                    throw;
                }
            };
        }


        private RazorLightEngine engine;
    }
}