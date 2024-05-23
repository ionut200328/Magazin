using Magazin.Models.EntytyLayer;
using Magazin.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Magazin.Views
{
    /// <summary>
    /// Interaction logic for CategoriiView.xaml
    /// </summary>
    public partial class CategoriiView : Page
    {
        public CategoriiView()
        {
            InitializeComponent();
            this.DataContext = new CategoriiVM();
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGrid dataGrid = sender as DataGrid;
                Categorii categorie = e.Row.Item as Categorii;

                if (categorie != null)
                {
                    var viewModel = this.DataContext as CategoriiVM;

                    // Check if all required fields are filled before adding/updating
                    if (!string.IsNullOrEmpty(categorie.categorie))
                    {
                        if (categorie.IDcategorie == 0) // Assuming IDprodus is 0 for new entries
                        {
                            viewModel?.AddCategorie(categorie);
                        }
                        else
                        {
                            viewModel?.UpdateCategorie(categorie);
                        }
                    }
                }
            }
        }
    }
}
