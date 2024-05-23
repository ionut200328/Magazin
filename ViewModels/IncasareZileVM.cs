using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models;
using Magazin.Models.EntytyLayer;

namespace Magazin.ViewModels
{
    public class IncasareZileVM
    {
        public List<DataSuma> Zile { get; set; }

        public IncasareZileVM(int op, DateTime data)
        {
            Zile = new List<DataSuma>();
            using (var context = new MagazinEntities())
            {
                var incasariZile = context.spUtilizatorTotalZileLuna(op, data);
                foreach (var incasare in incasariZile)
                {
                    Zile.Add(new DataSuma
                    {
                        Data = incasare.Ziua,
                        Suma = incasare.Suma

                    });
                }
            }
        }
    }
}
