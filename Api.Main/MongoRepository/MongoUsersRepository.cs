using Api.Data.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Api.Main.MongoRepository
{
    public class MongoUsersRepository
    {
        private readonly IMongoCollection<MongoUsers> _usersCollection;

        public MongoUsersRepository(IOptions<MongoUsersDatabaseSettings> usersDataSettings)
        {
            var mongoClient = new MongoClient(usersDataSettings.Value.ConnectionString);

            var mongoDatabase = mongoClient.GetDatabase(usersDataSettings.Value.DatabaseName);

            _usersCollection = mongoDatabase.GetCollection<MongoUsers>(usersDataSettings.Value.UsersCollectionName);
        }

        public async Task<List<MongoUsers>> GetAsync() => await _usersCollection.Find(_ => true).ToListAsync();

        public async Task<MongoUsers?> GetAsync(string id)
        {
            try
            {
                var res = await _usersCollection.Find(x => x.FirstName == id).FirstOrDefaultAsync();
                return res;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public async Task CreateAsync(MongoUsers newUser) =>
            await _usersCollection.InsertOneAsync(newUser);

        public async Task UpdateAsync(string id, MongoUsers updatedUser) =>
            await _usersCollection.ReplaceOneAsync(x => x.Id == id, updatedUser);

        public async Task RemoveAsync(string id) =>
            await _usersCollection.DeleteOneAsync(x => x.Id == id);
    }
}
