using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface ICurrentWeatherService
    {
        Task<AllWeatherData> GetCurrentWeather();
        Task MonitorCurrentWeather();
    }
}