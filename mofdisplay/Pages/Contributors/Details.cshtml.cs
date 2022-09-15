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
    public class DetailsModel : PageModel
    {
        private readonly mofdisplay.Data.mofdisplayContext _context;

        public DetailsModel(mofdisplay.Data.mofdisplayContext context)
        {
            _context = context;
        }

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
    }
}
