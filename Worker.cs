using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using MySql.Data.MySqlClient;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MySQLMonitorService
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private string _connectionString = "Server=localhost;Database=testdb;User ID=root;Password=your_password;";
        private int _lastProcessedId = 0;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Checking for new entries at: {time}", DateTimeOffset.Now);

                try
                {
                    // Fetch new records from the MySQL table
                    using (MySqlConnection connection = new MySqlConnection(_connectionString))
                    {
                        connection.Open();

                        // Query to get the new records after the last processed ID
                        string query = $"SELECT ID, Name, Address, Location FROM your_table WHERE ID > {_lastProcessedId} ORDER BY ID ASC";
                        MySqlCommand command = new MySqlCommand(query, connection);

                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Read the latest row
                                int id = reader.GetInt32("ID");
                                string name = reader.GetString("Name");
                                string address = reader.GetString("Address");
                                string location = reader.GetString("Location");

                                // Print the row to the console
                                Console.WriteLine($"ID: {id}, Name: {name}, Address: {address}, Location: {location}");

                                // Update the last processed ID
                                _lastProcessedId = id;
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    _logger.LogError("Error occurred: {Message}", ex.Message);
                }

                // Wait for a few seconds before checking for new entries again
                await Task.Delay(5000, stoppingToken); // Adjust the delay as needed
            }
        }
    }
}
