using System;
using System.Collections.Generic;
using System.Linq;

using Magazin.Models.EntytyLayer;

namespace Magazin.Models.BusinessLogicLayer
{
    public class StocuriL
    {
        public List<Stocuri> GetStocuri()
        {
            using (var context = new MagazinEntities())
            {
                return context.Stocuris.Where(s => s.cantitate > 0 && s.active == true).ToList();
            }
        }

        public void AddStoc(Stocuri stoc, double adaos)
        {
            using (var context = new MagazinEntities())
            {
                context.spAddStoc(stoc.produs, stoc.cantitate, stoc.um, stoc.aprovizionare, stoc.expirare, stoc.pret_achizitie, adaos);
                context.SaveChanges();
            }
        }

        public void UpdateStoc(int id, decimal vanzare)
        {
            using (var context = new MagazinEntities())
            {
                var stocToUpdate = context.Stocuris.FirstOrDefault(s => s.IDstoc == id);
                if (stocToUpdate != null)
                {
                    stocToUpdate.pret_vanzare = vanzare;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteStoc(int id)
        {
            using (var context = new MagazinEntities())
            {
                var stocToDelete = context.Stocuris.FirstOrDefault(s => s.IDstoc == id);
                if (stocToDelete != null)
                {
                    stocToDelete.active = false;
                    context.SaveChanges();
                }
            }
        }

    }
}
