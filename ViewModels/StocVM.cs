using Magazin.Models.EntytyLayer;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Magazin.Models.BusinessLogicLayer;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Magazin.Commands;
using Magazin.Views;

namespace Magazin.ViewModels
{
    public class StocVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private StocuriL stocuriL = new StocuriL();
        private ObservableCollection<Stocuri> stocuri;
        public ICommand AdaugaCommand { get; }
        public ICommand DeleteCommand { get; }
        public ObservableCollection<Stocuri> Stocuri
        {
            get { return stocuri; }
            set
            {
                stocuri = value; 
                OnPropertyChanged(nameof(Stocuri));
            }
        }

        public StocVM()
        {
            AdaugaCommand = new RelayCommand<Stocuri>(AdaugaStoc);
            DeleteCommand = new RelayCommand<Stocuri>(DeleteStoc);
            using (var context = new MagazinEntities())
            {

                Stocuri = new ObservableCollection<Stocuri>(stocuriL.GetStocuri());
            }
        }

        private void DeleteStoc(Stocuri stocuri)
        {
            stocuriL.DeleteStoc(stocuri.IDstoc);
            Stocuri = new ObservableCollection<Stocuri>(stocuriL.GetStocuri());
        }

        private void AdaugaStoc(object obj)
        {
            // Create an instance of the AddStocPopUp window
            AddStocPopUp addStocPopUp = new AddStocPopUp();

            // Show the window as a dialog
            addStocPopUp.ShowDialog();

            Stocuri = new ObservableCollection<Stocuri>(stocuriL.GetStocuri());
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        internal void UpdateStoc(Stocuri stoc)
        {
            if(stoc.pret_vanzare < stoc.pret_achizitie)
            {
                throw new Exception("Pretul de vanzare nu poate fi mai mic decat cel de achizitie");
            }
            stocuriL.UpdateStoc(stoc.IDstoc, stoc.pret_vanzare);
            Stocuri = new ObservableCollection<Stocuri>(stocuriL.GetStocuri());
        }
    }
}
