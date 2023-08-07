using Draw.Interfaces;
using SkiaSharp;
using System.IO;

namespace Draw.Canvases
{
    public class BitmapCanvas : ICreateble, ISave, IDisposable
    {
        private  SKBitmap _bitmap;

        public  SKCanvas Create(Stream stream)
        {
            using var scdata = SKData.Create(stream);
            _bitmap = SKBitmap.Decode(scdata);
            return new SKCanvas(_bitmap);
        }
        public byte[] Save()
        {
            using (MemoryStream memStream = new MemoryStream())
            using (SKManagedWStream wstream = new SKManagedWStream(memStream))
            {
                _bitmap?.Encode(wstream, SKEncodedImageFormat.Jpeg, 100);
                byte[] data = memStream.ToArray();
                return data;
            };
        }

        public void Dispose()
        {
            _bitmap?.Dispose();
        }
    }
}
