using Draw;
using Microsoft.AspNetCore.Mvc;
using NUglify.Css;
using SkiaSharp;
using StackExchange.Redis;
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

        // configure our brush
        var redBrush = new SKPaint
        {
            Color = new SKColor(0xff, 0, 0),
            IsStroke = true
        };
        var blueBrush = new SKPaint
        {
            Color = new SKColor(0, 0, 0xff),
            IsStroke = true
        };

        for (int i = 0; i < 64; i += 8)
        {
            var rect = new SKRect(i, i, 256 - i - 1, 256 - i - 1);
            
            skDraw.Draw(rect, default , (i % 16 == 0) ? redBrush : blueBrush);
        }
        SKPaint textPaint = new SKPaint
        {
            Color = SKColors.Chocolate
        };
        var skPoint = new SKPoint(100, 100);
        skDraw.Draw("Hello UnaDesk", skPoint , textPaint);

        var blackBrush = new SKPaint
        {
            Color = SKColors.Black
        };

        var circle = new Circle
        {
            Radius = 50f
        };

        skDraw.Draw(circle, skPoint, blackBrush);
        return File(skDraw.Save(),"image/jpg");
        
    }

   
   
}
