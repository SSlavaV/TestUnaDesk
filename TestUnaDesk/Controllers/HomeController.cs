using Draw;
using Draw.Components;
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



        var skPoint = new Point(100, 100);
        var font = new Font
        {
            Size = 12,
            Typeface = SKTypeface.FromFamilyName("Times New Roman", SKFontStyle.Bold),
            Color = SKColors.Red,
        };

        var typeFace = SKTypeface.CreateDefault();
        
        var text = new TextBox("assdfadsafs", skPoint, font);

        var paint = new Paint
        {
            IsStroke = false,
            Color = SKColors.Yellow,
        };

        var rect = new Rectangle(skPoint.X, skPoint.Y, 100, 100, paint);

        var circle = new Circle(skPoint.X, skPoint.Y, 100, paint);

       
        skDraw.Draw(rect);
        skDraw.Draw(circle);
        skDraw.Draw(text);

        return File(skDraw.Save(),"image/jpg");
        
    }

   
   
}
