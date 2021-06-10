using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RazorPagesMegaDesk
{
    public class DesktopMaterial
    {
        public int DesktopMaterialId { get; set; }

        [Display(Name = "Desktop Material")]
        public string DesktopMaterialName { get; set; }

        public decimal DesktopMaterialPrice { get; set; }
    }
}
