using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesMegaDesk
{
    //public enum DesktopMaterial
    //{
    //    Laminate,
    //    Oak,
    //    Rosewood,
    //    Veneer,
    //    Pine
    //}

    public class Desk
    {
        // Constants
        public const short MIN_WIDTH = 24;
        public const short MAX_WIDTH = 96;
        public const short MIN_DEPTH = 12;
        public const short MAX_DEPTH = 48;
        public const short MIN_DESK_DRAWERS = 0;
        public const short MAX_DESK_DRAWERS = 7;

        // properties
        public int DeskId { get; set; }
        public decimal Width { get; set; }
        public decimal Depth { get; set; }
        public decimal NumberOfDrawers { get; set; }

        public int DesktopMaterialId { get; set; }

        // navigation properties
        public DesktopMaterial SurfaceMaterial { get; set; }
    }
}
