using Draw.Wrappers;
using SkiaSharp;
namespace Draw.Components
{
    public class TextBox : IComponent
    {
        public TextBox(string text, Point point, Font font,Padding? padding = null) {
            Text = text;
            Point = point;
            Font = font;
            Padding = padding ?? new Padding(5,5,5,5) ;
        }

        public string Text { get; set; }
        public Point Point { get; set; }
        public Font Font { get; set; }
        public Padding Padding { get; }

        public void Draw(SKCanvas canvas)
        {
            var paint = Font.ToSkPaint();
            var tempborder = new SKRect();
            paint.MeasureText(Text,ref tempborder);


            var xcoord = tempborder.Left + Point.X;
            var ycoord = tempborder.Top + Point.Y;

            var border = new SKRect(xcoord - Padding.Left, ycoord - Padding.Top
                 , xcoord +  tempborder.Standardized.Width + Padding.Top
                 , ycoord + tempborder.Standardized.Height + Padding.Bottom
                );

            var borderSyle = new SKPaint
            {
                IsStroke = true,
                Color = SKColors.Black,
                StrokeWidth = 1, 
            };

            var background = new SKPaint
            {
                Color = SKColors.LightGray,
                IsStroke = false,
            };

            
            canvas.DrawRect(border, background);            
            canvas.DrawText(Text,Point,paint);
            canvas.DrawRect(border, borderSyle);

        }

        
    }
}
