using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;
using Magazin.Models;
using Magazin.Models.BusinessLogicLayer;

namespace Magazin.ViewModels
{
    public class BonVM
    {
        private List<BonItem> _bonItems;
        private BonuriL bonuriL = new BonuriL();
        
        public int IDbon { get; set; }

        public List<BonItem> BonItems
        {
            get { return _bonItems; }
            set { _bonItems = value; }
        }

        public decimal Total
        {
            get { return BonItems.Sum(b => b.Subtotal); }
        }
        public BonVM(int id)
        {
            IDbon = id;
            var bon = bonuriL.GetBonprodu(IDbon);
            BonItems = GetBonItems(bon);
        }

     

        private List<BonItem> GetBonItems(List<BonProdu> bonProdu)
        {
            List<BonItem> bonItems = new List<BonItem>();
            foreach (var item in bonProdu)
            {
                BonItem bonItem = new BonItem();
                bonItem.Cantitate = item.cantitate;
                bonItem.Produs = new ProduseL().GetProduse().FirstOrDefault(p => p.IDprodus == item.produs);
                bonItem.Subtotal = item.subtotal;
                bonItems.Add(bonItem);
            }
            return bonItems;
        }
    }
}
