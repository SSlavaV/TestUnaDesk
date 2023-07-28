using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Components
{
    public class Rectangle : BaseComponent
    {
        public Rectangle( ) { }

        public Rectangle(float x, float y, float width, float heigth, Paint paint)
        {
            Point = new Point( x, y );
            Width = width;
            Heigth = heigth;
            Paint = paint;
        }

        public float Width { get; set; }
        public float Heigth { get; set; }

        public override void Draw(SKCanvas canvas)
        {
            var rect = SKRect.Create(Point.X, Point.Y, Width, Heigth );
            canvas.DrawRect(rect, Paint);
        }
    }
}
