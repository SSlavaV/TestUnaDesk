using SkiaSharp;

namespace Draw.Wrappers
{
    public class Point 
    {
        public Point(float x, float y)
        {
            X = x;
            Y = y;
        }

        public float X { get; set; }
        public float Y { get; set; }

        public static implicit operator SKPoint(Point pt) => new SKPoint(pt.X,pt.Y);
        public static explicit operator Point(SKPoint skp) => new Point(skp.X,skp.Y);
    }
}
