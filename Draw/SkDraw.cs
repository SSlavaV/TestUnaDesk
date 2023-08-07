using Draw.Canvases;
using Draw.Interfaces;
using SkiaSharp;
using System.Windows.Input;

namespace Draw
{
    public class SkDraw<T> : ISave ,IDisposable
        where T : ICreateble, ISave, IDisposable, new()
    {
        private readonly SKCanvas _canvas;
        //private readonly Dictionary<Type, Action<DrawObject>> _painter;
        private readonly T _provider;

        public SkDraw(Stream stream)
        {
            _provider = new T();
            _canvas = _provider.Create(stream);         
        }

        public void Dispose()
        {
            _canvas.Dispose();
            _provider.Dispose();           
        }        

        public void Draw(IComponent component)
        {
            component.Draw(_canvas);
        }

        

        public byte[] Save()
        {
           return _provider.Save();
        }
    }
    

    

   

  

   

}

