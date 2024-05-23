using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Magazin.Models.BusinessLogicLayer;
using Magazin.Models.EntytyLayer;
using System.ComponentModel;
using Magazin.Commands;
using System.Windows.Input;

namespace Magazin.ViewModels
{
    public class UtilizatoriVM: INotifyPropertyChanged
    {
        ObservableCollection<Utilizatori> utilizatori;
        public ObservableCollection<bool> TipUtilizatorItems { get; set; }
        UtilizatoriL utilizatoriL = new UtilizatoriL();

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<Utilizatori> Utilizatori
        {
            get { return utilizatori; }
            set
            {
                utilizatori = value;
                OnPropertyChanged(nameof(Utilizatori));
            }
        }

        public UtilizatoriVM()
        {
            utilizatori = new ObservableCollection<Utilizatori>(utilizatoriL.GetUtilizatori());
            DeleteCommand = new RelayCommand<Utilizatori>(DeleteUtilizator, CanDeleteUtilizator);
            TipUtilizatorItems = new ObservableCollection<bool> { false, true };
        }

        

        public void AddUtilizator(Utilizatori utilizator)
        {
            try
            {
                utilizatoriL.AddUtilizator(utilizator);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Utilizatori = new ObservableCollection<Utilizatori>(utilizatoriL.GetUtilizatori());
            }
        }

        public void UpdateUtilizator(Utilizatori utilizator)
        {
            utilizatoriL.UpdateUtilizator(utilizator);
            Utilizatori = new ObservableCollection<Utilizatori>(utilizatoriL.GetUtilizatori());
        }

        public void DeleteUtilizator(Utilizatori utilizator)
        {
            utilizatoriL.DeleteUtilizator(utilizator.IDutilizator);
            Utilizatori = new ObservableCollection<Utilizatori>(utilizatoriL.GetUtilizatori());
        }

        public bool CanDeleteUtilizator(Utilizatori utilizator)
        {
            if (utilizator == null || utilizator.active == false)
                return false;
            return true;
        }
        

        protected void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
