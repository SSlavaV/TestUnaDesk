using Draw;
using Draw.Components;
using Draw.Shapes;
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
        using var skDraw = new SkDraw(fileStream.OpenReadStream());



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

        var tlPoint = new Point(500, 287);

        var toolTip = new ToolTip(200, "Это очеь длиая подсказка, Это очеь длиая подсказка,Это очеь длиая подсказка,Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка, Это очеь длиая подсказка,", tlPoint, font)
        {
            BackGroundColor = SKColor.Parse("#4A55A2"),
            Position = Position.Top,
            CornerRadius = 10f
        };
        //

        // skDraw.Draw(rect);
        // skDraw.Draw(circle);
        skDraw.Draw(text);
        //skDraw.Draw(triangle);
        skDraw.Draw(toolTip);

        return File(skDraw.Save(),"image/jpg");
        
    }

   
   
}
