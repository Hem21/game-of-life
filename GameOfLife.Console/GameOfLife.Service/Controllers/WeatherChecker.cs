using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;


namespace GameOfLife.Service.Controllers
{
    public class WeatherChecker : Controller
    {
        [Route("api/[controller]")]
        public class WeatherController : Controller
        {
            [HttpGet("[action]/{city}")]
            public async Task<IActionResult> City(string city)
            {
                using (var client = new HttpClient())
                {
                    try
                    {
                        client.BaseAddress = new Uri("https://api.openweathermap.org");
                        var response = await client.GetAsync($"/data/2.5/weather?q=wilmslow,uk&APPID=0e1b3709b6a617e669dc0e11f9447a30");
                        response.EnsureSuccessStatusCode();

                        var stringResult = await response.Content.ReadAsStringAsync();
                        var rawWeather = JsonConvert.DeserializeObject<Models.OpenWeatherResponseModel>(stringResult);
                        return Ok(new
                        {
                            Temp = rawWeather.Main.Temp,
                            Summary = string.Join(",", rawWeather.Weather.Select(x => x.Main)).ToArray(),
                            City = rawWeather.Name
                        }) ;
                    }
                    catch (HttpRequestException httpRequestException)
                    {
                        return BadRequest($"Error getting weather from OpenWeather: {httpRequestException.Message}");
                    }
                }
            }
        }
    }
}
