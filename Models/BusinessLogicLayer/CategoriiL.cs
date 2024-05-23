using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;

namespace Magazin.Models.BusinessLogicLayer
{
    public class CategoriiL
    {
        public CategoriiL() { }

        public List<Categorii> GetCategorii()
        {
            using (var context = new MagazinEntities())
            {
                return context.Categoriis.Where(c => c.active == true).ToList();
            }
        }

        public void AddCategorie(Categorii categorie)
        {
            using (var context = new MagazinEntities())
            {
                context.spAddCategorie(categorie.categorie);
                context.SaveChanges();
            }
        }

        public void UpdateCategorie(Categorii categorie)
        {
            using (var context = new MagazinEntities())
            {
                var categorieToUpdate = context.Categoriis.FirstOrDefault(c => c.IDcategorie == categorie.IDcategorie);
                if (categorieToUpdate != null)
                {
                    categorieToUpdate.categorie = categorie.categorie;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteCategorie(int id)
        {
            using (var context = new MagazinEntities())
            {
                var categorieToDelete = context.Categoriis.FirstOrDefault(c => c.IDcategorie == id);
                if (categorieToDelete != null)
                {
                    categorieToDelete.active = false;
                    context.SaveChanges();
                }
            }
        }
    }
}
