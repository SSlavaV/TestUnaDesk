using Draw.Texts.Enums;
using Draw.Wrappers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Texts
{
    public class H2:Paragraph
    {
        public H2(string text, Point point, Font font, Padding? padding = null) : base(text, point, font, padding)
        {

            font.Size = (float)Headers.h2;
            font.Typeface = SKTypeface.FromFamilyName(font.Typeface.FamilyName, SKFontStyle.Bold);
        }
    }
}
