using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BugTracker.Data;
using BugTracker.Models;

namespace BugTracker.Pages.TicketDashboard
{
    public class EditModel : PageModel
    {
        private readonly BugTracker.Data.ApplicationDbContext _context;

        public EditModel(BugTracker.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Tickets Tickets { get; set; }
        public List<SelectListItem> Activities { get; set; }
        public List<SelectListItem> TicketType { get; set; }



        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
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
            Activities = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "1", Text = "Open Ticket"},
                new SelectListItem() {Value = "2", Text = "In Progress"},
                new SelectListItem() {Value = "3", Text = "Complete"}
            };
            
            
            Tickets = await _context.Tickets.FirstOrDefaultAsync(m => m.ID == id);

            if (Tickets == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Tickets).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TicketsExists(Tickets.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool TicketsExists(int id)
        {
            return _context.Tickets.Any(e => e.ID == id);
        }
    }
}
