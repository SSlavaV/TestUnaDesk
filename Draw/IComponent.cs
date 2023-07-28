using SkiaSharp;

namespace Draw
{
    public interface IComponent
    {
        void Draw(SKCanvas canvas);
    }
}
