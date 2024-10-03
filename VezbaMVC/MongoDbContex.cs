using MongoDB.Driver;

namespace VezbaMVC
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetConnectionString("MongoDb"));
            _database = client.GetDatabase("Bioskop"); 
        }

        public IMongoCollection<Models.Movie> Movie => _database.GetCollection<Models.Movie>("Film");
    }
}
