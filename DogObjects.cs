using Newtonsoft.Json;

namespace SharpCat.Types.Dog
{
    public class DogBreed
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
        [JsonProperty("weight")]
        public DogWeight Weight { get; set; }
        [JsonProperty("country_code")]
        public string CountryCode { get; set; }
        [JsonProperty("height")]
        public DogHeight Height { get; set; }
    }

    public class DogCategory
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("name")]
        public string Name { get; set; }
    }

    public class DogFavourite
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

    public class DogFact
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

    public class DogWeight
    {
        [JsonProperty("imperial")]
        public string Imperial { get; set; }
        [JsonProperty("metric")]
        public string Metric { get; set; }
    }

    public class DogHeight
    {
        [JsonProperty("imperial")]
        public string Imperial { get; set; }
        [JsonProperty("metric")]
        public string Metric { get; set; }
    }

    public class DogImage
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
        public DogCategory[] Categories { get; set; }
        [JsonProperty("breeds")]
        public DogBreed[] Breeds { get; set; }
    }

    public class DogSearchParams
    {
        public bool has_breeds { get; set; }
        public string mime_types { get; set; }
        public string size { get; set; }
        public string sub_id { get; set; }
        public int limit { get; set; }
    }
}
