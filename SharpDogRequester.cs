using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using SharpCat.Types.Dog;

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
        /// <param name="searchParams">The <c>SearchParams</c> object that controls the configuration.</param>
        /// <returns>
        /// An array of <c>DogImage</c> objects containing the image data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<DogImage>> GetImageAsync(DogSearchParams searchParams)
        {
            string queryString = GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/images/search?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<DogImage> imagesReply = JsonConvert.DeserializeObject<List<DogImage>>(jsonReply);

            return imagesReply;
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
