using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.ComponentModel.DataAnnotations;

namespace RazorPagesMegaDesk
{
    public class DeskQuote
    {
        // constants
        private const decimal BASE_DESK_PRICE = 200.00M;
        private const decimal SURFACE_AREA_COST = 1.00M;
        private const decimal DRAWER_COST = 50.00M;

        // properties
        public int DeskQuoteId { get; set; } // primary key for DeskQuote
        public int DeskId { get; set; } // this is the foreign key that points to Desk.cs

        [Display(Name = "Customer Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string CustomerName { get; set; }

        [Display(Name = "Quote Date")]
        public string QuoteDate { get; set; } // set the type to string because we will convert dateTime to string later for a nicer format
       
        public int DeliveryId { get; set; }

        [Display(Name = "Total Price")]
        public decimal TotalPrice { get; set; }

        // navigation properties
        public Desk Desk { get; set; }

        [Display(Name = "Delivery Type")]
        public Delivery DeliveryType { get; set; }

        // get the total cost of surface area, if total is less or equal to 1000, then it is free
        public decimal GetTotalSurfaceAreaCost(decimal surfaceArea)
        {
            if (surfaceArea > 1000)
            {
                return (surfaceArea - 1000) * SURFACE_AREA_COST;
            }
            else
            {
                return 0.00M;
            }
        }
                     

        // get the total price for the specific quote
        public decimal GetQuotePrice(RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext context)
        {
            decimal totalPrice = BASE_DESK_PRICE;
            decimal surfaceArea = this.Desk.Depth * this.Desk.Width;
            decimal totalSurfaceAreaCost = GetTotalSurfaceAreaCost(surfaceArea);
            decimal totalDrawerCost = this.Desk.NumberOfDrawers * DRAWER_COST;

            var surfaceMaterialPrices = context.DesktopMaterial
                .Where(d => d.DesktopMaterialId == this.Desk.DesktopMaterialId)
                .FirstOrDefault();

            decimal surfaceMaterialCost = surfaceMaterialPrices.DesktopMaterialPrice;

            var shippingPrices = context.Delivery
                .Where(d => d.DeliveryId == this.DeliveryId).FirstOrDefault();

            // based on the delivery type and the size of desk, return different price
            decimal shippingCost;

            if (surfaceArea < 1000)
            {
                shippingCost = shippingPrices.LessThan1000;
            }
            else if (surfaceArea >= 1000 && surfaceArea <= 2000)
            {
                shippingCost = shippingPrices.Between1000And2000;
            }
            else if (surfaceArea > 2000)
            {
                shippingCost = shippingPrices.GreaterThan2000;
            }
            else
            {
                shippingCost = shippingPrices.LessThan1000;
            }


            totalPrice = totalPrice + totalSurfaceAreaCost + totalDrawerCost + surfaceMaterialCost + shippingCost;
            return totalPrice;
        }
    }
}
