using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;
using WebWeatherApp.Models;

namespace WebWeatherApp.Controllers
{
    public class WeatherController : Controller
    {
        public IActionResult Index()
        {
            Weather weather = new Weather();
             
            return View(weather);
        }

        [HttpPost]
        public IActionResult Index(Weather weather)
        {
            HttpClient client = new HttpClient();

            var weather1 = new Weather();

            var apiKey = "0c1c49bf7391fcb59e7e2d68bb06cae2";

            var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={weather.CityName}&appid={apiKey}&units=imperial";

            var response = client.GetStringAsync(weatherURL).Result;

            var formattedResponse = JObject.Parse(response).GetValue("main").ToString();
 
            var responseObj = (dynamic)JObject.Parse(formattedResponse);

            weather1.Temp = responseObj.temp;
            weather1.FeelsLike = responseObj.feels_like;
            weather1.Pressure = responseObj.pressure;
            weather1.TempMax = responseObj.temp_max;
            weather1.TempMin = responseObj.temp_min;
            weather1.Humidity = responseObj.humidity;
            weather1.CityName = weather.CityName;

            return View(weather1);
        }

    }
}
