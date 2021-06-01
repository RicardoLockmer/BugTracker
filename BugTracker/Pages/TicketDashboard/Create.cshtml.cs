using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Pages.TicketDashboard
{
    public class CreateModel : PageModel
    {
        private readonly BugTracker.Data.ApplicationDbContext _context;

        public CreateModel(BugTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }
        public List<SelectListItem> TicketType { get; set; }

        public IActionResult OnGet()
        {
            TicketType = new List<SelectListItem>()
            {
                new SelectListItem() { Value = "Bug", Text = "Bug"},
                new SelectListItem() { Value = "Feature", Text = "Feature"},
                new SelectListItem() { Value = "Question", Text = "Question"},
                new SelectListItem() { Value = "Technical Issue", Text = "Technical Issue"},
                new SelectListItem() { Value = "Remove", Text = "Remove"},
                new SelectListItem() { Value = "Fix", Text = "Fix"},
                new SelectListItem() { Value = "Change", Text = "Change"},
                new SelectListItem() { Value = "Design", Text = "Design"} 
            };
            return Page();
        }

        [BindProperty]
        public Tickets Tickets { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            Tickets.TicketActivity = 1;
            _context.Tickets.Add(Tickets);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
