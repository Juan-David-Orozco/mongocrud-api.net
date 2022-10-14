using MongoCrud.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;
using MongoDB.Bson;

namespace MongoCrud.Services;

public class MongoDBService {

    private readonly IMongoCollection<Comment> _commentsCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _commentsCollection = database.GetCollection<Comment>(mongoDBSettings.Value.CollectionName);
    }

    public async Task CreateAsync(Comment newComment) {
        await _commentsCollection.InsertOneAsync(newComment);
        return;
    }

    public async Task<List<Comment>> GetAsync() {
        return await _commentsCollection.Find(new BsonDocument()).ToListAsync();
    }

    public async Task DeleteAsync(string id) {
        FilterDefinition<Comment> filter = Builders<Comment>.Filter.Eq("Id", id);
        await _commentsCollection.DeleteOneAsync(filter);
        return;
    }
    



}