using Draw;
using Draw.Canvases;
using Draw.Components;
using Draw.Interfaces;
using Draw.Shapes;
using Draw.Texts;
using Draw.Wrappers;
using SkiaSharp;

public static class ExtensionTextHelper
  
{
    public static void AddParagraph<T>(this SkDraw<T> skDraw, string text, float x1, float y1,string fontFamily, float fontSize, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var paragraph = new Paragraph(text, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            Width = width
        };
        skDraw.Draw(paragraph);
    }

    public static void AddImage<T>(this SkDraw<T> skDraw, string path, float x1, float y1) where T : ICreateble, ISave, IDisposable, new()
    {
        var image = new Image(path, new Point(x1, y1));
        skDraw.Draw(image);
    }
    public static void AddImage<T>(this SkDraw<T> skDraw, Stream stream, float x1, float y1) where T : ICreateble, ISave, IDisposable, new()
    {
        var image = new Image(stream, new Point(x1, y1));
        skDraw.Draw(image);
    }

    public static void AddListItemsCircleMarker<T>(this SkDraw<T> skDraw, IEnumerable<string> strings, float x1, float y1, string fontFamily, float fontSize, float leftPadding = 10, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5, float markerRadius = 10) where T : ICreateble, ISave, IDisposable, new()
    {
        var list = new ListItems<Circle>(strings, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding,rightPadding, topPadding, bottomPadding))
        {
            MarkerSize = new Size(markerRadius, markerRadius)
        };
        skDraw.Draw(list);
    }
    public static void AddListItemsRectangleMarker<T>(this SkDraw<T> skDraw, IEnumerable<string> strings, float x1, float y1, string fontFamily, float fontSize, float leftPadding = 10, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5, float markerWidth = 5, float markerHeigth = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var list = new ListItems<Rectangle>(strings, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            MarkerSize = new Size(markerWidth,markerHeigth)
        };
        skDraw.Draw(list);
    }

    public static void AddHeaderH1<T>(this SkDraw<T> skDraw, string text, float x1, float y1, string fontFamily, float fontSize =0, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var header = new H1(text, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            Width = width
        };
        skDraw.Draw(header);
    }

    public static void AddHeaderH2<T>(this SkDraw<T> skDraw, string text, float x1, float y1, string fontFamily, float fontSize, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var header = new H2(text, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            Width = width
        };
        skDraw.Draw(header);
    }

    public static void AddHeaderH3<T>(this SkDraw<T> skDraw, string text, float x1, float y1, string fontFamily, float fontSize, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var header = new H3(text, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            Width = width
        };
        skDraw.Draw(header);
    }

    public static void AddHeaderH4<T>(this SkDraw<T> skDraw, string text, float x1, float y1, string fontFamily, float fontSize, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var header = new H4(text, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            Width = width
        };
        skDraw.Draw(header);
    }

    public static void AddHeaderH5<T>(this SkDraw<T> skDraw, string text, float x1, float y1, string fontFamily, float fontSize, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var header = new H5(text, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            Width = width
        };
        skDraw.Draw(header);
    }

    public static void AddHeaderH6<T>(this SkDraw<T> skDraw, string text, float x1, float y1, string fontFamily, float fontSize, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5) where T : ICreateble, ISave, IDisposable, new()
    {
        var header = new H6(text, new Point(x1, y1), new Font(fontFamily, fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            Width = width
        };
        skDraw.Draw(header);
    }

    public static void AddToolTip<T>(this SkDraw<T> skDraw, string text, float x1, float y1, string fontFamily, float fontSize, float width = 0, float leftPadding = 5, float rightPadding = 5, float topPadding = 5, float bottomPadding = 5, SKColor? backgroundcolor = null, Position position = Position.Bottom, float cornerRadius = 10f) where T : ICreateble, ISave, IDisposable, new()
    {
        var tooltip = new ToolTip(width, text, new Point(x1,y1), new Font(fontFamily,fontSize), new Padding(leftPadding, rightPadding, topPadding, bottomPadding))
        {
            BackGroundColor = backgroundcolor ?? SKColor.Parse("#4A55A2"),
            Position = position,
            CornerRadius = cornerRadius
        };
        skDraw.Draw(tooltip);
    }

}