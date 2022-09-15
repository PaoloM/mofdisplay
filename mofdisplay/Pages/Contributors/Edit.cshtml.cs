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

namespace mofdisplay.Pages.Contributors
{
    public class EditModel : PageModel
    {
        private readonly mofdisplay.Data.mofdisplayContext _context;

        public EditModel(mofdisplay.Data.mofdisplayContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Contributor Contributor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Contributors == null)
            {
                return NotFound();
            }

            var contributor =  await _context.Contributors.FirstOrDefaultAsync(m => m.ContributorID == id);
            if (contributor == null)
            {
                return NotFound();
            }
            Contributor = contributor;
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

            _context.Attach(Contributor).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ContributorExists(Contributor.ContributorID))
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

        private bool ContributorExists(int id)
        {
          return _context.Contributors.Any(e => e.ContributorID == id);
        }
    }
}
