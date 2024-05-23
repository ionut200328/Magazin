using Magazin.Models.EntytyLayer;
using System;
using System.Globalization;
using System.Windows.Data;

namespace Magazin.Converters
{
    public class ProducatoriIdConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert ID back to Producatori object
            if (value is int id)
            {
                using (var context = new MagazinEntities())
                {
                    return context.spGetProducatoriById(id);
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert Producatori object to its ID (assuming IDproducator is the property representing the ID)
            if (value is Producatori producatori)
            {
                return producatori.IDproducator;
            }
            return value;
        }
    } 
}
