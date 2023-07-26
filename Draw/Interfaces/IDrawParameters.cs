using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Draw.Interfaces
{
    public interface IDrawParameters<TObject, TSKPoint, TSKPaint>
    {
        public TObject SkObject { get; set; }
        public TSKPoint SKPoint { get; set; }
        public TSKPaint SKPaint { get; set; }
    }
}
