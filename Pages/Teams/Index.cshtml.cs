using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using League.Models;
using League.Data;


namespace League.Pages.Teams
{
    public class IndexModel : PageModel
    {
        private readonly LeagueContext _context;

        public IndexModel(LeagueContext context)
        {
            _context = context;
        }

        public List<Team> Teams {get; set;}
        public async Task OnGetAsync()
        {
            Teams = await _context.Teams.ToListAsync();
        }
    }
}