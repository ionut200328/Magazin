using System.IO;
using System.Windows;
using System.Windows.Controls;
using Magazin.Models.EntytyLayer;
using Magazin.ViewModels;
using System.Linq;

namespace Magazin.Views
{
    public partial class ProduseView : Page
    {
        public ProduseView()
        {
            InitializeComponent();
            this.DataContext = new ProdusVM();
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGrid dataGrid = sender as DataGrid;
                Produse produs = e.Row.Item as Produse;

                if (produs != null)
                {
                    var viewModel = this.DataContext as ProdusVM;

                    // Check if all required fields are filled before adding/updating
                    if (!string.IsNullOrEmpty(produs.nume_prod) && !string.IsNullOrEmpty(produs.cod_bare))
                    {
                        if (produs.IDprodus == 0) // Assuming IDprodus is 0 for new entries
                        {
                           
                            viewModel?.AddProdus(produs);
                        }
                        else
                        {
                            viewModel?.UpdateProdus(produs);
                        }
                    }
                }
            }
        }
    }
}
