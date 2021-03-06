using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using League.Data;
using League.Models;
using System.Linq;

namespace League.Pages.Teams
{
    public class TeamModel : PageModel
    {
        private readonly LeagueContext _context;
        public TeamModel(LeagueContext context)
        {
            _context = context;
        }

        public Team Team {get; set;}
        public async Task OnGetAsync(string id)
        {
            Team = await _context.Teams
            .Include(t => t.Players)
            .Include(t => t.Division)
            .AsNoTracking()
            .FirstOrDefaultAsync(t => t.TeamId == id);
        }
    }
}