using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace PracticaSockets.Models;

public class User
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public ObjectId Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }
}