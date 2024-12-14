using System;

namespace WSCADCodeChallenge.Models
{
    public class GraphicFactory
    {
        public static IGraphicParser GetParser(string fileType)
        {
            return fileType.ToLower() switch
            {
                "json" => new JsonGraphicParser(),
                "xml" => throw new NotImplementedException("XML parser not implemented"),
                _ => throw new ArgumentException("Unsupported file type")
            };
        }
    }
}
