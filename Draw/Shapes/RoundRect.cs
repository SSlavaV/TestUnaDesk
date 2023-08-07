using Draw.Wrappers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Shapes
{
    public class RoundRect : Rectangle
    {
        public RoundRect(float x, float y, float width, float heigth, float radius, Paint paint) : base(x, y, width, heigth, paint)
        {
            Radius = radius;
        }

        public float Radius { get; }

        public override void Draw(SKCanvas canvas)
        {
            var rect = SKRect.Create(Point, new SKSize(this.Size.Width, this.Size.Heigth));
            var roundRect = new SKRoundRect(rect, Radius);
            canvas.DrawRoundRect(roundRect, Paint);
        }
    }
}
