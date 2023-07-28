using Draw.Wrappers;
using SkiaSharp;
namespace Draw.Components
{
    public abstract class BaseComponent : IComponent
    {
        public Paint Paint { get; set; }
        public Point Point { get; set; }
        public abstract void Draw(SKCanvas canvas);        
    }
}
