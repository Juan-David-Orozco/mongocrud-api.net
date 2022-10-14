using MongoCrud.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MongoCrud.Services;

public class MongoDBService {

    private readonly IMongoCollection<Comment> _commentsCollection;

    public MongoDBService(IOptions<MongoDBSettings> mongoDBSettings) {
        MongoClient client = new MongoClient(mongoDBSettings.Value.ConnectionURI);
        IMongoDatabase database = client.GetDatabase(mongoDBSettings.Value.DatabaseName);
        _commentsCollection = database.GetCollection<Comment>(mongoDBSettings.Value.CollectionName);
    }


    
}