using Microsoft.Practices.ServiceLocation;
using System;
using System.Globalization;
using System.Windows.Data;
using TypeUtils.Services;
using TypeUtils.Services.Impl;

namespace WpfUtils.Converter
{
    public class ExtendedValueConverter : IValueConverter
    {
        private ITypeConverter _converter;

        public ExtendedValueConverter()
        {
            // Try DI
            try
            {
                if (ServiceLocator.Current != null)
                    _converter = ServiceLocator.Current.GetInstance<ITypeConverter>();
            }
            catch (Exception) {}
            
            // Default
            if (_converter == null)
                _converter = TypeConverter.Current;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _converter.convert(value, targetType);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return _converter.convert(value, targetType);
        }
    }
}
