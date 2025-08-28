// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ConnectFourClient.Models
{
    public class LocalGame
    {
        [Key]
        public int Id { get; set; }

        public int PlayerId { get; set; }

        [Required]
        public string PlayerName { get; set; }

        public DateTime StartTime { get; set; }

        public TimeSpan Duration { get; set; }

        public string Result { get; set; }

        public List<LocalMove> Moves { get; set; }

        public LocalGame()
        {
            Moves = new List<LocalMove>();
        }
    }

    public class LocalMove
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Game")]
        public int LocalGameId { get; set; }

        public int Row { get; set; }

        public int Column { get; set; }

        public int Who { get; set; } // 1 = Player, 2 = Server

        public DateTime Timestamp { get; set; }

        public LocalGame Game { get; set; }
    }
}
