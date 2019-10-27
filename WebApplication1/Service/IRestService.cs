using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Service
{
    public interface IRestService
    {
        Task<AllWeatherData> Get(string url);
        Task Post(object data, string url);
    }
}