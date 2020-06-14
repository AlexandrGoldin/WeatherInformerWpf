using System;
using System.Globalization;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using WpfWeatherDemo.Models;
using WpfWeatherDemo.Utils;

namespace WpfWeatherDemo.Services
{
    public class OpenWeatherMapService : IWeatherService
    {
        private const string APP_ID = "8cc1a7ea7583dd5d4184ab0858273bc9";
       
        private HttpClient client;

        public OpenWeatherMapService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://api.openweathermap.org/data/2.5/");
        }

        public async Task<IEnumerable<WeatherForecast>> GetForecastAsync(string location, int intervals)
        {
            if (location == null) throw new ArgumentNullException("Location can't be null.");
            if (location == string.Empty) throw new ArgumentException("Location can't be an empty string.");
           
            if (intervals <= 0) throw new ArgumentOutOfRangeException("Days should be greater than zero.");
           
            var query = $"forecast?q={location}&mode=xml&units=metric&appid={APP_ID}&lang=ru";
            var response = await client.GetAsync(query);

            switch (response.StatusCode)
            {
                case HttpStatusCode.Unauthorized:
                    throw new UnauthorizedApiAccessException("Invalid API key.");
                case HttpStatusCode.NotFound:
                    throw new LocationNotFoundException("Location not found.");
                case HttpStatusCode.OK:
                    var s = await response.Content.ReadAsStringAsync();
                    var x = XElement.Load(new StringReader(s));

                    var data = x.Descendants("time").Select(w => new WeatherForecast
                    {
                        Description = w.Element("symbol").Attribute("name").Value,
                        ID = int.Parse(w.Element("symbol").Attribute("number").Value),
                        //IconID = w.Element("symbol").Attribute("var").Value,
                        IconID = w.Element("symbol").Attribute("var").Value,
                        //Date = DateTime.Parse(w.Attribute("day").Value),
                        Date = DateTime.Parse(w.Attribute("from").Value),
                        WindType = w.Element("windSpeed").Attribute("name").Value,
                        WindSpeed = double.Parse(w.Element("windSpeed").Attribute("mps").Value, CultureInfo.InvariantCulture),
                        WindDirection = w.Element("windDirection").Attribute("code").Value,
                        Temperature = double.Parse(w.Element("temperature").Attribute("value").Value, CultureInfo.InvariantCulture),                       
                        MaxTemperature = double.Parse(w.Element("temperature").Attribute("max").Value, CultureInfo.InvariantCulture),
                        MinTemperature = double.Parse(w.Element("temperature").Attribute("min").Value, CultureInfo.InvariantCulture),
                        Pressure = double.Parse(w.Element("pressure").Attribute("value").Value),
                        Humidity = double.Parse(w.Element("humidity").Attribute("value").Value)
                    });

                    return data;
                default:
                    throw new NotImplementedException(response.StatusCode.ToString());
            }
        }
    }
}
