using Newtonsoft.Json;
using SharpCat.Types.Cat;
using SharpCat.Utils;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Text;

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
        /// <param name="searchParams">The <see cref="CatImageSearchParams"/> object that controls the configuration.</param>
        /// <returns>
        /// An array of <see cref="CatImage"/> objects containing the image data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<CatImage>> GetImageAsync(CatImageSearchParams searchParams)
        {
            string queryString = Utility.GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/images/search?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<CatImage> imagesReply = JsonConvert.DeserializeObject<List<CatImage>>(jsonReply);

            return imagesReply;
        }

        /// <summary>
        /// This function gets a list of all the breeds available from the cat API.
        /// </summary>
        /// <param name="searchParams">The <see cref="CatBreedSearchParams"/> object that controls the configuration.</param>
        /// <returns>
        /// An array of <see cref="CatBreed"/> objects containing the breed data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<CatBreed>> GetBreedsAsync(CatBreedSearchParams searchParams)
        {
            string queryString = Utility.GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/breeds?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<CatBreed> breedsReply = JsonConvert.DeserializeObject<List<CatBreed>>(jsonReply);

            return breedsReply;
        }

        /// <summary>
        /// This function gets a list of breeds from the cat API using <c>breedName</c> as a search term.
        /// </summary>
        /// <param name="breedName">The string object that contains the name of the breed. For example, "sib" for Siberian.</param>
        /// <returns>
        /// An array of <see cref="CatBreed"/> objects containing the breed data.
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

        /// <summary>
        /// This function gets a list of all the categories available from the cat API.
        /// </summary>
        /// <param name="searchParams">The <see cref="CatCategorySearchParams"/> object that controls the configuration.</param>
        /// <returns>
        /// An array of <see cref="CatCategory"/> objects containing the category data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<CatCategory>> GetCategoriesAsync(CatCategorySearchParams searchParams)
        {
            string queryString = Utility.GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/categories?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<CatCategory> categoryReply = JsonConvert.DeserializeObject<List<CatCategory>>(jsonReply);

            return categoryReply;
        }

        /// <summary>
        /// This function gets a list of all your votes attached to your user.
        /// </summary>
        /// <param name="searchParams">The <see cref="CatVoteSearchParams"/> object that controls the configuration.</param>
        /// <returns>
        /// An array of <see cref="CatVote"/> objects containing the vote data.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<List<CatVote>> GetVotesAsync(CatVoteSearchParams searchParams)
        {
            string queryString = Utility.GetQueryString(searchParams);
            string jsonReply = string.Empty;

            using (HttpResponseMessage response = await httpClient.GetAsync($"v1/votes?{queryString}"))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            List<CatVote> voteReply = JsonConvert.DeserializeObject<List<CatVote>>(jsonReply);

            return voteReply;
        }

        /// <summary>
        /// This function posts a vote, <c>sub_id</c> being the username of the user you want to post it to. 
        /// <c>value</c> of 1 means upvote, <c>value</c> of 0 means downvote.
        /// </summary>
        /// <param name="searchParams">The <see cref="CatVotePost"/> object that contains the vote data.</param>
        /// <returns>
        /// A <see cref="CatVoteReply"/> object containing the POST message, if it is SUCCESS, the parameter 
        /// <c>id</c> contains the ID of the vote.
        /// </returns>
        /// <exception cref="JsonSerializationException">Thrown when the downloaded data
        /// is invalid for JSON parsing.</exception>
        public async Task<CatVoteReply> PostVoteAsync(CatVotePost postableVote)
        {
            string jsonReply = string.Empty;
            HttpContent postContent = new StringContent(JsonConvert.SerializeObject(postableVote),
                                                        Encoding.UTF8, "application/json");

            using(HttpResponseMessage response = await httpClient.PostAsync("https://api.thecatapi.com/v1/votes",
                                                                            postContent))
            {
                jsonReply = await response.Content.ReadAsStringAsync();
            }
            CatVoteReply voteReply = JsonConvert.DeserializeObject<CatVoteReply>(jsonReply);

            return voteReply;
        }
    }
}
