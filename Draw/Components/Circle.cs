using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Components
{

    public class Circle:BaseComponent
    {
        public Circle() { }

        public Circle(float cx, float cy, float radius, Paint paint)
        {
            Radius = radius;
            Point = new Point(cx, cy);
            Paint = paint;
        }

        public float Radius { get; set; }

        public override void Draw(SKCanvas canvas)
        {
            canvas.DrawCircle(Point, Radius, Paint);
        }
    }
}
