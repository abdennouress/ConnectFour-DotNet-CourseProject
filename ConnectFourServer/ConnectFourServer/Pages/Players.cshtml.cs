using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using ConnectFourServer.Models;
using ConnectFourServer.Data;

namespace ConnectFourServer.Pages;

public class PlayersModel : PageModel
{
    private readonly AppDbContext _context;

    public PlayersModel(AppDbContext context)
    {
        _context = context;
    }

    public List<Player> AllPlayers { get; set; } = new();
    public ILookup<string, Player> PlayersByCountry { get; set; } = default!;
    public List<Player> PlayersWhoNeverPlayed { get; set; } = new();
    public List<Player> FilteredPlayers { get; set; } = new();
    public List<string> AvailableCountries { get; set; } = new();
    public string? SelectedCountry { get; set; }
    public bool SortInsensitive { get; set; }
    public ILookup<int, Player> PlayersByGameCount { get; set; } = default!;

    public record PlayerGameInfo(Player Player, DateTime LatestDate);
    public List<PlayerGameInfo> LatestGamePerPlayer { get; set; } = new();

    public record PlayerGameCount(string PlayerName, int GameCount);
    public List<PlayerGameCount> GamesPerPlayer { get; set; } = new();

    public int? SelectedPlayerId { get; set; }
    public Player? SelectedPlayer { get; set; }
    public List<Game> GamesOfSelectedPlayer { get; set; } = new();
    public List<Game> AllGames { get; set; } = new();

    public List<Game> DistinctGames { get; set; } = new();


    public void OnGet(string? country, bool sortInsensitive = false, int? selectedPlayerId = null)
    {
        SortInsensitive = sortInsensitive;

        if (sortInsensitive)
        {
            AllPlayers = _context.Players
                .AsEnumerable()
                .OrderBy(p => p.Name.ToLower()) // C# string comparison is case-sensitive by default
                .ToList();
        }
        else
        {
            AllPlayers = _context.Players
                .ToList();
        }


        PlayersByCountry = AllPlayers.ToLookup(p => p.Country);

        PlayersWhoNeverPlayed = _context.Players
            .Include(p => p.Games)
            .Where(p => !p.Games.Any())
            .ToList();

        AvailableCountries = _context.Players
            .Select(p => p.Country)
            .Distinct()
            .OrderBy(c => c)
            .ToList();

        if (!string.IsNullOrEmpty(country))
        {
            SelectedCountry = country;
            FilteredPlayers = _context.Players
                .Where(p => p.Country == country)
                .ToList();
        }

        PlayersByGameCount = _context.Players
        .Include(p => p.Games)
        .AsEnumerable()
        .ToLookup(p => p.Games.Count);

        LatestGamePerPlayer = _context.Players
        .Include(p => p.Games)
        .Where(p => p.Games.Any())
        .AsEnumerable() // switch to LINQ-to-objects
        .Select(p => new PlayerGameInfo(
            p,
            p.Games.Max(g => g.StartTime)
        ))
        .OrderBy(pg => pg.Player.Name, StringComparer.Ordinal)
        .ToList();




        SelectedPlayerId = selectedPlayerId;
        if (SelectedPlayerId != null)
        {
            SelectedPlayer = _context.Players
                .Include(p => p.Games)
                .ThenInclude(g => g.Moves)
                .FirstOrDefault(p => p.Id == SelectedPlayerId);

            GamesOfSelectedPlayer = SelectedPlayer?.Games
                .OrderBy(g => g.StartTime)
                .ToList() ?? new();
        }


        AllGames = _context.Games
            .Include(g => g.Player)
            .Include(g => g.Moves)
            .OrderBy(g => g.Id)
            .ToList();

        GamesPerPlayer = _context.Players
            .Include(p => p.Games)
            .AsEnumerable() // switch to in-memory LINQ
            .Select(p => new PlayerGameCount(
                p.Name,
                p.Games.Count
            ))
            .OrderByDescending(p => p.GameCount)
            .ToList();

        // Distinct games per player (based on StartTime and Result for example)
        DistinctGames = _context.Games
            .Include(g => g.Player)
            .Include(g => g.Moves)
            .AsEnumerable()
            .GroupBy(g => new { g.Player.Identifier }) // Adjust grouping as needed
            .Select(g => g.First())
            .OrderBy(g => g.Player.Name)
            .ToList();


    }

    public IActionResult OnPostDelete(int id)
    {
        var player = _context.Players
            .Include(p => p.Games)
            .FirstOrDefault(p => p.Id == id);

        if (player != null)
        {
            foreach (var game in player.Games)
                _context.Moves.RemoveRange(game.Moves);
            _context.Games.RemoveRange(player.Games);
            _context.Players.Remove(player);
            _context.SaveChanges();
        }

        return RedirectToPage(); // reload Players page
    }
    public IActionResult OnPostDeleteGame(int id)
    {
        var game = _context.Games
            .Include(g => g.Moves)
            .FirstOrDefault(g => g.Id == id);
        if (game != null)
        {
            _context.Moves.RemoveRange(game.Moves);
            _context.Games.Remove(game);
            _context.SaveChanges();
        }

        return RedirectToPage();
    }

}
