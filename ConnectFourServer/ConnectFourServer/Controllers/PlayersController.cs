// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Server - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using Microsoft.AspNetCore.Mvc;
using ConnectFourServer.Data;
using ConnectFourServer.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectFourServer.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PlayersController : ControllerBase
{
    private readonly AppDbContext _context;

    public PlayersController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/players
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Player>>> GetAll()
    {
        return await _context.Players.ToListAsync();
    }

    // GET: api/players/5
    [HttpGet("{id}")]
    public async Task<ActionResult<Player>> Get(int id)
    {
        var player = await _context.Players.FindAsync(id);
        return player == null ? NotFound() : Ok(player);
    }

    // GET: api/players/identifier/5
    [HttpGet("identifier/{identifier}")]
    public async Task<ActionResult<Player>> GetByIdentifier(int identifier)
    {
        var player = await _context.Players
            .FirstOrDefaultAsync(p => p.Identifier == identifier);

        

        return player == null ? NotFound() : Ok(player);
    }



    // POST: api/players
    [HttpPost]
    public async Task<ActionResult<Player>> Post(Player player)
    {
        if (_context.Players.Any(p => p.Identifier == player.Identifier))
            return BadRequest("Identifier already exists.");

        _context.Players.Add(player);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(Get), new { id = player.Id }, player);
    }

    // PUT: api/players/5
    [HttpPut("{id}")]
    public async Task<IActionResult> Put(int id, Player updated)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return NotFound();

        player.Name = updated.Name;
        player.Country = updated.Country;
        player.Phone = updated.Phone;
        player.Identifier = updated.Identifier;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/players/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var player = await _context.Players.FindAsync(id);
        if (player == null) return NotFound();

        _context.Players.Remove(player);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
