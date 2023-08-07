using Draw.Texts.Enums;
using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Texts
{
    public class H1 : Paragraph
    {
        public H1(string text, Point point, Font font, Padding? padding = null) : base(text, point, font, padding)
        {
            
            font.Size = (float)Headers.h1;
            font.Typeface = SKTypeface.FromFamilyName(font.Typeface.FamilyName, SKFontStyle.Bold);
        }
    }
}
