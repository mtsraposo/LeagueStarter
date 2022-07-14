using League.Data;
using League.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace League.Pages.Players
{
    public class IndexModel : PageModel
    {

        private readonly LeagueContext _context;
        public IndexModel(LeagueContext context)
        {
            _context = context;
        }

        public List<Player> Players {get; set;}
        public async Task OnGetAsync()
        {
            Players = await _context.Players.ToListAsync();
        }
    }
}