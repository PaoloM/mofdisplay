using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mofdisplay.Data;
using mofdisplay.Models;

namespace mofdisplay.Pages.Displays
{
    public class EditModel : PageModel
    {
        private readonly mofdisplay.Data.mofdisplayContext _context;

        public EditModel(mofdisplay.Data.mofdisplayContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Display Display { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Displays == null)
            {
                return NotFound();
            }

            var display =  await _context.Displays.FirstOrDefaultAsync(m => m.DisplayID == id);
            if (display == null)
            {
                return NotFound();
            }
            Display = display;
           ViewData["CuratorID"] = new SelectList(_context.Contributors, "ContributorID", "ContributorID");
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

            _context.Attach(Display).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DisplayExists(Display.DisplayID))
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

        private bool DisplayExists(int id)
        {
          return _context.Displays.Any(e => e.DisplayID == id);
        }
    }
}
