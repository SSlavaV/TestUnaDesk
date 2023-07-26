using Draw.Interfaces;
using SkiaSharp;

namespace Draw
{
    public class SkDraw : IDraw, ISave ,IDisposable
    {
        private readonly SKBitmap _bitmap;
        private readonly SKCanvas _canvas;
        private readonly Dictionary<Type, Action<DrawObject>> _painter;

        public SkDraw(Stream imageStream)
        {
            var scdata = SKData.Create(imageStream);
            _bitmap = SKBitmap.Decode(scdata); 
            _canvas = new SKCanvas(_bitmap);
            _painter = new Dictionary<Type, Action<DrawObject>>()
            {
                {typeof(SKRect),(skobject)=>_canvas.DrawRect((SKRect)skobject.SkObject,skobject.SKPaint) },
                {typeof(string),(skobject)=>_canvas.DrawText(skobject.SkObject.ToString(),skobject.SKPoint ,skobject.SKPaint) },
                {typeof(Circle),(skObject)=> _canvas.DrawCircle(skObject.SKPoint,((Circle)skObject.SkObject).Radius,skObject.SKPaint)  }
            };
        }

        public void Dispose()
        {
            _canvas.Dispose();
        }

        public void Draw(object sKObject, SKPoint point, SKPaint paint)
        {
            var drawObject = new DrawObject
            {
                SKPaint = paint,
                SKPoint = point,
                SkObject = sKObject
            };
            if(_painter.TryGetValue(sKObject.GetType(),out var paintAction))
            {
                paintAction(drawObject);
            }
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

