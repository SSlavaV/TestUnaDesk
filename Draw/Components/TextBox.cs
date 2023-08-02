﻿using Draw.Interfaces;
using Draw.Shapes;
using Draw.Wrappers;
using SkiaSharp;
namespace Draw.Components
{
    public class TextBox : IComponent, ILocation, IDimension
    {
        public TextBox(string text, Point point, Font font, Padding? padding = null) {
            Point = point;
            Font = font;
            Padding = padding ?? new Padding(5, 5, 5, 5);
            Text = text;
        }

        private void PrepareBorderRectangle()
        {
            var paint = Font.ToSkPaint();
            paint.TextAlign = SKTextAlign.Right;
            var tempborder = new SKRect();
            paint.MeasureText(Text, ref tempborder);
            var xcoord = tempborder.Left + Point.X;
            var ycoord = tempborder.Top + Point.Y;

            var borderProperties = new BorderProperties
            {
                Point = new Point(xcoord - Padding.Left, ycoord - Padding.Top),
                Width = Padding.Left + tempborder.Standardized.Width + Padding.Right,
                Height = Padding.Top + tempborder.Standardized.Height + Padding.Bottom,
                BorderWidth = BorderProperties?.BorderWidth ?? 1f,
                Color = BorderProperties?.Color ?? SKColors.DarkGray
            };
            var borderSyle = new Paint
            {
                IsStroke = true,
                Color = borderProperties.Color,
                StrokeWidth = 1,
            };
            BorderProperties = borderProperties;
            var size = new SKSize(borderProperties.Width, borderProperties.Height);
            Border = new(xcoord - Padding.Left, ycoord - Padding.Left
                , size.Width
                , size.Height
                , CornerRadius
                , borderSyle);
            Size = new Size(size.Width, size.Height);
        }

        public bool IsMultiline { get; set; } = false;
        private string _text = string.Empty; 
        public string Text { get { return _text; } set { _text = value; PrepareBorderRectangle(); }}
        public Point Point { get; set; }
        public Font Font { get; set; }
        public Padding Padding { get; }
        public SKColor BackGroundColor { get; set; } = SKColors.LightGray;
        public BorderProperties BorderProperties { get; set; }
        public float CornerRadius { get; set; } = 5f;
        protected RoundRect Border {  get; set; }

        public Size Size { get; set; }

        public virtual void Draw(SKCanvas canvas)
        {
            var background = new SKPaint
            {
                Color = BackGroundColor,
                IsStroke = false,
            };
            var roundRect = new SKRoundRect(SKRect.Create(Border.Point, new SKSize(Size.Width, Size.Height)),CornerRadius);
            canvas.DrawRoundRect(roundRect, background);
            canvas.DrawText(Text,Point,Font.ToSkPaint());
            Border.Draw(canvas);
        }

        
    }
}
