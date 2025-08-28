// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Server - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ConnectFourServer.Models
{
    public class Move
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Who { get; set; } // 1 = Player, 2 = Server

        [Required]
        public int Column { get; set; }

        [Required]
        public int Row { get; set; }

        [Required]
        public DateTime Timestamp { get; set; }

        public int GameId { get; set; }
    }
}
