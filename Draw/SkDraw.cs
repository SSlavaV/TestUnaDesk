using Draw.Interfaces;
using SkiaSharp;
using System.Windows.Input;

namespace Draw
{
    public class SkDraw : ISave ,IDisposable
    {
        private readonly SKBitmap _bitmap;
        private readonly SKCanvas _canvas;
        //private readonly Dictionary<Type, Action<DrawObject>> _painter;

        public SkDraw(Stream imageStream)
        {
            using var scdata = SKData.Create(imageStream);
            _bitmap = SKBitmap.Decode(scdata); 
            _canvas = new SKCanvas(_bitmap);           
        }

        public void Dispose()
        {
            _canvas.Dispose();
            _bitmap.Dispose();

        }        

        public void Draw(IComponent component)
        {
            component.Draw(_canvas);
        }

        

        public byte[] Save()
        {
            using (MemoryStream memStream = new MemoryStream())
            using (SKManagedWStream wstream = new SKManagedWStream(memStream))
            {
                _bitmap.Encode(wstream, SKEncodedImageFormat.Jpeg, 100);
                byte[] data = memStream.ToArray();
                return data;
            };
        }
    }
    

    

   

  

   

}

