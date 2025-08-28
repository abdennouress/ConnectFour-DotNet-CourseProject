using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ConnectFourServer.Models;
using ConnectFourServer.Data;

namespace ConnectFourServer.Pages;

public class RegisterModel : PageModel
{
    private readonly AppDbContext _context;

    public RegisterModel(AppDbContext context)
    {
        _context = context;
    }

    [BindProperty]
    public Player NewPlayer { get; set; } = new();

    public string? Message { get; set; }

    public void OnGet() { }

    public IActionResult OnPost()
    {
        if (!ModelState.IsValid)
            return Page();

        if (_context.Players.Any(p => p.Identifier == NewPlayer.Identifier))
        {
            ModelState.AddModelError("NewPlayer.Identifier", "Identifier already exists.");
            return Page();
        }

        _context.Players.Add(NewPlayer);
        _context.SaveChanges();

        TempData["SuccessMessage"] = "Registration successful!";
        return RedirectToPage("Register"); // causes a GET
    }
}