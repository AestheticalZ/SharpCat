using Newtonsoft.Json;
using System.Collections.Generic;

namespace SharpCat.Types.Cat
{
    public class CatBreed
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
        [JsonProperty("temperament")]
        public string Temperament { get; set; }
        [JsonProperty("life_span")]
        public string LifeSpan { get; set; }
        [JsonProperty("alt_names")]
        public string AltNames { get; set; }
        [JsonProperty("wikipedia_url")]
        public string WikipediaUrl { get; set; }
        [JsonProperty("origin")]
        public string Origin { get; set; }
        [JsonProperty("weight_imperial")]
        public string ImperialWeight { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }

        [JsonProperty("experimental")]
        public int Experimental { get; set; }
        [JsonProperty("hairless")]
        public int Hairless { get; set; }
        [JsonProperty("natural")]
        public int Natural { get; set; }
        [JsonProperty("rare")]
        public int Rare { get; set; }
        [JsonProperty("rex")]
        public int Rex { get; set; }
        [JsonProperty("suppress_tail")]
        public int SuppressTail { get; set; }
        [JsonProperty("short_legs")]
        public int ShortLegs { get; set; }
        [JsonProperty("hypoallergenic")]
        public int Hypoallergenic { get; set; }

        //ALL THESE RANGE FROM 1 TO 5
        [JsonProperty("adaptability")]
        public int Adaptability { get; set; }
        [JsonProperty("affection_level")]
        public int AffectionLevel { get; set; }
        [JsonProperty("child_friendly")]
        public int ChildFriendly { get; set; }
        [JsonProperty("dog_friendly")]
        public int DogFriendly { get; set; }
        [JsonProperty("energy_level")]
        public int EnergyLevel { get; set; }
        [JsonProperty("grooming")]
        public int Grooming { get; set; }
        [JsonProperty("health_issues")]
        public int HealthIssues { get; set; }
        [JsonProperty("intelligence")]
        public int Intelligence { get; set; }
        [JsonProperty("shedding_level")]
        public int SheddingLevel { get; set; }
        [JsonProperty("social_needs")]
        public int SocialNeeds { get; set; }
        [JsonProperty("stranger_friendly")]
        public int StrangerFriendly { get; set; }
        [JsonProperty("vocalisation")]
        public int Vocalisation { get; set; }
    }

    public class CatCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class CatFact
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("text")]
        public string Text { get; set; }
        [JsonProperty("language_code")]
        public string LanguageCode { get; set; }
        [JsonProperty("breed_id")]
        public string BreedId { get; set; }
    }

    public class CatFavourite
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("image_id")]
        public string ImageId { get; set; }
        [JsonProperty("sub_id")]
        public string SubId { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
    }

    public class CatImage
    {
        [JsonProperty("id")]
        public string Id { get; set; }
        [JsonProperty("url")]
        public string Url { get; set; }
        [JsonProperty("sub_id")]
        public string SubId { get; set; }
        [JsonProperty("created_at")]
        public string CreatedAt { get; set; }
        [JsonProperty("original_filename")]
        public string OriginalFilename { get; set; }

        [JsonProperty("categories")]
        public CatCategory[] Categories { get; set; }
        [JsonProperty("breeds")]
        public CatBreed[] Breeds { get; set; }
    }

    public class CatImageSearchParams
    {
        public bool has_breeds { get; set; }
        public string mime_types { get; set; }
        public string size { get; set; }
        public string sub_id { get; set; }
        public int limit { get; set; }
    }

    public class CatBreedSearchParams
    {
        public int attach_breed { get; set; }
        public int page { get; set; }
        public int limit { get; set; }
    }
}
