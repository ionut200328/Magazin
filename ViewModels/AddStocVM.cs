using Magazin.Commands;
using Magazin.Models.EntytyLayer;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Magazin.Models.BusinessLogicLayer;
using System.Collections.Generic;
using System.Windows;

namespace Magazin.ViewModels
{
    public class AddStocVM : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private StocuriL stocuriL = new StocuriL();

        public List <Produse> Produse
        {
            get { return new ProduseL().GetProduse(); }
        }

        private Produse selectedProdus;
        public Produse SelectedProdus
        {
            get { return selectedProdus; }
            set
            {
                selectedProdus = value;
                OnPropertyChanged(nameof(SelectedProdus));
            }
        }
        private int cantitate;
        public int Cantitate
        {
            get { return cantitate; }
            set
            {
                cantitate = value;
                OnPropertyChanged(nameof(Cantitate));
            }
        }

        private decimal pret;
        public decimal Pret
        {
            get { return pret; }
            set
            {
                pret = value;
                OnPropertyChanged(nameof(Pret));
            }
        }

        private string um;
        public string UM
        {
            get { return um; }
            set
            {
                um = value;
                OnPropertyChanged(nameof(UM));
            }
        }

        private DateTime? dataAprovizionare;
        public DateTime? DataAprovizionare
        {
            get { return dataAprovizionare; }
            set
            {
                dataAprovizionare = value;
                OnPropertyChanged(nameof(DataAprovizionare));
            }
        }

        private DateTime? dataExpirare;
        public DateTime? DataExpirare
        {
            get { return dataExpirare; }
            set
            {
                dataExpirare = value;
                OnPropertyChanged(nameof(DataExpirare));
            }
        }

        private double adaos;
        public double Adaos
        {
            get { return adaos; }
            set
            {
                adaos = value;
                OnPropertyChanged(nameof(Adaos));
            }
        }

        public ICommand AddStocCommand { get; }
        public ICommand CancelCommand { get; }

        public AddStocVM()
        {
            AddStocCommand = new RelayCommand<Stocuri>(AddStocCommandExecute, CanAdd);
            CancelCommand = new RelayCommand<object>(CancelCommandExecute);
        }

        private void AddStocCommandExecute(Stocuri parameter)
        {
            // Add stoc logic here
            // You can access NumeProdus, Cantitate, Pret, UM, DataAprovizionare, and DataExpirare properties to retrieve user input
           
            try
            {
                parameter = new Stocuri();
                if(SelectedProdus == null)
                {
                    MessageBox.Show("Please select a product!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }
                parameter.produs = SelectedProdus.IDprodus;
                parameter.cantitate = Cantitate;
                parameter.pret_achizitie = Pret;
                parameter.um = UM;
                parameter.aprovizionare = DataAprovizionare ?? DateTime.Now;
                parameter.expirare = DataExpirare ?? null;
                stocuriL.AddStoc(parameter, Adaos);
                MessageBox.Show("Stock added successfully!", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("An error occurred while adding the stock!", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
            finally
            {
                CloseWindow();
            }

        }

        private bool CanAdd(Stocuri parameter)
        {
            // Add validation logic here
            return true;
        }
        private void CancelCommandExecute(object obj)
        {
            // Close the window
            CloseWindow();
        }

        private void CloseWindow()
        {
            foreach (Window window in Application.Current.Windows)
            {
                if (window.DataContext == this)
                {
                    window.Close();
                    break;
                }
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
