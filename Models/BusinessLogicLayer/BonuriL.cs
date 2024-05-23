using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;

namespace Magazin.Models.BusinessLogicLayer
{
    public class BonuriL
    {
        public List<Bonuri> GetBonuri()
        {
            using (var context = new MagazinEntities())
            {
                //return BonuriProduse.ToList();
                return context.Bonuris.Where(b => b.active == true).ToList();
            }
        }

        public List<BonProdu> GetBonprodu(int id)
        {
            using (var context = new MagazinEntities())
            {
                return context.BonProdus.Where(b => b.bon == id).ToList();
            }
        }

        public void AddBon(DateTime dateTime)
        {
            using (var context = new MagazinEntities())
            {
                context.spCreareBon(dateTime, GlobalVariables.IDuser);
            }
        }

       public void DeleteBon(int id)
       {
            using (var context = new MagazinEntities())
            {
                var bonToDelete = context.Bonuris.FirstOrDefault(b => b.IDbon == id);
                if (bonToDelete != null)
                {
                    bonToDelete.active = false;
                    context.SaveChanges();
                }
            }
       }
        
    }
}
