
using Draw.Components;
using Draw.Interfaces;
using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Texts
{
    public class Paragraph : BaseComponent, IDimension
    {
        public Paragraph(string text, Point point, Font font, Padding? padding = null)
        {
            Point = point;
            Font = font;
            Padding = padding ?? new Padding(5, 5, 5, 5);
            Text = text;
            PointText = point;
        }

        protected Point PointText { get; set; }

        protected void DrawText(SKCanvas canvas)
        {
            SKPaint paint = Font.ToSkPaint();
            float spaceWidth = paint.MeasureText(" ");
            float wordX = 0;
            float wordY = PointText.Y + Padding.Top + paint.FontSpacing / 2;
            float width = Width;
            foreach (string word in Text.Split(" "))
            {
                var wordWidth = paint.MeasureText(word);
                if (wordWidth > width - wordX)
                {
                    wordY += paint.FontSpacing;
                    wordX = 0;
                }
                canvas.DrawText(word, PointText.X + Padding.Left + wordX, wordY, paint);
                wordX += wordWidth + spaceWidth;
            }
        }

        protected void CalculateSize()
        {
            SKPaint paint = Font.ToSkPaint();
            if (Width <= 0)
            {
                Width = paint.MeasureText(Text);
                Size = new Size(Width + Padding.Left + Padding.Right, Padding.Bottom + Padding.Top + paint.FontSpacing);
            }               
            
            float spaceWidth = paint.MeasureText(" ");
            float wordX = 0f;
            float wordY = 0f;
            foreach (string word in Text.Split(" "))
            {
                var wordWidth = paint.MeasureText(word);
                if (wordWidth > Width - wordX)
                {
                    wordY += paint.FontSpacing;
                    wordX = 0;
                }
                wordX += wordWidth + spaceWidth;
            }
            var height = wordY + Padding.Bottom + Padding.Top + paint.FontSpacing / 2;
            Size = new Size(Width + Padding.Left + Padding.Right, height);
        }

        public Padding Padding { get; set; } = new Padding(5,5,5,5);
        public string Text { get; set; } = "";
        public Font Font { get; set; }
        public float Width { get; set; }
        public Size Size {  get; set; }    

        public override void Draw(SKCanvas canvas)
        {
            CalculateSize();
            DrawText(canvas);
        }
    }
}
