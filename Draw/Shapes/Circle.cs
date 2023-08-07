using Draw.Components;
using Draw.Interfaces;
using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Shapes
{

    public class Circle : BaseComponent,IDimension
    {
        public Circle() { }

        public Circle(float cx, float cy, float radius, Paint paint)
        {
            Radius = radius;
            Point = new Point(cx, cy);
            Paint = paint;
        }

        public float Radius { get; set; }
        public Size Size { get; set; }

        public override void Draw(SKCanvas canvas)
        {
            if (Radius == 0)
            {
                Radius = Size.Heigth == 0 ? Size.Width / 2 : Size.Heigth / 2;
                Point = new Point(Point.X + Radius, Point.Y + Radius );
            }
            canvas.DrawCircle(Point, Radius, Paint);
        }
    }
}
