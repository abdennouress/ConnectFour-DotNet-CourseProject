// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Server - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ConnectFourServer.Data;
using ConnectFourServer.Models;

namespace ConnectFourServer.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController : ControllerBase
{
    private readonly AppDbContext _context;

    public GamesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/games
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
    {
        var games = await _context.Games
             .Include(g => g.Player)
             .Include(g => g.Moves)
             .ToListAsync();

        if (games == null || games.Count == 0)
            return NotFound("No games found.");

        return Ok(games);
    }

    // GET: api/games/{id}
    [HttpGet("{id}")]
    public async Task<ActionResult<Game>> GetGame(int id)
    {
        var game = await _context.Games
           .Include(g => g.Player)
           .Include(g => g.Moves)
           .FirstOrDefaultAsync(g => g.Id == id);

        return game == null ? NotFound() : Ok(game);
    }

    // GET: api/games/player/{playerId}
    [HttpGet("player/{playerId}")]
    public async Task<ActionResult<IEnumerable<Game>>> GetGamesByPlayer(int playerId)
    {
        var exists = await _context.Players.AnyAsync(p => p.Id == playerId);
        if (!exists) return NotFound("Player not found");

        var games = await _context.Games
            .Include(g => g.Moves)
            .Where(g => g.Player.Id == playerId)
            .OrderBy(g => g.StartTime)
            .ToListAsync();

        return Ok(games);
    }

    // POST: api/games
    [HttpPost]
    public async Task<IActionResult> CreateGame([FromBody] Game game)
    {
        if (!ModelState.IsValid)
        {
            var allErrors = string.Join(" | ", ModelState.Values
                .SelectMany(v => v.Errors)
                .Select(e => e.ErrorMessage));

            return BadRequest("Model validation failed: " + allErrors);
        }

        if (game.Player == null || game.Player.Id == 0)
            return BadRequest("Missing or invalid Player object");

        var player = await _context.Players.FindAsync(game.Player.Id);
        if (player == null)
            return BadRequest("Invalid PlayerId");

        game.Player = player;
        
        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return Ok(new { game.Id });
    }

    // DELETE: api/games/{id}
    public async Task<IActionResult> DeleteGame(int id)
    {
        var game = await _context.Games
            .Include(g => g.Moves)
            .FirstOrDefaultAsync(g => g.Id == id);

        if (game == null) return NotFound();

        _context.Moves.RemoveRange(game.Moves);
        _context.Games.Remove(game);
        await _context.SaveChangesAsync();

        return NoContent();
    }

    // POST: api/games/start
    [HttpPost("start")]
    public async Task<ActionResult<StartGameResponse>> StartGame([FromBody] StartGameRequest req)
    {
        var player = await _context.Players.FindAsync(req.PlayerId);
        if (player == null) return BadRequest("Invalid PlayerId");

        var game = new Game
        {
            Player = player,
            StartTime = DateTime.UtcNow,
            Duration = TimeSpan.Zero,
            Result = "Ongoing",
            PlayerMoves = 0,
            ServerMoves = 0
        };

        _context.Games.Add(game);
        await _context.SaveChangesAsync();

        return Ok(new StartGameResponse { GameId = game.Id });
    }


    // POST: api/games/decide-move
    [HttpPost("decide-move")]
    public ActionResult<MoveDecisionResponse> DecideMove([FromBody] MoveDecisionRequest req)
    {
        if (req.Board == null || req.Board.Length == 0 || req.Board[0].Length == 0)
            return BadRequest("Board is required.");

        int rows = req.Board.Length;
        int cols = req.Board[0].Length;

        int GetDropRow(int col)
        {
            for (int r = rows - 1; r >= 0; r--)
                if (req.Board[r][col] == 0) return r;
            return -1;
        }

        // Gather all legal columns
        var legalMoves = new List<(int col, int row)>();
        for (int c = 0; c < cols; c++)
        {
            int row = GetDropRow(c);
            if (row != -1)
            {
                legalMoves.Add((c, row));
            }
        }

        // Randomly pick one
        if (legalMoves.Count > 0)
        {
            var rnd = new Random();
            var choice = legalMoves[rnd.Next(legalMoves.Count)];

            return Ok(new MoveDecisionResponse
            {
                Column = choice.col,
                Row = choice.row
            });
        }

        // No legal move
        return Ok(new MoveDecisionResponse
        {
            Column = -1,
            Row = -1
        });
    }


    // DELETE: api/games/all
    [HttpDelete("all")]
    public async Task<IActionResult> DeleteAllGames()
    {
        var games = await _context.Games
            .Include(g => g.Moves)
            .ToListAsync();

        if (games.Count == 0) return NoContent();

        var allMoves = games.SelectMany(g => g.Moves).ToList();

        _context.Moves.RemoveRange(allMoves);
        _context.Games.RemoveRange(games);
        await _context.SaveChangesAsync();

        return Ok($"Deleted {games.Count} games and {allMoves.Count} moves.");
    }


    

}
