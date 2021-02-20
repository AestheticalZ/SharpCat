using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SharpCat.Types.Cat;

namespace SharpCat.Requester.Cat
{
    public class SharpCatRequester
    {
        private readonly string catApiKey;

        private readonly HttpClient httpClient;

        private const string CAT_URL = "https://api.thecatapi.com/";

        public SharpCatRequester(string apiKey)
        {
            httpClient = new HttpClient { BaseAddress = new Uri(CAT_URL) };
            catApiKey = apiKey;
            httpClient.DefaultRequestHeaders.Authorization
                = new AuthenticationHeaderValue("X-API-KEY", catApiKey);
        }

        /// <summary>
        /// This function gets an image from the cat API.
        /// </summary>
        /// <param name="searchParams">The <c>CatImageSearchParams</c> object that controls the configuration.</param>
        /// <returns>
        /// An array of <c>CatImage</c> objects containing the image data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<CatImage>> GetImageAsync(CatImageSearchParams searchParams)
        {
            string queryString = GetQueryString(searchParams);
            string jsonReply = string.Empty;
            
            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/images/search?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<CatImage> imagesReply = JsonConvert.DeserializeObject<List<CatImage>>(jsonReply);

            return imagesReply;
        }

        /// <summary>
        /// This function gets a list of breeds from the cat API.
        /// </summary>
        /// <param name="searchParams">The <c>CatBreedSearchParams</c> object that controls the configuration.</param>
        /// <returns>
        /// An array of <c>CatBreed</c> objects containing the breed data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<CatBreed>> GetBreedsAsync(CatBreedSearchParams searchParams)
        {
            string queryString = GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using(HttpResponseMessage response = await httpClient.GetAsync($"v1/breeds?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<CatBreed> breedsReply = JsonConvert.DeserializeObject<List<CatBreed>>(jsonReply);

            return breedsReply;
        }

        /// <summary>
        /// This function gets a single breed from the cat API.
        /// </summary>
        /// <param name="breedName">The string object that contains the name of the breed. For example, "sib" for Siberian.</param>
        /// <returns>
        /// An array of <c>CatBreed</c> objects containing the breed data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<CatBreed>> GetBreedAsync(string breedName)
        {
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/breeds/search?q={breedName}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<CatBreed> breedsReply = JsonConvert.DeserializeObject<List<CatBreed>>(jsonReply);

            return breedsReply;
        }

        private string GetQueryString(object obj)
        {
            var properties = from p in obj.GetType().GetProperties()
                             where p.GetValue(obj, null) != null
                             select p.Name + "=" + HttpUtility.UrlEncode(p.GetValue(obj, null).ToString());

            return string.Join("&", properties.ToArray());
        }
    }
}
