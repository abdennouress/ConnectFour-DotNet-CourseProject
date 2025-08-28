// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Server - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConnectFourServer.Models
{
    public class Player
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        [MinLength(2, ErrorMessage = "Name must be at least 2 letters.")]
        [RegularExpression("^[A-Za-z]+$", ErrorMessage = "Name must be letters only.")]
        [Display(Name = "Name")]
        public string Name { get; set; } = string.Empty;

        [Required(ErrorMessage = "Country is required.")]
        public string Country { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone is required.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone must be exactly 10 digits.")]
        public string Phone { get; set; } = string.Empty;

        [Required(ErrorMessage = "Identifier is required.")]
        [Range(1, 1000, ErrorMessage = "Identifier must be between 1 and 1000.")]
        public int Identifier { get; set; } // Unique between 1–1000
        [JsonIgnore]
        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}
