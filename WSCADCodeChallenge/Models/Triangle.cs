using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WSCADCodeChallenge.Models
{
    public class Triangle : IVectorGraphic
    {
        public Point A { get; set; }
        public Point B { get; set; }
        public Point C { get; set; }
        public bool Filled { get; set; }
        public Color Color { get; set; }

        public void Draw(Canvas canvas)
        {
            var polygon = new Polygon
            {
                Points = [A, B, C],
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1,
                Fill = Filled ? new SolidColorBrush(Color) : null
            };
            canvas.Children.Add(polygon);
        }
    }
}
