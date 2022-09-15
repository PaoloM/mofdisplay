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
    public class IndexModel : PageModel
    {
        private readonly mofdisplay.Data.mofdisplayContext _context;

        public IndexModel(mofdisplay.Data.mofdisplayContext context)
        {
            _context = context;
        }

        public IList<Contributor> Contributor { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Contributors != null)
            {
                Contributor = await _context.Contributors.ToListAsync();
            }
        }
    }
}
