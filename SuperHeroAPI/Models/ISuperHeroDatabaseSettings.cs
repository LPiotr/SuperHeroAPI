namespace SuperHeroAPI.Models
{
    public interface ISuperHeroDatabaseSettings
    {
        string SuperHeroesCollectionName { get; set; }
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }   
    }
}
