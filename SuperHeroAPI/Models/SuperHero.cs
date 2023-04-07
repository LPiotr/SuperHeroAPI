using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperHeroAPI.Models;

public class SuperHero
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = string.Empty;
    
    [BsonElement("name")]
    public string Name { get; set; } = string.Empty;
    
    [BsonElement("firstName")]
    public string FirstName { get; set; } = string.Empty;
    
    [BsonElement("lastName")]
    public string LastName { get; set; } = string.Empty;
    
    [BsonElement("place")]
    public string Place { get; set; } = string.Empty;
}
