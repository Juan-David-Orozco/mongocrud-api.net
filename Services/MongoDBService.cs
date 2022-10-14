using MongoCrud.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace MongoCrud.Services;

public class MongoDBService {

    private readonly IMongoCollection<Comment> _commentsCollection;

}