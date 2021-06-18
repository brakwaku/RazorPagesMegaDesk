using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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
        //public const short MIN_WIDTH = 24;
        //public const short MAX_WIDTH = 96;
        //public const short MIN_DEPTH = 12;
        //public const short MAX_DEPTH = 48;
        //public const short MIN_DESK_DRAWERS = 0;
        //public const short MAX_DESK_DRAWERS = 7;

        // properties
        public int DeskId { get; set; }
        [Range(24, 96)]
        public decimal Width { get; set; }
        [Range(12, 48)]
        public decimal Depth { get; set; }

        [Display(Name = "Number Of Drawers")]
        [Range(0, 7)]
        public decimal NumberOfDrawers { get; set; }

        public int DesktopMaterialId { get; set; }

        // navigation properties
        public DesktopMaterial SurfaceMaterial { get; set; }

        //public decimal GetMaterialCost()
        //{
        //    switch (SurfaceMaterial.DesktopMaterialName)
        //    {
        //        case "Laminate":
        //            return SurfaceMaterial.DesktopMaterialPrice;

        //        case "Oak":
        //            return OAK_COST;

        //        case DesktopMaterial.Rosewood:
        //            return ROSEWOOD_COST;

        //        case DesktopMaterial.Veneer:
        //            return VENEER_COST;

        //        case DesktopMaterial.Pine:
        //            return PINE_COST;
        //        default:
        //            return 0.00M;
        //    }
        //}
    }
}
