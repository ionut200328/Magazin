using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.EntytyLayer;
using Magazin.Models.BusinessLogicLayer;
using System.ComponentModel;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Magazin.Commands;

namespace Magazin.ViewModels
{
    public class ProducatoriVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private ProducatoriL producatoriL = new ProducatoriL();
        private ObservableCollection<Producatori> _producatori;
        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<Producatori> Producatori
        {
            get { return _producatori; }
            set {
                _producatori = value; 
                OnPropertyChanged(nameof(Producatori));
            }
        }

        public ProducatoriVM()
        {
            Producatori = new ObservableCollection<Producatori>(producatoriL.GetProducatori());
            DeleteCommand = new RelayCommand<Producatori>(DeleteProducator, CanDeleteProducator);
        }

        public void AddProducator(Producatori producator)
        {
            try
            {
                producatoriL.AddProducator(producator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Producatori = new ObservableCollection<Producatori>(producatoriL.GetProducatori());
            }
        }

        public void UpdateProducator(Producatori producator)
        {
            producatoriL.UpdateProducator(producator);
            Producatori = new ObservableCollection<Producatori>(producatoriL.GetProducatori());
        }

        public void DeleteProducator(Producatori producatori)
        {
            producatoriL.DeleteProducator(producatori.IDproducator);
            Producatori = new ObservableCollection<Producatori>(producatoriL.GetProducatori());
        }

        public bool CanDeleteProducator(Producatori producator)
        {
            if(producator == null || producator.active == false)
                return false;
            return true;
        }

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
