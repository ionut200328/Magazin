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
using System.Windows.Shapes;
using Magazin.ViewModels;
using Magazin.Models;

namespace Magazin.Views
{
    /// <summary>
    /// Interaction logic for GenerareBonView.xaml
    /// </summary>
    public partial class GenerareBonView : Window
    {
        public GenerareBonView()
        {
            InitializeComponent();
            this.DataContext = new GenerareBonVM();
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

                    // Get the corresponding BonItem item
                    var bonItem = e.Row.Item as BonItem;
                    bonItem.Cantitate = Convert.ToInt32(newValue);
                    var viewModel = this.DataContext as GenerareBonVM;
                    try
                    {
                        viewModel?.BonItems.Add(bonItem);
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
