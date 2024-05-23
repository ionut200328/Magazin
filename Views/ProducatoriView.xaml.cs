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
    /// Interaction logic for ProducatoriView.xaml
    /// </summary>
    public partial class ProducatoriView : Page
    {
        public ProducatoriView()
        {
            InitializeComponent();
            this.DataContext = new ProducatoriVM();
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGrid dataGrid = sender as DataGrid;
                Producatori producator = e.Row.Item as Producatori;

                if (producator != null)
                {
                    var viewModel = this.DataContext as ProducatoriVM;

                    // Check if all required fields are filled before adding/updating
                    if (!string.IsNullOrEmpty(producator.nume_producator) && !string.IsNullOrEmpty(producator.tara_origine))
                    {
                        if (producator.IDproducator == 0) // Assuming IDprodus is 0 for new entries
                        {
                            viewModel?.AddProducator(producator);
                        }
                        else
                        {
                            viewModel?.UpdateProducator(producator);
                        }
                    }
                }
            }
        }
    }
}
