using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
//using System.Text.Json.Serialization;

namespace MongoCrud.Models;

public class Comment {

    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    public string name { get; set; } = null!;

    public string email { get; set; } = null!;

}
