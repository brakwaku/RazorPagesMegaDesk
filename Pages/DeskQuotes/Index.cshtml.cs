using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorPagesMegaDesk;
using RazorPagesMegaDesk.Data;

namespace RazorPagesMegaDesk.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext _context;

        public IndexModel(RazorPagesMegaDesk.Data.RazorPagesMegaDeskContext context)
        {
            _context = context;
        }


        public IList<DeskQuote> DeskQuote { get;set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public SelectList SurfaceMaterial { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Delivery { get; set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote
                .Include(d => d.Desk.SurfaceMaterial)
                .Include(d => d.DeliveryType)
                .Include(d => d.Desk).ToListAsync();


            var quotes = from m in _context.DeskQuote
                         select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(s => s.CustomerName.Contains(SearchString));
            }

            DeskQuote = await quotes.ToListAsync();
        }
    }
}
