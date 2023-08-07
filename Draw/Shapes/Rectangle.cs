using Draw.Components;
using Draw.Interfaces;
using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Shapes
{
    public class Rectangle : BaseComponent, IDimension
    {
        public Rectangle() { }

        public Rectangle(float x, float y, float width, float heigth, Paint paint)
        {
            Point = new Point(x, y);
            Size = new Size(width, heigth);
            Paint = paint;
        }

        public Size Size {get; set;}

        public override void Draw(SKCanvas canvas)
        {
            var rect = SKRect.Create(Point.X, Point.Y, Size.Width, Size.Heigth);
            canvas.DrawRect(rect, Paint);
        }
    }
}
