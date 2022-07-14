using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using League.Models;
using League.Data;
using System.Threading.Tasks;
using System.Linq;

namespace League.Pages.Players
{
    public class PlayerModel : PageModel
    {
        private readonly LeagueContext _context;
        public PlayerModel(LeagueContext context)
        {
            _context = context;
        }

        public Player Player {get; set;}
        public async Task OnGetAsync(string id)
        {
            Player = await _context.Players.FindAsync(id);
        }

    }
}