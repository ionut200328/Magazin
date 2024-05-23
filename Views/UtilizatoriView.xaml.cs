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
using Magazin.Models.EntytyLayer;
using Magazin.ViewModels;


namespace Magazin.Views
{
    /// <summary>
    /// Interaction logic for utilizatorView.xaml
    /// </summary>
    public partial class UtilizatoriView : Page
    {
        public UtilizatoriView()
        {
            InitializeComponent();
            this.DataContext = new UtilizatoriVM();
        }

        private void DataGrid_RowEditEnding(object sender, DataGridRowEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                DataGrid dataGrid = sender as DataGrid;
                Utilizatori utilizator = e.Row.Item as Utilizatori;

                if (utilizator != null)
                {
                    var viewModel = this.DataContext as UtilizatoriVM;

                    // Check if all required fields are filled before adding/updating
                    if (!string.IsNullOrEmpty(utilizator.nume) && !string.IsNullOrEmpty(utilizator.parola))
                    {
                        if (utilizator.IDutilizator == 0) // Assuming IDprodus is 0 for new entries
                        {
                            viewModel?.AddUtilizator(utilizator);
                        }
                        else
                        {
                            viewModel?.UpdateUtilizator(utilizator);
                        }
                    }
                }
            }
        }
    }
}
