using Draw.Components;
using Draw.Interfaces;
using Draw.Shapes;
using Draw.Wrappers;
using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Texts
{
    public class ListItems<TMarker> : BaseComponent
        where TMarker : BaseComponent, IDimension, new()
    {
        public ListItems(IEnumerable<string> texts, Point point, Font font, Padding padding)
        {
            Texts = texts;
            Font = font;
            Padding = padding;
            Point = point;
        }


        protected IEnumerable<string> Texts { get; }
        public Font Font { get; }
        public Padding Padding { get; }
        public SKColor MarkerColor { get; set; } = SKColors.Black;
        public bool IsStroke { get; set; } = false;
        public Size MarkerSize { get; set; } = new Size(5, 5);
        public float MarkerSpace { get; set; } = 10f;

        public override void Draw(SKCanvas canvas)
        {
            
            var paint = Font.ToSkPaint();
            var yMarkerSeek =Padding.Top + (paint.FontSpacing - MarkerSize.Heigth) / 4 ;
            var interval = MarkerSpace + paint.FontSpacing + Padding.Top + Padding.Bottom;
            foreach (var item in Texts.Select((item, index) => new { Index = index, Text = item }))
            {
                var marker  = new TMarker
                 {
                     Paint = new Wrappers.Paint
                     {
                         Color = MarkerColor,
                         IsStroke = IsStroke,
                     },
                     Size = MarkerSize
                 };

                marker.Point = new Point(Point.X, Point.Y + (yMarkerSeek + interval * item.Index));
                var text = new Paragraph(item.Text, new Point(Point.X + marker.Size.Width, Point.Y + (interval * item.Index)), Font, Padding);
                marker.Draw(canvas);
                text.Draw(canvas);
            }
        }
    }
}
