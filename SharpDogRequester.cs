using Newtonsoft.Json;
using SharpCat.Types.Dog;
using SharpCat.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace SharpCat.Requester.Dog
{
    public class SharpDogRequester
    {
        private readonly string dogApiKey;

        private readonly HttpClient httpClient;

        private const string DOG_URL = "https://api.thedogapi.com/";

        public SharpDogRequester(string apiKey)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(DOG_URL) };
            dogApiKey = apiKey;
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("X-API-KEY", dogApiKey);
        }

        /// <summary>
        /// This function gets an image from the dog API.
        /// </summary>
        /// <param name="searchParams">The <c>DogImageSearchParams</c> object that controls the configuration.</param>
        /// <returns>
        /// An array of <c>DogImage</c> objects containing the image data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<DogImage>> GetImageAsync(DogImageSearchParams searchParams)
        {
            string queryString = Utility.GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/images/search?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<DogImage> imagesReply = JsonConvert.DeserializeObject<List<DogImage>>(jsonReply);

            return imagesReply;
        }

        /// <summary>
        /// This function gets a list of breeds from the dog API.
        /// </summary>
        /// <param name="searchParams">The <c>DogBreedSearchParams</c> object that controls the configuration.</param>
        /// <returns>
        /// An array of <c>DogBreed</c> objects containing the breed data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<DogBreed>> GetBreedsAsync(DogBreedSearchParams searchParams)
        {
            string queryString = Utility.GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/breeds?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<DogBreed> breedsReply = JsonConvert.DeserializeObject<List<DogBreed>>(jsonReply);

            return breedsReply;
        }

        /// <summary>
        /// This function gets a single breed from the dog API.
        /// </summary>
        /// <param name="breedName">The string object that contains the name of the breed.</param>
        /// <returns>
        /// An array of <c>DogBreed</c> objects containing the breed data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<DogBreed>> GetBreedAsync(string breedName)
        {
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/breeds/search?q={breedName}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<DogBreed> breedsReply = JsonConvert.DeserializeObject<List<DogBreed>>(jsonReply);

            return breedsReply;
        }
    }
}
