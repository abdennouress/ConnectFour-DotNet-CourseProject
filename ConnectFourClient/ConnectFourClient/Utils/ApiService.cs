// ------------------------------------------------------------
// Authors: [Yosi Ben Shushan] & [Noam Ben Benjamin]
// Project: Connect Four Client - 10212 Course Project
// Date: August 2025
// Description: Part of the semester project for the .NET course.
// ------------------------------------------------------------
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using ConnectFourClient.Models;
using System.Net.Http.Json;
using System.Net;
using System.Text;

namespace ConnectFourClient.Utils
{
    public static class ApiService
    {

        private static readonly HttpClient client = new HttpClient
        {

            BaseAddress = new Uri("https://localhost:7259/api/") // Adjust the port if needed
        };

        static ApiService()
        {
            ServicePointManager.ServerCertificateValidationCallback +=
                (sender, cert, chain, sslPolicyErrors) => true;
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public static async Task<Player> GetPlayerByIdentifierAsync(int identifier)
        {
            try
            {
                HttpResponseMessage response = await client.GetAsync($"players/identifier/{identifier}");
                if (response.IsSuccessStatusCode)
                {
                    return await response.Content.ReadFromJsonAsync<Player>();
                }
                return null;
            }
            catch
            {
                return null;
            }
        }

        //POST Game 
        public static async Task PostGameAsync(Game game)
        {
            try
            {
                // Log the JSON body being sent
                var json = System.Text.Json.JsonSerializer.Serialize(game, new System.Text.Json.JsonSerializerOptions
                {
                    WriteIndented = true
                });
                Console.WriteLine("Sending JSON to /api/games:");
                Console.WriteLine(json);

                var options = new System.Text.Json.JsonSerializerOptions
                {
                    DefaultIgnoreCondition = System.Text.Json.Serialization.JsonIgnoreCondition.WhenWritingNull
                };

                var content = new StringContent(
                    System.Text.Json.JsonSerializer.Serialize(game, options),
                    Encoding.UTF8,
                    "application/json"
                );

                var resp = await client.PostAsync("games", content);

                if (!resp.IsSuccessStatusCode)
                {
                    var errorText = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine("Server responded with error body: " + errorText);
                    throw new Exception($"POST failed: {(int)resp.StatusCode} - {resp.ReasonPhrase}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to post game (ApiService): " + ex.Message);
                throw;
            }
        }



        public static async Task<MoveDecisionResponse> GetServerMoveFromBoardAsync(int[][] board)
        {
            try
            {
                var request = new MoveDecisionRequest { Board = board };

                var resp = await client.PostAsJsonAsync("games/decide-move", request);
                if (!resp.IsSuccessStatusCode)
                {
                    var errorText = await resp.Content.ReadAsStringAsync();
                    Console.WriteLine("Move decision failed: " + errorText);
                    return null;
                }

                return await resp.Content.ReadFromJsonAsync<MoveDecisionResponse>();
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to call decide-move API: " + ex.Message);
                return null;
            }
        }



    }
}

