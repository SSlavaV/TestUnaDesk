using Draw.Components;
using Draw.Wrappers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Shapes
{
    public class Triangle : BaseComponent
    {
        public Triangle(float x1, float y1, float x2, float y2, float x3, float y3 ) {
            Point = new Wrappers.Point(x1, y1);
            Point2 = new Wrappers.Point(x2, y2);
            Point3 = new Wrappers.Point(x3, y3);

        }

        public Point Point2 { get; set; }
        public Point Point3 { get; set; }
        public SKColor BackGroundColor { get; set; }

        public override void Draw(SKCanvas canvas)
        {
            var points = new SKPoint[] { Point, Point2, Point3 };

            canvas.DrawVertices(SKVertexMode.Triangles,points, new [] { BackGroundColor, BackGroundColor, BackGroundColor } , new SKPaint { IsStroke = false} );
        }
    }
}
