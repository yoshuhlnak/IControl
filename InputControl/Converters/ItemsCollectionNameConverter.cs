using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace InputControl.Converters
{
    public class ItemsCollectionNameConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); //TODO: Need to be implemented
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); //TODO: Need to implemented
        }
    }
}