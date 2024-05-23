using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Magazin.Models.EntytyLayer;

namespace Magazin.Views
{
    /// <summary>
    /// Interaction logic for BonulZileiView.xaml
    /// </summary>
    public partial class BonulZileiView : Page
    {
        public BonulZileiView()
        {
            InitializeComponent();
        }

        private void btnAfisare_Click(object sender, RoutedEventArgs e)
        {
            // Retrieve the selected date from the DatePicker
            DateTime? selectedDate = datePicker.SelectedDate;

            // Check if a date is selected
            if (selectedDate.HasValue)
            {
                // Get the bon ID for the selected date
                using (var context = new MagazinEntities())
                {
                    var result = context.spBonulZilei(selectedDate.Value).FirstOrDefault();

                    if (result.HasValue)
                    {
                        int bonId = result.Value;
                        // Display the BonView for the bon ID
                        new BonView(bonId).ShowDialog();
                    }
                    else
                    {
                        MessageBox.Show("No bon found for the selected date.", "Information", MessageBoxButton.OK, MessageBoxImage.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a date.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
