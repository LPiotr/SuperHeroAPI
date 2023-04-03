using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperHeroAPI.Models;

public class SuperHero
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;
    public string Name { get; set; } = String.Empty;
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string Place { get; set; } = String.Empty;
}
