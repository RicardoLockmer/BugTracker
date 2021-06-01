using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BugTracker.Models
{
    public class Tickets
    {

        public int ID { get; set; }

        [Required(ErrorMessage = "Please fill in a title for your ticket")]
        [Display(Name = "Ticket title")]
        public string TicketName { get; set; }

        [Required(ErrorMessage = "Please fill in a brief desscription")]
        [Display(Name = "Issue Description")]
        public string TicketDecription { get; set; }

        [Required(ErrorMessage = "Please select a ticket type")]
        [Display(Name = "Ticket type")]
        public string TicketCategory { get; set; }

        [ScaffoldColumn(false)]
        public DateTime TicketDate { get; set; }

        [ScaffoldColumn(false)]
        public string TicketCreator { get; set; }

        [Display(Name = "Assign Ticket")]
        public string TicketOwner { get; set; }

        [ScaffoldColumn(false)]
        public int TicketActivity { get; set; }
    }
}
