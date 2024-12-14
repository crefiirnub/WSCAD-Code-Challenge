using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WSCADCodeChallenge.Models
{
    public class Line : IVectorGraphic
    {
        public Point Start { get; set; }
        public Point End { get; set; }
        public Color Color { get; set; }

        public void Draw(Canvas canvas)
        {
            var line = new System.Windows.Shapes.Line
            {
                X1 = Start.X,
                Y1 = Start.Y,
                X2 = End.X,
                Y2 = End.Y,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1
            };
            canvas.Children.Add(line);
        }
    }
}
