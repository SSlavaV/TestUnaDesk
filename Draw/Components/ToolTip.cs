﻿using Draw.Shapes;
using Draw.Wrappers;
using SkiaSharp;
namespace Draw.Components
{
    public class ToolTip : TextBox
    {

        public ToolTip(float width, string text, Point point, Font font, Padding? padding = null) : base(text, point, font, padding)
        {
            BackGroundColor = SKColors.AliceBlue;
            Width = width;          
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
            if (Position == Position.Bottom)
            {
                x3seek = LinkWidth;
                y2seek = y3seek = LinkHeigth;
                y2seek += CornerRadius;
                positionYSeek += LinkHeigth;
            }
            else
            if (Position == Position.Right)
            {
                x2seek = x3seek = LinkHeigth;
                y3seek += LinkWidth;
                x2seek += CornerRadius;
                positionXSeek = LinkHeigth ;
            }
            if (Position == Position.Left)
            {
                x2seek = x3seek = -1 * (LinkHeigth);
                y3seek += LinkWidth;
                x2seek -= CornerRadius;
                positionXSeek = -1 * (LinkHeigth + Width);
            } else
            if (Position == Position.Top)
            {
                x3seek = LinkWidth;
                y2seek = y3seek = -1 * LinkHeigth;
                y2seek -= CornerRadius;
                positionYSeek -= Size.Heigth + LinkHeigth;
            }
            var triangle = new Triangle(Point.X, Point.Y, Point.X + x2seek, Point.Y + y2seek, Point.X + x3seek, Point.Y + y3seek);
            triangle.BackGroundColor = BackGroundColor;
            triangle.Draw(canvas);
            PointText = new Point(Point.X + positionXSeek, Point.Y + positionYSeek);
        }

        public override void Draw(SKCanvas canvas)
        {
            CalculateSize();
            PrepareLink(canvas);                     
            var backGround  = new RoundRect(PointText.X, PointText.Y, Size.Width, Size.Heigth, CornerRadius, new Paint { IsStroke = false, StrokeWidth = 2, Color = BackGroundColor});           
            backGround.Draw(canvas);
            DrawText(canvas);
        }

    }
}
