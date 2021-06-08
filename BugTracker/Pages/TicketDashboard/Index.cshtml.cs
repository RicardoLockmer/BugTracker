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

        public IList<Tickets> Tickets { get; set; }

        [BindProperty]
        public int TicketActivity { get; set; }

        public async Task OnGetAsync()
        {

            Tickets = await _context.Tickets.OrderBy(t => t.TicketName).ToListAsync();
            
            
        }

        // GETS CALLED WITH AJAX TO UPDATE THE TICKET ACTIVITY WHEN DRAG AND DROPPED TO ANOTHER COLUMN
        public async Task OnPostAsync(int id, string activity)
        {

            var ChangingTicket = await _context.Tickets.FindAsync(id);
            if (activity == "InProgress")
            {
                ChangingTicket.TicketActivity = 2;
            }
            if (activity == "OpenTicket")
            {
                ChangingTicket.TicketActivity = 1;
            }
            if (activity == "Complete")
            {
                ChangingTicket.TicketActivity = 3;
            }

            await _context.SaveChangesAsync();

        }
        
        
        
    }
}
