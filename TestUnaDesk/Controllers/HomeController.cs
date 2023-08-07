using Draw;
using Draw.Canvases;
using Draw.Components;
using Draw.Interfaces;
using Draw.Shapes;
using Draw.Texts;
using Draw.Wrappers;
using Microsoft.AspNetCore.Mvc;
using SkiaSharp;
using Volo.Abp.AspNetCore.Mvc;

namespace TestUnaDesk.Controllers;

public class HomeController : AbpController
{
    public ActionResult Index()
    {
        return Redirect("~/swagger");
    }
    
    [HttpPost("drawska")]
    public ActionResult  DrawSka(IFormFile fileStream)
    {
        using var skDraw = new SkDraw<BitmapCanvas>(fileStream.OpenReadStream());
        var skPoint = new Point(500, 300);
        var font = new Font
        {
            Size = 14,
            Typeface = SKTypeface.FromFamilyName("reg", SKFontStyle.Normal),
            Color = SKColor.Parse("#FFFFFF"),
        };
        var typeFace = SKTypeface.CreateDefault();
        var text = new TextBox("Это какойто текст", skPoint, font);
        var paint = new Paint
        {
            IsStroke = false,
            Color = SKColors.Yellow,
        };
        var rect = new Rectangle(skPoint.X, skPoint.Y, 100, 100, paint);
        var circle = new Circle(skPoint.X, skPoint.Y, 100, paint);
        var triangle =new Triangle(100, 100, 200,200, 0, 200);
        
        var tooltipText = "Это очеь длиая подсказка, Это очеь длиая подсказка,Это очеь длиая подсказка,Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка,";
        skDraw.AddToolTip(tooltipText, 500,287, "reg", 14,200 );
        //

        // skDraw.Draw(rect);
        // skDraw.Draw(circle);
        //skDraw.Draw(text);
        //skDraw.Draw(triangle);

        return File(skDraw.Save(),"image/jpg");
    }

    [HttpGet("drawPdf")]
    public ActionResult DrawPdf()
    {
        using var skDraw = new SkDraw<PortableDocument>(new MemoryStream());
        var skPoint = new Point(500, 300);
        var font = new Font
        {
            Size = 14,
            Typeface = SKTypeface.FromFamilyName("reg", SKFontStyle.Normal),
            Color = SKColor.Parse("#FFFFFF"),
        };
        var typeFace = SKTypeface.CreateDefault();
        var text = new TextBox("Это какойто текст", skPoint, font);
      
        //var toolTip = new ToolTip(200, "Это очеь длиая подсказка, Это очеь длиая подсказка,Это очеь длиая подсказка,Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка,", tlPoint, font)
        //{
        //    BackGroundColor = SKColor.Parse("#4A55A2"),
        //    Position = Position.Top,
        //    CornerRadius = 10f
        //};

        skDraw.AddTriangle(100,100,200,200,0,200);
        skDraw.AddCircle(500, 300, 100, SKColors.Yellow);
        skDraw.AddRectangle(500,300,100,100, SKColors.Yellow);
        skDraw.AddHeaderH1("Заголовок H1", 1200, 100, "reg");
        skDraw.AddHeaderH1("Заголовок H2", 1200, 200, "reg");
        skDraw.AddHeaderH1("Заголовок H3", 1200, 300, "reg");
        skDraw.AddHeaderH1("Заголовок H4", 1200, 400, "reg");
        skDraw.AddHeaderH1("Заголовок H5", 1200, 500, "reg");
        skDraw.AddHeaderH1("Заголовок H6", 1200, 600, "reg");

        return File(skDraw.Save(), "application/x-pdf", $"{Guid.NewGuid()}.pdf");
    }

    [HttpGet("drawExamplePdf")]
    public ActionResult DrawExamplePdf()
    {
        using var skDraw = new SkDraw<PortableDocument>(new MemoryStream());

        skDraw.AddHeaderH1("Заголовок Жирный и Крупный", 0, 100, "reg", 0);
        skDraw.AddHeaderH2("Заголовок поменьше", 0 , 200, "reg", 0);
        var strings = new List<string> { "первый элемент в списке", "второй элемент в списке"};
        skDraw.AddListItemsCircleMarker(strings, 50, 300, "reg", 25);

        skDraw.AddImage("lev-chb-5-5.jpg", 50,400);

        var text = "это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф, это текст длинный и просто параграф,";       
        skDraw.AddParagraph(text,0,1200,"reg",20,2480);

        return File(skDraw.Save(), "application/x-pdf", $"{Guid.NewGuid()}.pdf");
    }





    }
