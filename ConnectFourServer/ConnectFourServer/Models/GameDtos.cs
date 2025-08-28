// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Server - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
namespace ConnectFourServer.Models
{
    public class StartGameRequest
    {
        public int PlayerId { get; set; }
    }

    public class StartGameResponse
    {
        public int GameId { get; set; }
    }

    public class MoveRequest
    {
        public int Column { get; set; } // player's chosen column (0..6)
    }

    public class MoveResponse
    {
        public int ServerColumn { get; set; } // server's chosen column (0..6)
        public string MovesJson { get; set; } = string.Empty; // updated, for debug/view if needed
    }
}
