﻿using Draw.Shapes;
using Draw.Wrappers;
using SkiaSharp;
namespace Draw.Components
{
    public class ToolTip : TextBox
    {
        private readonly float _width;

        public ToolTip(float width, string text, Point point, Font font, Padding? padding = null) : base(text, point, font, padding)
        {
            this.BackGroundColor = SKColors.AliceBlue;
            _width = width;
            CalculateSize();
        }

        private Point PointText { get; set; }

        private void CalculateSize()
        {
            SKPaint paint = Font.ToSkPaint();
            float spaceWidth = paint.MeasureText(" ");
            float wordX =0;
            float wordY = 0;
            float width = _width + Padding.Left - Padding.Right;
            foreach (string word in Text.Split(" "))
            {
                var wordWidth = paint.MeasureText(word);
                if (wordWidth > width - wordX)
                {
                    wordY += paint.FontSpacing;
                    wordX = 0;
                }
                wordX += wordWidth + spaceWidth;
            }
            var height = wordY + Padding.Bottom + Padding.Top + paint.FontSpacing/2;
            Size = new Size(_width, height);
        }
       
        private void DrawText(SKCanvas canvas)
        {   
            SKPaint paint = Font.ToSkPaint();
            float spaceWidth = paint.MeasureText(" ");
            float wordX = PointText.X + Padding.Left;
            float wordY = PointText.Y + Padding.Top + paint.FontSpacing / 2;
            float width = _width + PointText.X + Padding.Left - Padding.Right;
            foreach (string word in Text.Split(" "))
            {
                 var wordWidth = paint.MeasureText(word);               
                if (wordWidth > width - wordX)
                {
                    wordY += paint.FontSpacing;
                    wordX = PointText.X + Padding.Left;
                }                
                canvas.DrawText(word, wordX, wordY, paint);
                wordX += wordWidth + spaceWidth;
            }
        }

        public float LinkHeigth { get; set; } = 20f;
        public float LinkWidth { get; set; } = 10f;

        public Position Position { get; set; } = Position.Bottom;

        void PrepareLink(SKCanvas canvas)
        {
            var x2seek = 0f;
            var y2seek = 0f;
            var x3seek = 0f;
            var y3seek = 0f;

            var positionXSeek = 0f;
            var positionYSeek = 0f;
            if (Position == Position.Left)
            {
                x2seek = x3seek = -1 * (LinkHeigth);
                y3seek += LinkWidth;
                x2seek -= CornerRadius;
                positionXSeek = -1 * (LinkHeigth + _width);
            }
            if (Position == Position.Right)
            {
                x2seek = x3seek = LinkHeigth;
                y3seek += LinkWidth;
                x2seek += CornerRadius;
                positionXSeek = LinkHeigth ;
            }
            if (Position == Position.Bottom)
            {
                x3seek =  LinkWidth;
                y2seek = y3seek = LinkHeigth ;
                y2seek += CornerRadius;
                positionYSeek += LinkHeigth;
            }
            if (Position == Position.Top)
            {
                x3seek = LinkWidth;
                y2seek = y3seek = -1 * LinkHeigth;
                y2seek -= CornerRadius;
                positionYSeek -= Size.Height + LinkHeigth;
            }

            var triangle = new Triangle(Point.X, Point.Y, Point.X + x2seek, Point.Y + y2seek, Point.X + x3seek, Point.Y + y3seek);
            triangle.BackGroundColor = BackGroundColor;
            triangle.Draw(canvas);
            PointText = new Point(Point.X + positionXSeek, Point.Y + positionYSeek);
        }


        public override void Draw(SKCanvas canvas)
        {
            PrepareLink(canvas);                     
            var backGround  = new RoundRect(PointText.X, PointText.Y, Size.Width, Size.Height,CornerRadius, new Paint { IsStroke = false, StrokeWidth = 2, Color = BackGroundColor});           
            backGround.Draw(canvas);
            DrawText(canvas);
        }

    }
}
