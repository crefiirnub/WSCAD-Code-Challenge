using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace WSCADCodeChallenge.Models
{
    public class Circle : IVectorGraphic
    {
        public Point Center { get; set; }
        public double Radius { get; set; }
        public bool Filled { get; set; }
        public Color Color { get; set; }

        public void Draw(Canvas canvas)
        {
            var ellipse = new Ellipse
            {
                Width = Radius * 2,
                Height = Radius * 2,
                Stroke = new SolidColorBrush(Color),
                StrokeThickness = 1,
                Fill = Filled ? new SolidColorBrush(Color) : null
            };
            Canvas.SetLeft(ellipse, Center.X - Radius);
            Canvas.SetTop(ellipse, Center.Y - Radius);
            canvas.Children.Add(ellipse);
        }
    }
}
