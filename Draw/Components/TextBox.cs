using Draw.Interfaces;
using Draw.Shapes;
using Draw.Texts;
using Draw.Wrappers;
using SkiaSharp;
namespace Draw.Components
{
    public class TextBox : Paragraph, IComponent, ILocation
    {
        public TextBox(string text, Point point, Font font, Padding? padding = null):base( text, point, font, padding)
         {
            
        }
        private void PrepareBorderRectangle()
        {
            CalculateSize();
            var borderProperties = new BorderProperties
            {                
                BorderWidth = BorderProperties?.BorderWidth ?? 1f,
                Color = BorderProperties?.Color ?? SKColors.DarkGray
            };
            var borderSyle = new Paint
            {
                IsStroke = true,
                Color = borderProperties.Color,
                StrokeWidth = borderProperties.Width,
            };
            BorderProperties = borderProperties;          
            Border = new(Point.X, Point.Y
                , Size.Width
                , Size.Heigth
                , CornerRadius
                , borderSyle);
        }

        public bool IsMultiline { get; set; } = false;
        public SKColor BackGroundColor { get; set; } = SKColors.LightGray;
        public BorderProperties BorderProperties { get; set; }
        public float CornerRadius { get; set; } = 5f;
        protected RoundRect Border {  get; set; }

        

        public virtual void Draw(SKCanvas canvas)
        {
            var background = new SKPaint
            {
                Color = BackGroundColor,
                IsStroke = false,
            };
            PrepareBorderRectangle();
            var roundRect = new SKRoundRect(SKRect.Create(Border.Point, new SKSize(Size.Width, Size.Heigth)),CornerRadius);
            canvas.DrawRoundRect(roundRect, background);
            base.Draw(canvas);
            Border.Draw(canvas);
        }

        
    }
}
