using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Windows;
using System.Windows.Media;

namespace WSCADCodeChallenge.Models
{
    public class JsonGraphicParser : IGraphicParser
    {
        public List<IVectorGraphic> Parse(string input)
        {
            var graphics = new List<IVectorGraphic>();
            using var document = JsonDocument.Parse(input);
            var elements = document.RootElement.EnumerateArray();

            foreach (var item in elements)
            {
                var type = item.GetProperty("type").GetString();
                switch (type)
                {
                    case "line":
                        graphics.Add(new Line
                        {
                            Start = ParsePoint(item.GetProperty("a").GetString()),
                            End = ParsePoint(item.GetProperty("b").GetString()),
                            Color = ParseColor(item.GetProperty("color").GetString())
                        });
                        break;
                    case "circle":
                        graphics.Add(new Circle
                        {
                            Center = ParsePoint(item.GetProperty("center").GetString()),
                            Radius = item.GetProperty("radius").GetDouble(),
                            Filled = item.GetProperty("filled").GetBoolean(),
                            Color = ParseColor(item.GetProperty("color").GetString())
                        });
                        break;
                    case "triangle":
                        graphics.Add(new Triangle
                        {
                            A = ParsePoint(item.GetProperty("a").GetString()),
                            B = ParsePoint(item.GetProperty("b").GetString()),
                            C = ParsePoint(item.GetProperty("c").GetString()),
                            Filled = item.GetProperty("filled").GetBoolean(),
                            Color = ParseColor(item.GetProperty("color").GetString())
                        });
                        break;
                }
            }

            return graphics;
        }

        private static Point ParsePoint(string point)
        {
            return new Point(Convert.ToDouble(point.Split(';')[0]), Convert.ToDouble(point.Split(';')[1]));
        }

        private static Color ParseColor(string color)
        {
            var parts = color.Split(';').Select(byte.Parse).ToArray();
            return Color.FromArgb(parts[0], parts[1], parts[2], parts[3]);
        }
    }
}
