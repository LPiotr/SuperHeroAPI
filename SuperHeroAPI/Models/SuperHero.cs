using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace SuperHeroAPI.Models;

public class SuperHero
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; } = String.Empty;
    
    [BsonElement("name")]
    public string Name { get; set; } = String.Empty;
    
    [BsonElement("firstName")]
    public string FirstName { get; set; } = String.Empty;
    
    [BsonElement("lastName")]
    public string LastName { get; set; } = String.Empty;
    
    [BsonElement("place")]
    public string Place { get; set; } = String.Empty;
}
