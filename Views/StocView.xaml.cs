using Magazin.Models.EntytyLayer;
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
    /// Interaction logic for StocView.xaml
    /// </summary>
    public partial class StocView : Page
    {
        public StocView()
        {
            InitializeComponent();
            this.DataContext = new ViewModels.StocVM();
        }
        private void DataGrid_CellEditEnding(object sender, DataGridCellEditEndingEventArgs e)
        {
            if (e.EditAction == DataGridEditAction.Commit)
            {
                var editedTextBox = e.EditingElement as TextBox;
                if (editedTextBox != null)
                {
                    // Get the edited value
                    var newValue = editedTextBox.Text;

                    // Get the corresponding Stocuri item
                    var stoc = e.Row.Item as Stocuri;
                    stoc.pret_vanzare = Convert.ToDecimal(newValue);


                    if (stoc != null)
                    {
                        var viewModel = this.DataContext as ViewModels.StocVM;
                        try
                        {
                            viewModel?.UpdateStoc(stoc);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

    }
}
