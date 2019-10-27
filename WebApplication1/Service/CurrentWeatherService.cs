using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public class CurrentWeatherService : ICurrentWeatherService
    {
        private readonly IRestService _restService;
        private readonly string ApiKey = string.Empty;

        public CurrentWeatherService(IRestService restService)
        {
            _restService = restService;
            ApiKey = "21c0bf4fb06e763aefd31041408a1225";
        }
        public async Task<AllWeatherData> GetCurrentWeather()
        {
            string urlForWeatherOfPhx = "http://api.openweathermap.org/data/2.5/weather?q=Phoenix,US&appId=" + ApiKey;
            return await _restService.Get(urlForWeatherOfPhx);
        }

        public  async Task MonitorCurrentWeather()
        {
            AllWeatherData data = await GetCurrentWeather();

            await _restService.Post(data, "http://localhost:8080/milestone3/rest/weather/postCurrentWeather");
            Console.WriteLine(JsonConvert.SerializeObject(data));
            
        }

    }
}
