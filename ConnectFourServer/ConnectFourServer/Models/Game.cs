// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Server - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace ConnectFourServer.Models
{
    public class Game
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public Player Player { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public TimeSpan Duration { get; set; }

        [Required]
        public string Result { get; set; } // "Win", "Loss", "Draw"

        public int PlayerMoves { get; set; }

        public int ServerMoves { get; set; }

        public List<Move> Moves { get; set; } = new List<Move>();
    }
}
