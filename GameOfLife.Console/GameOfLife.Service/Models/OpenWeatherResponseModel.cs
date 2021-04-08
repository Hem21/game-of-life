using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GameOfLife.Service.Models
{
    public class OpenWeatherResponseModel


    {
           
        public string Name { get; set; }

        public List<WeatherDescription> Weather { get; set; }

        public Main Main { get; set; }
    }

    public class WeatherDescription
    {
        public string Main { get; set; }
        public string Description { get; set; }
    }

    public class Main
    {
        public string Temp { get; set; }
    }



}

