using SkiaSharp;

namespace Draw.Canvases
{
    public interface ICreateble
    {
        SKCanvas Create(Stream stream);
    }
}
