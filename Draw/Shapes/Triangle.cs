using Draw.Components;
using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Shapes
{
    public class Triangle : BaseComponent
    {
        public Triangle(float x1, float y1, float x2, float y2, float x3, float y3 ) {
            Point = new Point(x1, y1);
            Point2 = new Point(x2, y2);
            Point3 = new Point(x3, y3);

        }

        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        public SKColor BackGroundColor { get; set; }
        public bool IsStroke  { get; set; } = false;
         public override void Draw(SKCanvas canvas)
        {
            var points = new SKPoint[] { Point, Point2, Point3 };

            canvas.DrawVertices(SKVertexMode.Triangles,points, new [] { BackGroundColor, BackGroundColor, BackGroundColor } , new SKPaint { IsStroke = IsStroke} );
        }
    }
}
