using Draw.Canvases;
using Draw.Interfaces;
using Draw.Shapes;
using Draw.Wrappers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public static class ExtensionShapetHelper
    {
        public static void AddRectangle<T>(this SkDraw<T> skDraw, float x1, float y1,  float width = 1, float heigth =1, SKColor? sKColor =null, bool isSroke = false ) where T : ICreateble, ISave, IDisposable, new()
        {
            var paint = new Paint
            {
                IsStroke = isSroke,
                Color = sKColor ?? SKColors.Black,
            };

            var rect = new Rectangle(x1, y1, width, heigth, paint);
            skDraw.Draw(rect);
        }
        public static void AddCircle<T>(this SkDraw<T> skDraw, float x1, float y1, float radius = 1, SKColor? sKColor = null, bool isSroke = false) where T : ICreateble, ISave, IDisposable, new()
        {
            var paint = new Paint
            {
                IsStroke = isSroke,
                Color = sKColor ?? SKColors.Black,
            };
            var circle = new Circle(x1, y1, radius, paint);
            skDraw.Draw(circle);
        }
        public static void AddTriangle<T>(this SkDraw<T> skDraw, float x1, float y1, float x2, float y2, float x3, float y3, SKColor? sKColor = null, bool isSroke = false) where T : ICreateble, ISave, IDisposable, new()
        {           
            var triangle = new Triangle(x1, y1, x2, y2, x3, y3)
            {
                IsStroke = isSroke,
                BackGroundColor = sKColor ?? SKColors.Black,
            };
            skDraw.Draw(triangle);
        }
    }
}
