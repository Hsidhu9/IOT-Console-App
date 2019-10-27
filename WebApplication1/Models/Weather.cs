using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Weather
    {
        public string description { get; set; }
    }

    public class Wind
    {
        string[] caridnals = { "N", "NE", "E", "SE", "S", "SW", "W", "NW", "N" };
      
        private string _direction;

        public double speed { get; set; }
        public int deg { get; set; }

        public string direction
        {
            get
            {
                return caridnals[(int)Math.Round(((double)deg % 360) / 45)];
            }
            set => _direction = value;
        }
    }
    public class Main
    {
        private double _temp;

        public double temp
        {
            get => _temp; set
            {
                _temp = value - 273.15;
            }
        }
        public int pressure { get; set; }
        public int humidity { get; set; }
    }

}
