using Magazin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;

namespace Magazin.ViewModels
{
    public class ProdCategVM
    {
        public List<ProdCateg> Produse { get; set; }

        public ProdCategVM(int prod)
        {
            Produse = new List<ProdCateg>();
            using (var context = new MagazinEntities())
            {
                var produse = context.spProducatorProdus(prod);
                foreach (var produs in produse)
                {
                    Produse.Add(new ProdCateg
                    {
                        Produs = produs.nume_prod,
                        Categorie = produs.categorie
                    });
                }
            }
        }
    }
}
