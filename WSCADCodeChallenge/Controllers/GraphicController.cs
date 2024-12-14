using System.Collections.Generic;
using System.Windows.Controls;
using WSCADCodeChallenge.Models;

namespace WSCADCodeChallenge.Controllers
{
    public class GraphicController(Canvas canvas)
    {
        private readonly Canvas _canvas = canvas;
        private List<IVectorGraphic> _graphics = new List<IVectorGraphic>();

        public void LoadFile(string fileContent)
        {
            var parser = GraphicFactory.GetParser("json");
            _graphics = parser.Parse(fileContent);
        }

        public void GenerateGraphics()
        {
            _canvas.Children.Clear();
            foreach (var graphic in _graphics)
            {
                graphic.Draw(_canvas);
            }
        }
    }
}
