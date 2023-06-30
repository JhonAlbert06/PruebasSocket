using MongoDB.Driver;
using PracticaSockets.Models;

namespace PracticaSockets.Repository;

public class UserRepository
{
    private readonly IMongoCollection<User> _users;

    public UserRepository(MongoDbSettings settings)
    {
        var client = new MongoClient(settings.ConnectionString);
        var database = client.GetDatabase(settings.DatabaseName);
        _users = database.GetCollection<User>("Users");
    }

    public void Create(User user)
    {
        _users.InsertOne(user);

    }

    public List<User> GetAll()
    {
        return _users.Find(_ => true).ToList();
    }
}