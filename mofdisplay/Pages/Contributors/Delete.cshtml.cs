using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using mofdisplay.Data;
using mofdisplay.Models;

namespace mofdisplay.Pages.Contributors
{
    public class DeleteModel : PageModel
    {
        private readonly mofdisplay.Data.mofdisplayContext _context;

        public DeleteModel(mofdisplay.Data.mofdisplayContext context)
        {
            _context = context;
        }

        [BindProperty]
      public Contributor Contributor { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contributors == null)
            {
                return NotFound();
            }

            var contributor = await _context.Contributors.FirstOrDefaultAsync(m => m.ContributorID == id);

            if (contributor == null)
            {
                return NotFound();
            }
            else 
            {
                Contributor = contributor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Contributors == null)
            {
                return NotFound();
            }
            var contributor = await _context.Contributors.FindAsync(id);

            if (contributor != null)
            {
                Contributor = contributor;
                _context.Contributors.Remove(Contributor);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
