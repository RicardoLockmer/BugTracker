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
        public int TicketID { get; set; }
        public Tickets ChangingTicket { get; set; }
        [BindProperty]
        public int TicketActivity { get; set; }
        public void OnGet()
        {
            Tickets = _context.Tickets.ToList();
        }
       public async Task<IActionResult> OnPostAsync()
        {

            ChangingTicket = await _context.Tickets.FindAsync(TicketID);
            ChangingTicket.TicketActivity = TicketActivity;
            _context.SaveChanges();
            Tickets = _context.Tickets.ToList();
            return Page();

           
        }
    }
}
