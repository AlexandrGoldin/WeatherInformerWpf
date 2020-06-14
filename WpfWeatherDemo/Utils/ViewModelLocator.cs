using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.Unity;
using Unity;
using WpfWeatherDemo.Services;
using WpfWeatherDemo.ViewModels;

namespace WpfWeatherDemo.Utils
{
    public class ViewModelLocator
    {
        private UnityContainer _container;
        public ViewModelLocator()
        {
            _container = new UnityContainer();
            _container.RegisterType<IWeatherService, OpenWeatherMapService>();
            _container.RegisterType<IDialogService, DialogService>();
        }

        public WeatherViewModel WeatherVM
        {
            get { return _container.Resolve<WeatherViewModel>(); }
        }
    }
}
