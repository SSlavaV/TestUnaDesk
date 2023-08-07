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
    public class Image : BaseComponent
    {
        private SKBitmap _bitmap;

        public Image(Stream stream, Point point) {
            using var scdata = SKData.Create(stream);
            _bitmap = SKBitmap.Decode(scdata);
            Point = point;
        }

        public Image(string path, Point point) :this(File.OpenRead(path), point)
        {           
        }

        public override void Draw(SKCanvas canvas)
        {

            canvas.DrawBitmap(_bitmap, Point);
            _bitmap.Dispose();
        }
    }
}
