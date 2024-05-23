using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.DataAccesssLayer;
using Magazin.Models.EntytyLayer;

namespace Magazin.Models.BusinessLogicLayer
{
    public class ProduseL
    { 
        public List<Produse> GetProduse()
        {
            using (var context = new MagazinEntities())
            {
               // get all active products
                return context.Produses.Where(p => p.active == true).ToList();
            }
        }

        public List<Producatori> GetProducatori()
        {
            using (var context = new MagazinEntities())
            {
                return context.Producatoris.ToList();
            }
        }

        public List<Categorii> GetCategorii()
        {
            using (var context = new MagazinEntities())
            {
                return context.Categoriis.ToList();
            }
        }

        public void AddProdus(Produse produs)
        {
            using (var context = new MagazinEntities())
            {
                context.spAddProdus(produs.nume_prod, produs.cod_bare, produs.producator, produs.categorie);
                context.SaveChanges();
            }
        }

        public void UpdateProdus(Produse produs)
        {
            using (var context = new MagazinEntities())
            {
                var produsToUpdate = context.Produses.FirstOrDefault(p => p.IDprodus == produs.IDprodus);
                if (produsToUpdate != null)
                {
                    produsToUpdate.nume_prod = produs.nume_prod;
                    produsToUpdate.cod_bare = produs.cod_bare;
                    produsToUpdate.producator = produs.producator;
                    produsToUpdate.categorie = produs.categorie;
                    produsToUpdate.active = produs.active;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProdus(int id)
        {
            using (var context = new MagazinEntities())
            {
                var produsToDelete = context.Produses.FirstOrDefault(p => p.IDprodus == id);
                if (produsToDelete != null)
                {
                    produsToDelete.active = false;
                    context.SaveChanges();
                }
            }
        }
    }
}
