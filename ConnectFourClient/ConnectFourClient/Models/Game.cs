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
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;
namespace ConnectFourClient.Models
{
    /// <summary>
    /// Client-side Game model. Matches the server DTO and
    /// carries a local Moves list that we serialize into MovesJson when posting.
    /// </summary>
   
    public class Game
    {
        public int Id { get; set; }
        public Player Player { get; set; }
        public DateTime StartTime { get; set; }
        public TimeSpan Duration { get; set; }
        public string Result { get; set; }
        public int PlayerMoves { get; set; }
        public int ServerMoves { get; set; }

        public List<Move> Moves { get; set; }

        public Game()
        {
            Moves = new List<Move>();
        }
    }

    public class Move
    {
        public int Who { get; set; }        // GameManager.PLAYER or SERVER
        public int Column { get; set; }
        public int Row { get; set; }
        public DateTime Timestamp { get; set; }
    }




}
