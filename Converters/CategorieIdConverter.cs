using Magazin.Models.EntytyLayer;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace Magazin.Converters
{
    public class CategorieIdConverter: IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert ID back to Categorie object
            if (value is int id)
            {
                using (var context = new MagazinEntities())
                {
                    return context.spGetCategorieById(id);
                }
            }

            return value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            // Convert Categorie object to its ID (assuming IDcategorie is the property representing the ID)
            if (value is Categorii categorii)
            {
                return categorii.IDcategorie;
            }

            return value;
        }
    }
}
