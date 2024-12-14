using System.Collections.Generic;

namespace WSCADCodeChallenge.Models
{ 
    public interface IGraphicParser
    {
        List<IVectorGraphic> Parse(string input);
    }
}
