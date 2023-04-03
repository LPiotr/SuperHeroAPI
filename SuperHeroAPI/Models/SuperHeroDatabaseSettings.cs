﻿namespace SuperHeroAPI.Models
{
    public class SuperHeroDatabaseSettings : ISuperHeroDatabaseSettings
    {
        public string SuperHeroCollectionName { get; set; } = string.Empty;
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;   
    }
}
