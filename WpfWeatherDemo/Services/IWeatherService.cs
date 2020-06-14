using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfWeatherDemo.Models;

namespace WpfWeatherDemo.Services
{
    public interface IWeatherService
    {
        Task<IEnumerable<WeatherForecast>> GetForecastAsync(string location, int intervals);
    }
}
