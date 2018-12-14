using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using A4A.Data;

namespace A4A.Service.pages
{
    public class CreateModel : PageModel
    {
        private readonly A4A.Data.AppDbContext _context;

        public CreateModel(A4A.Data.AppDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public BusinessAgents BusinessAgents { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.BusinessAgents.Add(BusinessAgents);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}