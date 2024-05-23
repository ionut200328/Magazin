using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;

namespace Magazin.Models.BusinessLogicLayer
{
    public class ProducatoriL
    {
        public ProducatoriL() { }

        public List<Producatori> GetProducatori()
        {
            using (var context = new MagazinEntities())
            {
                return context.Producatoris.Where(p => p.active == true).ToList();
            }
        }

        public void AddProducator(Producatori producator)
        {
            using (var context = new MagazinEntities())
            {
                context.spAddProducator(producator.nume_producator, producator.tara_origine);
                context.SaveChanges();
            }
        }

        public void UpdateProducator(Producatori producator)
        {
            using (var context = new MagazinEntities())
            {
                var producatorToUpdate = context.Producatoris.FirstOrDefault(p => p.IDproducator == producator.IDproducator);
                if (producatorToUpdate != null)
                {
                    producatorToUpdate.nume_producator = producator.nume_producator;
                    producatorToUpdate.tara_origine = producator.tara_origine;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteProducator(int id)
        {
            using (var context = new MagazinEntities())
            {
                var producatorToDelete = context.Producatoris.FirstOrDefault(p => p.IDproducator == id);
                if (producatorToDelete != null)
                {
                    producatorToDelete.active = false;
                    context.SaveChanges();
                }
            }
        }
    }
}
