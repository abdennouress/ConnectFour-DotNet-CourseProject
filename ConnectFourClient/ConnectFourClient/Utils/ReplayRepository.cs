// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using ConnectFourClient.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectFourClient.Utils
{
    public static class ReplayRepository
    {
        private static readonly string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\YosiBenShushan\Desktop\ConnectFourClient\ConnectFourClient\ReplaysDB.mdf;Integrated Security=True";

        public static void SaveGame(Game game)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Insert Player if not exists
                var checkCmd = new SqlCommand("SELECT COUNT(*) FROM Players WHERE Id = @Id", conn);
                checkCmd.Parameters.AddWithValue("@Id", game.Player.Id);
                int exists = (int)checkCmd.ExecuteScalar();
                if (exists == 0)
                {
                    var insertPlayer = new SqlCommand(@"
                        INSERT INTO Players (Id, Name, Phone, Country, Identifier)
                        VALUES (@Id, @Name, @Phone, @Country, @Identifier)", conn);
                    insertPlayer.Parameters.AddWithValue("@Id", game.Player.Id);
                    insertPlayer.Parameters.AddWithValue("@Name", game.Player.Name);
                    insertPlayer.Parameters.AddWithValue("@Phone", game.Player.Phone);
                    insertPlayer.Parameters.AddWithValue("@Country", game.Player.Country);
                    insertPlayer.Parameters.AddWithValue("@Identifier", game.Player.Identifier);
                    insertPlayer.ExecuteNonQuery();
                }

                // Insert Game
                var insertGame = new SqlCommand(@"
                    INSERT INTO Games (PlayerId, StartTime, Duration, Result, PlayerMoves, ServerMoves)
                    OUTPUT INSERTED.Id
                    VALUES (@PlayerId, @StartTime, @Duration, @Result, @PlayerMoves, @ServerMoves)", conn);
                insertGame.Parameters.AddWithValue("@PlayerId", game.Player.Id);
                insertGame.Parameters.AddWithValue("@StartTime", game.StartTime);
                insertGame.Parameters.AddWithValue("@Duration", (int)game.Duration.TotalSeconds);
                insertGame.Parameters.AddWithValue("@Result", game.Result);
                insertGame.Parameters.AddWithValue("@PlayerMoves", game.PlayerMoves);
                insertGame.Parameters.AddWithValue("@ServerMoves", game.ServerMoves);
                int gameId = (int)insertGame.ExecuteScalar();

                // Insert Moves
                foreach (var move in game.Moves)
                {
                    var insertMove = new SqlCommand(@"
                        INSERT INTO Moves (GameId, Who, ColumnNum, RowNum, Timestamp)
                        VALUES (@GameId, @Who, @Column, @Row, @Timestamp)", conn);
                    insertMove.Parameters.AddWithValue("@GameId", gameId);
                    insertMove.Parameters.AddWithValue("@Who", move.Who);
                    insertMove.Parameters.AddWithValue("@Column", move.Column);
                    insertMove.Parameters.AddWithValue("@Row", move.Row);
                    insertMove.Parameters.AddWithValue("@Timestamp", move.Timestamp);
                    insertMove.ExecuteNonQuery();
                }
            }
        }

        // Add methods like LoadGamesForPlayer(int playerId), LoadMovesForGame(int gameId) etc. later

        /// <summary>
        /// Loads all games for a specific player (by playerId).
        /// </summary>
        public static List<Game> LoadGamesForPlayer(int playerId)
        {
            var games = new List<Game>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Games WHERE PlayerId = @PlayerId", conn))
            {
                cmd.Parameters.AddWithValue("@PlayerId", playerId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        games.Add(new Game
                        {
                            Id = reader.GetInt32(reader.GetOrdinal("Id")),
                            StartTime = reader.GetDateTime(reader.GetOrdinal("StartTime")),
                            Duration = TimeSpan.Parse(reader["Duration"].ToString()),
                            Result = reader["Result"].ToString(),
                            PlayerMoves = (int)reader["PlayerMoves"],
                            ServerMoves = (int)reader["ServerMoves"],
                            Moves = new List<Move>() // load moves later
                        });
                    }
                }
            }

            return games;
        }
        public static Game LoadGameWithMoves(int gameId)
        {
            Game game = null;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                using (SqlCommand cmd = new SqlCommand("SELECT * FROM Games WHERE Id = @Id", conn))
                {
                    cmd.Parameters.AddWithValue("@Id", gameId);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            game = new Game
                            {
                                Id = gameId,
                                StartTime = (DateTime)reader["StartTime"],
                                Duration = TimeSpan.FromSeconds((int)reader["Duration"]),
                                Result = reader["Result"].ToString(),
                                PlayerMoves = (int)reader["PlayerMoves"],
                                ServerMoves = (int)reader["ServerMoves"],
                                Moves = new List<Move>()
                            };
                        }
                    }
                }
                if (game != null)
                {
                    Console.WriteLine("Starting LoadMovesForGame(gameId)...");
                    game.Moves = LoadMovesForGame(gameId);
                }
            }

            return game;
        }

        /// <summary>
        /// Loads all moves for a specific game by its gameId.
        /// </summary>
        public static List<Move> LoadMovesForGame(int gameId)
        {
            var moves = new List<Move>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("SELECT * FROM Moves WHERE GameId = @GameId ORDER BY Timestamp", conn))
            {
                cmd.Parameters.AddWithValue("@GameId", gameId);

                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        moves.Add(new Move
                        {
                            Who = (int)reader["Who"],
                            Column = (int)reader["ColumnNum"],
                            Row = (int)reader["RowNum"],
                            Timestamp = (DateTime)reader["Timestamp"]
                        });
                    }
                }
            }

            return moves;
        }


    }
}
