using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mofdisplay.Data;
using mofdisplay.Models;

namespace mofdisplay.Pages.Displays
{
    public class DeleteModel : PageModel
    {
        private readonly mofdisplay.Data.mofdisplayContext _context;

        public DeleteModel(mofdisplay.Data.mofdisplayContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Display Display { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Displays == null)
            {
                return NotFound();
            }

            var display = await _context.Displays.FirstOrDefaultAsync(m => m.DisplayID == id);

            if (display == null)
            {
                return NotFound();
            }
            else 
            {
                Display = display;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Displays == null)
            {
                return NotFound();
            }
            var display = await _context.Displays.FindAsync(id);

            if (display != null)
            {
                Display = display;
                _context.Displays.Remove(Display);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
