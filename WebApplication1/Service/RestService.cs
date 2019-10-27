using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class RestService : IRestService
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly HttpClient httpClient = null;

        public RestService(IHttpClientFactory httpClientFactory)
        {
           _clientFactory = httpClientFactory;
            httpClient = _clientFactory.CreateClient();
        }

        public async Task<AllWeatherData> Get(string url) 
        {
            HttpResponseMessage response = await httpClient.GetAsync(url);
            String stringResponse = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
            {
                throw new HttpRequestException(stringResponse);
            }
            AllWeatherData allWeatherData = JsonConvert.DeserializeObject<AllWeatherData>(stringResponse);
            return allWeatherData;
        }

        public async Task Post(Object data, string url)
        {
            StringContent stringObject = new StringContent(JsonConvert.SerializeObject(data), System.Text.Encoding.UTF8, "application/json");
            //await httpClient.PostAsync(url, stringObject);
        }
    }
}
