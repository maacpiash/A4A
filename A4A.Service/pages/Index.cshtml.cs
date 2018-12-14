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
    public class IndexModel : PageModel
    {
        private readonly A4A.Data.AppDbContext _context;

        public IndexModel(A4A.Data.AppDbContext context)
        {
            _context = context;
        }

        public IList<BusinessAgents> BusinessAgents { get;set; }

        public async Task OnGetAsync()
        {
            BusinessAgents = await _context.BusinessAgents.ToListAsync();
        }
    }
}
