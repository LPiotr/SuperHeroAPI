namespace SuperHeroAPI.Models
{
    public interface ISuperHeroDatabaseSettings
    {
        string SuperHeroCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }   
    }
}
