using Draw.Wrappers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Components
{
    public class BorderProperties
    {
        internal float Width { get; set; }
        internal float Height { get; set; }
        public SKColor Color { get; set; }
        internal Point Point { get; set; }
        public float BorderWidth { get; set; }
    }
}
