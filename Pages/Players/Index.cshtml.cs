using League.Data;
using League.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Http;
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
        public SelectList Teams {get; set;}
        public SelectList Positions {get; set;}

        
        public string FavoriteTeam {get; set;}
        [BindProperty(SupportsGet = true)]
        public string SelectedTeam {get; set;}
        [BindProperty(SupportsGet = true)]
        public string SelectedPosition {get; set;}
        public async Task OnGetAsync()
        {
            
            var players = from p in _context.Players
                          select p;
            if (!string.IsNullOrEmpty(SelectedTeam))
            {
                players = players.Where(p => p.TeamId == SelectedTeam);
            }
            if (!string.IsNullOrEmpty(SelectedPosition))
            {
                players = players.Where(p => p.Position == SelectedPosition);
            }

            Players = await players.ToListAsync();

            IQueryable<string> AllTeams = from player in _context.Players
                                orderby player.TeamId
                                select player.TeamId;
            Teams = new SelectList(await AllTeams.Distinct().ToListAsync());

            IQueryable<string> AllPositions = from player in _context.Players
                                orderby player.Position
                                select player.Position;
            Positions = new SelectList(await AllPositions.Distinct().ToListAsync());

            FavoriteTeam = HttpContext.Session.GetString("_Favorite");

        }

        public string PlayerClass(Player Player)
        {
            string playerClass = "d-flex";
            if (Player.TeamId == FavoriteTeam)
            {
                playerClass += " favorite";
            }
            if (Player.Depth == 1)
            {
                playerClass += " starter";
            }
            return playerClass;
        }
    }
}