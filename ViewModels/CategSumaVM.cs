using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models;
using Magazin.Models.EntytyLayer;

namespace Magazin.ViewModels
{
    public class CategSumaVM
    {
        public List<CategSum> Categorii { get; set; }

        public CategSumaVM()
        {
            Categorii = new List<CategSum>();
            using (var context = new MagazinEntities())
            {
                var categSuma = context.spValoarePerCategorie();
                foreach (var categ in categSuma)
                {
                    Categorii.Add(new CategSum
                    {
                        Categorie = categ.categorie,
                        Suma = categ.Suma
                        
                    });
                }
            }
        }
    }
}
