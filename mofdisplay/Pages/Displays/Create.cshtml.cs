using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using mofdisplay.Data;
using mofdisplay.Models;

namespace mofdisplay.Pages.Displays
{
    public class CreateModel : PageModel
    {
        private readonly mofdisplay.Data.mofdisplayContext _context;

        public CreateModel(mofdisplay.Data.mofdisplayContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CuratorID"] = new SelectList(_context.Contributors, "ContributorID", "ContributorID");
            return Page();
        }

        [BindProperty]
        public Display Display { get; set; }
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Displays.Add(Display);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
