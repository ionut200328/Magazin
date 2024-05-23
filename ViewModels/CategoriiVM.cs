    using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Magazin.Models.EntytyLayer;
using Magazin.Models.BusinessLogicLayer;
using System.ComponentModel;
using System.Windows.Input;
using Magazin.Commands;

namespace Magazin.ViewModels
{
    public class CategoriiVM: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        private CategoriiL categoriiL = new CategoriiL();
        private ObservableCollection<Categorii> _categorii;
        public ICommand DeleteCommand { get; private set; }

        public ObservableCollection<Categorii> Categorii
        {
            get { return _categorii; }
            set
            {
                _categorii = value; 
                OnPropertyChanged(nameof(Categorii));
            }
        }

        public CategoriiVM()
        {
            Categorii = new ObservableCollection<Categorii>(categoriiL.GetCategorii());
            DeleteCommand = new RelayCommand<Categorii>(DeleteCategorie, CanDeleteCategorie);
        }

        public void AddCategorie(Categorii categorie)
        {
            try
            {
                categoriiL.AddCategorie(categorie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Categorii = new ObservableCollection<Categorii>(categoriiL.GetCategorii());
            }
        }

        public void UpdateCategorie(Categorii categorie)
        {
            categoriiL.UpdateCategorie(categorie);
            Categorii = new ObservableCollection<Categorii>(categoriiL.GetCategorii());
        }

        public void DeleteCategorie(Categorii categorii)
        {
            try
            {
                categoriiL.DeleteCategorie(categorii.IDcategorie);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
            finally
            {
                Categorii = new ObservableCollection<Categorii>(categoriiL.GetCategorii());
            }
        }

        public bool CanDeleteCategorie(Categorii categorii)
        {
            return categorii != null;
        }

        protected void OnPropertyChanged(string name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
