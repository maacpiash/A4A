using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using A4A.Data;

namespace A4A.Service.pages
{
    public class DeleteModel : PageModel
    {
        private readonly A4A.Data.AppDbContext _context;

        public DeleteModel(A4A.Data.AppDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public BusinessAgents BusinessAgents { get; set; }

        public async Task<IActionResult> OnGetAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BusinessAgents = await _context.BusinessAgents.FirstOrDefaultAsync(m => m.BusinessId == id);

            if (BusinessAgents == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            BusinessAgents = await _context.BusinessAgents.FindAsync(id);

            if (BusinessAgents != null)
            {
                _context.BusinessAgents.Remove(BusinessAgents);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
