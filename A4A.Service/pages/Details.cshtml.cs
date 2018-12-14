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
    public class DetailsModel : PageModel
    {
        private readonly A4A.Data.AppDbContext _context;

        public DetailsModel(A4A.Data.AppDbContext context)
        {
            _context = context;
        }

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
    }
}
