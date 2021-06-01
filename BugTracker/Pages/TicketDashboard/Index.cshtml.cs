using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Pages.TicketDashboard
{
    public class IndexModel : PageModel
    {
        private readonly BugTracker.Data.ApplicationDbContext _context;

        public IndexModel(BugTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Tickets> Tickets { get;set; }

        public async Task OnGetAsync()
        {
            Tickets = await _context.Tickets.ToListAsync();
        }
    }
}
