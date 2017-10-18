﻿using Newtonsoft.Json;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models.Framework
{
    
    [NotMapped]
    public class Series
    {
        public int ID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        // [JsonProperty("rating")]
        // public int Rating { get; set; }
        
        public int? GenreId { get; set; }

        [JsonProperty("genre")]
        public virtual Genre Genre { get; set; }

        [JsonProperty("creators")]
        public virtual ICollection<Person> Creators { get; set; }

        [JsonProperty("writers")]
        public virtual ICollection<Person> Writers { get; set; }

        [JsonProperty("actors")]
        public virtual ICollection<Person> Actors { get; set; }

        [JsonProperty("cast")]
        public virtual ICollection<Person> Cast { get; set; }

        [JsonProperty("ongoing")]
        public string Ongoing { get; set; }

        [JsonProperty("numberOfSeasons")]
        public int NumberOfSeasons { get; set; }

        [JsonProperty("npisodesPerSeason")]
        public int EpisodesPerSeason { get; set; }
    }
}
