using System;
using System.Collections.Generic;
using System.Text;

namespace IOTConsoleApp.Models
{
    public class Coord
    {
        public string lon { get; set; }
        public string lat { get; set; }
    }

    public class Weather
    {
        public string id { get; set; }
        public string main { get; set; }
        public string description { get; set; }
        public string icon { get; set; }
    }

    public class Main
    {
        public string temp { get; set; }
        public string pressure { get; set; }
        public string humidity { get; set; }
        public string temp_min { get; set; }
        public string temp_max { get; set; }
    }

    public class Wind
    {
        public string speed { get; set; }
        public string deg { get; set; }
    }

    public class Clouds
    {
        public string all { get; set; }
    }

    public class Sys
    {
        public string Type { get; set; }
        public string Id { get; set; }
        public string Message { get; set; }
        public string Country { get; set; }
        public string Sunrise { get; set; }
        public string Sunset { get; set; }
    }
    
    public class WeatherRootClass
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public Main Main { get; set; }
        public string Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Dt { get; set; }
        public Sys Sys { get; set; }
        public string Timezone { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Cod { get; set; }
    }
}
