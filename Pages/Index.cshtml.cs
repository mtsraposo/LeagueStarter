using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using League.Data;
using League.Models;

namespace League.Pages
{
  public class IndexModel : PageModel
  {
    private readonly LeagueContext _context;
    private readonly ILogger<IndexModel> _logger;

    public IndexModel(ILogger<IndexModel> logger, LeagueContext context)
    {
      _logger = logger;
      _context = context;
    }

    public League.Models.League League { get; set; }

    public async Task OnGetAsync()
    {
      League = await _context.Leagues.FirstOrDefaultAsync();
    }
  }
}
