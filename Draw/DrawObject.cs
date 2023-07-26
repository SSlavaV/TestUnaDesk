using Draw.Interfaces;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw
{
    public class DrawObject : IDrawParameters<object, SKPoint, SKPaint>
    {
        public object SkObject { get; set; }
        public SKPoint SKPoint { get; set; }
        public SKPaint SKPaint { get; set; }
    }
}
