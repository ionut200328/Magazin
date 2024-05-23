using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;

namespace Magazin.Models.BusinessLogicLayer
{
    public class UtilizatoriL
    {
        public UtilizatoriL() { }

        public List<Utilizatori> GetUtilizatori()
        {
            using (var context = new MagazinEntities())
            {
                return context.Utilizatoris.Where(u => u.active == true).ToList();
            }
        }

        public void AddUtilizator(Utilizatori utilizator)
        {
            using (var context = new MagazinEntities())
            {
                context.spAddUtilizator(utilizator.nume, utilizator.parola, utilizator.tip_utilizator);
                context.SaveChanges();
            }
        }

        public void UpdateUtilizator(Utilizatori utilizator)
        {
            using (var context = new MagazinEntities())
            {
                var utilizatorToUpdate = context.Utilizatoris.FirstOrDefault(u => u.IDutilizator == utilizator.IDutilizator);
                if (utilizatorToUpdate != null)
                {
                    utilizatorToUpdate.nume = utilizator.nume;
                    utilizatorToUpdate.parola = utilizator.parola;
                    utilizatorToUpdate.tip_utilizator = utilizator.tip_utilizator;
                    context.SaveChanges();
                }
            }
        }

        public void DeleteUtilizator(int id)
        {
            using (var context = new MagazinEntities())
            {
                var utilizatorToDelete = context.Utilizatoris.FirstOrDefault(u => u.IDutilizator == id);
                if (utilizatorToDelete != null)
                {
                    utilizatorToDelete.active = false;
                    context.SaveChanges();
                }
            }
        }
    }
}
