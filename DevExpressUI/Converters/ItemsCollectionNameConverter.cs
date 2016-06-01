using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Windows.Data;
using System.Windows.Markup;
using Core.Model;

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
            var collection = value as IList<IItem>;
            if( collection == null )
                throw new ArgumentException( String.Format("Invalid argument value in {0}.Convert()"), this.GetType().Name );
            return String.Format("{0}",
                collection.Count == 1 ? collection.ElementAt(0).Name : "<Выбрано несколько изделий>");
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException(); //TODO: Need to implemented
        }
    }
}