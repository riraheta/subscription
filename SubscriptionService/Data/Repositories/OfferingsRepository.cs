using Npgsql;

namespace  SubscriptionService.Data.Repositories;

public class OfferingsRepository : IOfferingsRepository
{
    public async Task<List<string>> GetOfferingsAsync()
    {
        var names = new List<string>{};
        var connString = "Host=localhost:5432;Username=postgres;Password=test1234;Database=postgres";

        var dataSourceBuilder = new NpgsqlDataSourceBuilder(connString);
        var dataSource = dataSourceBuilder.Build();

        var conn = await dataSource.OpenConnectionAsync();

        // Retrieve all rows
        await using (var cmd = new NpgsqlCommand("SELECT name FROM subscription_offerings", conn))
        await using (var reader = await cmd.ExecuteReaderAsync())
        {
            while (await reader.ReadAsync()) 
            {
                names.Add(reader.GetString(0));
            }
        }

        return names;
    }
}