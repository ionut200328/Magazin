using Magazin.Models.BusinessLogicLayer;
using Magazin.Models.EntytyLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity.Core.Objects;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Magazin.Models
{
    public class BonItem : INotifyPropertyChanged
    {
        private int _cantitate;
        private Produse _produs;
        private decimal _subtotal;
        private decimal _pretUnitar;

        public int Cantitate
        {
            get { return _cantitate; }
            set
            {
                var stocuri = new StocuriL();
                var stoc = stocuri.GetStocuri();
                int cantitate = stoc.Sum(s => s.cantitate);
                // Check if the new value exceeds the available stock
                if (value <= cantitate)
                {
                    // Set the value if it's within the available stock
                    _cantitate = value;
                    OnPropertyChanged(nameof(Cantitate));
                }
                else
                {
                    // If the new value exceeds the available stock, you can either throw an exception or handle it in a different way
                    // For example, you can set the Cantitate to the maximum available stock
                    _cantitate = cantitate;
                    OnPropertyChanged(nameof(Cantitate));
                    // Alternatively, you can display a message to the user indicating that the quantity exceeds the available stock
                    MessageBox.Show("The quantity exceeds the available stock.");
                }
            }
        }

        public Produse Produs
        {
            get { return _produs; }
            set
            {
                _produs = value;
                ObjectParameter pret = new ObjectParameter("pret", typeof(decimal));
                using (var context = new MagazinEntities())
                {
                    context.spGetProductPrice(_produs.IDprodus, pret);
                    PretUnitar = pret.Value == DBNull.Value ? 0 : (decimal)pret.Value;
                }
                OnPropertyChanged(nameof(Produs));
            }
        }

        public decimal PretUnitar
        {
            get { return _pretUnitar; }
            private set
            {
                _pretUnitar = value;
                OnPropertyChanged(nameof(PretUnitar));
            }
        }

        public decimal Subtotal
        {
            get { return _subtotal; }
            set
            {
                _subtotal = value;
                OnPropertyChanged(nameof(Subtotal));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
