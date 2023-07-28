using SkiaSharp;
using System;
using System.Collections.Generic;
namespace Draw.Wrappers
{
    public class Paint:SKPaint
    {
        public Paint():base() { }
        public Paint(Font font) : base(font) { }
    }
}
