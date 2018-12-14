using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using A4A.Data;

namespace A4A.Service.pages
{
    public class EditModel : PageModel
    {
        private readonly A4A.Data.AppDbContext _context;

        public EditModel(A4A.Data.AppDbContext context)
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(BusinessAgents).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BusinessAgentsExists(BusinessAgents.BusinessId))
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

        private bool BusinessAgentsExists(long id)
        {
            return _context.BusinessAgents.Any(e => e.BusinessId == id);
        }
    }
}
