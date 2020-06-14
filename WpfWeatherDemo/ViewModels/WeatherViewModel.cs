﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfWeatherDemo.Commands;
using WpfWeatherDemo.Models;
using WpfWeatherDemo.Services;
using WpfWeatherDemo.Utils;

namespace WpfWeatherDemo.ViewModels
{
    public class WeatherViewModel : ViewModelBase
    {
        private IWeatherService weatherService;
        private IDialogService dialogService;

        public WeatherViewModel(IWeatherService ws, IDialogService ds)
        {
            weatherService = ws;
            dialogService = ds;
        }

        private List<WeatherForecast> _forecast;
        public List<WeatherForecast> Forecast
        {
            get { return _forecast; }
            set
            {
                _forecast = value;
                OnPropertyChanged();
            }
        }

        private WeatherForecast _currentWeather = new WeatherForecast();
        public WeatherForecast CurrentWeather
        {
            get { return _currentWeather; }
            set
            {
                _currentWeather = value;
                OnPropertyChanged();
            }
        }

        private string _location;
        public string Location
        {
            get { return _location; }
            set
            {
                _location = value;
                OnPropertyChanged();
            }
        }

        private ICommand _getWeatherCommand;
        public ICommand GetWeatherCommand
        {
            get
            {
                if (_getWeatherCommand == null) _getWeatherCommand =
                        new RelayCommandAsync(() => GetWeather(), (o) => CanGetWeather());
                return _getWeatherCommand;
            }
        }

        public async Task GetWeather()
        {
            try
            {
                var weather = await weatherService.GetForecastAsync(Location, 3);
                CurrentWeather = weather.First();
                Forecast = weather.Skip(1).Take(8).ToList();
            }
            catch (HttpRequestException ex)
            {
                dialogService.ShowNotification("Ensure you're connected to the internet!", "Open Weather");
            }
            catch (LocationNotFoundException ex)
            {
                dialogService.ShowNotification("Location not found!", "Open Weather");
            }

        }

        public Boolean CanGetWeather()
        {
            return Location != string.Empty;
        }
    }
}
