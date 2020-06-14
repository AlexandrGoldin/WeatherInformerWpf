using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWeatherDemo.Models;

namespace WpfWeatherDemo.SampleData
{
    public class SampleWeatherViewModel
    {

        public List<WeatherForecast> Forecast { get; set; }
        public WeatherForecast CurrentWeather { get; set; }

        public SampleWeatherViewModel()
        {
         ///// Edit !!!
            CurrentWeather = new WeatherForecast()
            {
                Date = DateTime.Now,
                Humidity = 82,
                MaxTemperature = 34.12,
                MinTemperature = 20.45,
                Pressure = 843.16,
                IconID = "11d",
                Temperature = 23,
                Description = "гроза с проливным дождём ",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            };
         ////// add periods. Need 8 periods(night and day) 
            Forecast = new List<WeatherForecast>();
            Forecast.Add(new WeatherForecast()
            {
                
                Date = DateTime.Now.AddHours(3),
                Humidity = 82,
                MaxTemperature = 18.33,
                MinTemperature = 12.78,
                Pressure = 843.16,
                IconID = "09d",
                Temperature = 17,
                Description = "небольшой дождь",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            }); ;
            Forecast.Add(new WeatherForecast()
            {
               
                Date = DateTime.Now.AddHours(6),
                Humidity = 82,
                ID = 800,
                MaxTemperature = 34.65,
                MinTemperature = 20.32,
                Pressure = 843.16,
                IconID = "01d",
                Temperature = 23,
                Description = "Ясно",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            });
            Forecast.Add(new WeatherForecast()
            {
                
                Date = DateTime.Now.AddHours(9),
                Humidity = 82,
                ID = 800,
                MaxTemperature = 34.65,
                MinTemperature = 20.32,
                Pressure = 843.16,
                IconID = "09d",
                Temperature = 23,
                Description = "небольшой дождь",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            });
            Forecast.Add(new WeatherForecast()
            {
               
                Date = DateTime.Now.AddHours(12),
                Humidity = 82,
                ID = 800,
                MaxTemperature = 34.65,
                MinTemperature = 20.32,
                Pressure = 843.16,
                IconID = "01d",
                Temperature = 23,
                Description = "Ясно",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            });
            Forecast.Add(new WeatherForecast()
            {
               
                Date = DateTime.Now.AddHours(15),
                Humidity = 82,
                ID = 800,
                MaxTemperature = 34.65,
                MinTemperature = 20.32,
                Pressure = 843.16,
                IconID = "11d",
                Temperature = 23,
                Description = "гроза с проливным дождём ",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            });
            Forecast.Add(new WeatherForecast()
            {
              
                Date = DateTime.Now.AddHours(18),
                Humidity = 82,
                ID = 800,
                MaxTemperature = 34.65,
                MinTemperature = 20.32,
                Pressure = 843.16,
                IconID = "01d",
                Temperature = 23,
                Description = "Ясно",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            });
            Forecast.Add(new WeatherForecast()
            {
               
                Date = DateTime.Now.AddHours(21),
                Humidity = 82,
                ID = 800,
                MaxTemperature = 34.65,
                MinTemperature = 20.32,
                Pressure = 843.16,
                IconID = "09d",
                Temperature = 23,
                Description = "небольшой дождь",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            });
            Forecast.Add(new WeatherForecast()
            {
               
                Date = DateTime.Now.AddHours(24),
                Humidity = 82,
                ID = 800,
                MaxTemperature = 34.65,
                MinTemperature = 20.32,
                Pressure = 843.16,
                IconID = "01d",
                Temperature = 23,
                Description = "Ясно",
                WindDirection = "СВ",
                WindSpeed = 1.85,
                WindType = "слабый ветер"
            });
        }
    }
}
