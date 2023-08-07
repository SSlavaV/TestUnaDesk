using Draw.Interfaces;
using SkiaSharp;
using System;


namespace Draw.Canvases
{
    public class PortableDocument : ICreateble, ISave, IDisposable
    {
        private  SKDocument _skDocument;
        private  Stream _stream;

        public float Width { get; set; } = 2480;
        public float Height { get; set; } = 3508;

        public SKCanvas Create(Stream stream)
        {
            _skDocument = SKDocument.CreatePdf(stream,300);
            _stream = stream;
            return _skDocument.BeginPage(Width, Height);
        }
        public void Dispose()
        {
            _stream?.Dispose();            
            _skDocument?.Dispose();
        }

        public byte[] Save()
        {
            _skDocument?.EndPage();
            _skDocument?.Close();
            using (MemoryStream memStream = new MemoryStream())
            {
                _stream.Position = 0;
                _stream.CopyTo(memStream);
                return memStream.ToArray();
            }
        }
    }
}
