using System.Collections.ObjectModel;
using System.ComponentModel;
using Magazin.Models.EntytyLayer;
using Magazin.Models.BusinessLogicLayer;
using System.Data.Entity.Migrations.Model;
using System.Windows.Input;
using Magazin.Views;
using System;
using System.Runtime.CompilerServices;
using System.Linq;
using Magazin.Commands;
using System.Collections.Generic;

namespace Magazin.ViewModels
{
    public class ProdusVM : INotifyPropertyChanged
    {
        private ObservableCollection<Produse> produse;
        private ObservableCollection<Producatori> producatori;
        private ObservableCollection<Categorii> categorii;
        ProduseL produseL = new ProduseL();
        private  ObservableCollection<Produse> filteredProduse;
        private string _searchQuery;

        public ICommand AddProdusCommand { get; private set; }
        public ICommand DeleteCommand { get; private set; }


        public event PropertyChangedEventHandler PropertyChanged;
        public ObservableCollection<Produse> Produse
        {
            get { return produse; }
            set
            {
                produse = value;
                OnPropertyChanged(nameof(Produse));
            }
        }

        public ObservableCollection<Producatori> Producatori
        {
            get { return producatori; }
            set
            {
                producatori = value;
                OnPropertyChanged(nameof(Producatori));
            }
        }

        public ObservableCollection<Categorii> Categorii
        {
            get { return categorii; }
            set
            {
                categorii = value;
                OnPropertyChanged(nameof(Categorii));
            }
        }

        public  ObservableCollection<Produse> FilteredProduse
        {
            get { return filteredProduse; }
            set
            {
                filteredProduse = value;
                OnPropertyChanged(nameof(FilteredProduse));
            }
        }

        public string SearchQuery
        {
            get { return _searchQuery; }
            set
            {
                _searchQuery = value;
                FilterProduse(); // Call the filter method whenever search query changes
                OnPropertyChanged(nameof(SearchQuery));
            }
        }

        public ProdusVM()
        {
            Produse = new ObservableCollection<Produse>(produseL.GetProduse());
            FilteredProduse = new  ObservableCollection<Produse>(produseL.GetProduse());
            Producatori = new ObservableCollection<Producatori>(produseL.GetProducatori());
            Categorii = new ObservableCollection<Categorii>(produseL.GetCategorii());
            DeleteCommand = new RelayCommand<Produse>(DeleteProdus, CanDelete);

        }

        public void UpdateProdus(Produse produs)
        {
            produseL.UpdateProdus(produs); // Implement the update logic in your BusinessLogicLayer
            produse = new ObservableCollection<Produse>(produseL.GetProduse());
            FilteredProduse = new  ObservableCollection<Produse>(produseL.GetProduse());
        }

        public void AddProdus(Produse produs)
        {
            try
            {
                produseL.AddProdus(produs); // Implement the add logic in your BusinessLogicLayer
                
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            finally
            {
                produse = new ObservableCollection<Produse>(produseL.GetProduse());
                FilteredProduse = new  ObservableCollection<Produse>(produseL.GetProduse());
            }

        }
        private void DeleteProdus(Produse produs)
        {
            // Call your delete logic from the business layer
            produseL.DeleteProdus(produs.IDprodus);

            // Update the ObservableCollection to reflect the changes
            Produse = new ObservableCollection<Produse>(produseL.GetProduse());
            FilteredProduse = new  ObservableCollection<Produse>(produseL.GetProduse());
        }
        private bool CanDelete(Produse produs)
        {
            if (produs == null || produs.active == false )
            {
                return false;
            }
            return true;
        }

        private void FilterProduse()
        {
            // Filter the Produse collection based on the search query
            if (string.IsNullOrWhiteSpace(SearchQuery))
            {
                // If search query is empty or null, show all Produse
                FilteredProduse = Produse;
            }
            else
            {
                // Otherwise, filter Produse based on the search query
                FilteredProduse = new ObservableCollection<Produse>(
                    Produse.Where(p => p.nume_prod.ToLower().Contains(SearchQuery.ToLower()) ||
                                        p.cod_bare.ToLower().Contains(SearchQuery.ToLower())));
            }
        }
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
