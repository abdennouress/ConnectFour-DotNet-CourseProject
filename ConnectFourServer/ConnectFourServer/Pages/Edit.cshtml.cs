using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConnectFourServer.Models;
using ConnectFourServer.Data;

namespace ConnectFourServer.Pages;

public class EditModel : PageModel
{
    private readonly AppDbContext _context;

    public EditModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Player Player { get; set; } = default!;

    public IActionResult OnGet(int id)
    {
        Player = _context.Players.FirstOrDefault(p => p.Id == id)!;
        if (Player == null)
            return NotFound();

        return Page();
    }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        var existing = _context.Players.FirstOrDefault(p => p.Id == Player.Id);
        if (existing == null)
            return NotFound();

        existing.Name = Player.Name;
        existing.Country = Player.Country;
        existing.Phone = Player.Phone;

        _context.SaveChanges();
        return RedirectToPage("Players");
    }
}
