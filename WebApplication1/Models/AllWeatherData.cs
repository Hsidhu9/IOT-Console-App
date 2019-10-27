using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class AllWeatherData
    {
        public List<Weather> weather { get; set; }
        public Main main { get; set; }
        public Wind wind { get; set; }
        public string name { get; set; }
    }
}
