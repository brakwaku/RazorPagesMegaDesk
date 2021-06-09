using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorPagesMegaDesk;

namespace RazorPagesMegaDesk.Data
{
    public class RazorPagesMegaDeskContext : DbContext
    {
        public RazorPagesMegaDeskContext (DbContextOptions<RazorPagesMegaDeskContext> options)
            : base(options)
        {
        }

        public DbSet<RazorPagesMegaDesk.Desk> Desk { get; set; }
    }
}
