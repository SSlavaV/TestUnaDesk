using SkiaSharp;

namespace Draw.Wrappers
{
    public class Font : SKFont
    {
        public Font() { }
        public Font(string familyName, float size, SKColor sKColor)           
        {  
            Typeface = SKTypeface.FromFamilyName(familyName);
            Size = size;
            Color = sKColor;
        }
        private Font(SKFont font)
        {
            BaselineSnap = font.BaselineSnap;
            Edging = font.Edging;
            EmbeddedBitmaps = font.EmbeddedBitmaps;
            Embolden = font.Embolden;
            ForceAutoHinting = font.ForceAutoHinting;
            Handle = font.Handle;
            Hinting = font.Hinting;
            LinearMetrics = font.LinearMetrics;
            ScaleX = font.ScaleX;
            Size = font.Size;
            SkewX = font.SkewX;
            Subpixel = font.Subpixel;
            Typeface = font.Typeface;
        }
        public SKColor Color { get; set; }
        public Paint ToSkPaint()
        {
            var skpaint = new Paint(this)
            {
                Color = Color
            };
            return skpaint; 
        }

    }
}
