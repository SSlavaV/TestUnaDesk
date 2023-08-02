using Draw.Shapes;
using Draw.Wrappers;
using SkiaSharp;

namespace Draw.Components
{
    public class BorderRectangle : Rectangle
    {
        public BorderProperties Properties { get; set; }
        public Paint Paint { get; set; }
        public override void Draw(SKCanvas canvas)
        {           
           var border = new Rectangle(Properties.Point.X, Properties.Point.Y, Properties.Width, Properties.Height, Paint);
           border.Draw(canvas);
        }
    }
}
