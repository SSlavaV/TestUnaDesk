using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Interfaces
{
    public interface IDraw
    {
        public void Draw(object sKObject, SKPoint point, SKPaint paint);
    }
}
