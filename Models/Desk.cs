using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RazorPagesMegaDesk
{
    public class Desk
    {
        // properties
        public int DeskId { get; set; }
        [Range(24, 96)]
        public decimal Width { get; set; }
        [Range(12, 48)]
        public decimal Depth { get; set; }

        [Display(Name = "Number Of Drawers")]
        [Range(0, 7)]
        public decimal NumberOfDrawers { get; set; }

        [Display(Name = "Desktop Material")]
        public int DesktopMaterialId { get; set; }

        // navigation properties
        public DesktopMaterial SurfaceMaterial { get; set; }
    }
}
