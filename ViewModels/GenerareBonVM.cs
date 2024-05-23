using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;
using Magazin.Models.BusinessLogicLayer;
using Magazin.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Magazin.Commands;
using System.Data.Entity.Core.Objects;
using Magazin.Views;

namespace Magazin.ViewModels
{
    public class GenerareBonVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private BonuriL bonuriL = new BonuriL();
        private ProduseL produseL = new ProduseL();
        private StocuriL stocuriL = new StocuriL();
        private ObservableCollection<BonItem> bonItems;
        private List<Produse> produse;
        private ICommand generareCommand;
        MagazinEntities context = new MagazinEntities();

        public ObservableCollection<BonItem> BonItems
        {
            get { return bonItems; }
            set
            {
                bonItems = value;
                OnPropertyChanged(nameof(BonItems));
            }
        }
        public List<Produse> Produse
        {
            get { return produse; }
            set
            {
                produse = value;
                OnPropertyChanged(nameof(Produse));
            }
        }
        public ICommand GenerareCommand
        {
            get { return generareCommand; }
            set
            {
                generareCommand = value;
                OnPropertyChanged(nameof(GenerareCommand));
            }
        }
        public GenerareBonVM()
        {
            Produse = new List<Produse>();
            var produse = produseL.GetProduse();
            //Produse should have just the products that are in stock
            foreach (var item in produse)
            {
                var stoc = stocuriL.GetStocuri().Where(x => x.produs == item.IDprodus).FirstOrDefault();
                if (stoc != null)
                {
                    Produse.Add(item);
                }
               
            }
            
            BonItems = new ObservableCollection<BonItem>();
            GenerareCommand = new RelayCommand<object>(GenerareBon);
        }

        private void GenerareBon(object param)
        {
            bonuriL.AddBon(DateTime.Now);
            var lastBon = new ObjectParameter("bon", typeof(int));
            context.spLastBon(lastBon);
            int bon = (int)lastBon.Value;
            foreach (var item in BonItems)
            {
                var subTotal = new ObjectParameter("subtotal", typeof(decimal));
                subTotal.Value = 0;
                context.spCreareBonProdus(bon, item.Produs.IDprodus, item.Cantitate, subTotal);
                BonItems[BonItems.IndexOf(item)].Subtotal = (decimal)subTotal.Value;
            }
            new BonView(bon).ShowDialog();
        }



        private void OnPropertyChanged(string propertyName)
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            }
    }
}
