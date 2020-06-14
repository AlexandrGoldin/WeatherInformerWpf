using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Data;
using System.Windows;
using System.Windows.Media.Imaging;

namespace WpfWeatherDemo.Converters
{
   public class WeatherIconConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var iconID = (string)value;
            var pack = "pack://application:,,,/WpfWeatherDemo;component/WeatherIcons/";

            if (iconID == null) return Binding.DoNothing;

            Uri source = new Uri(pack + iconID + ".png");

            BitmapImage bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.UriSource = source;
            bmp.EndInit();
            
            return bmp;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return DependencyProperty.UnsetValue;
           
        }
    }
}

