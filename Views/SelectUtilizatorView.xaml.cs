using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Magazin.Models.EntytyLayer;

namespace Magazin.Views
{
    /// <summary>
    /// Interaction logic for SelectUtilizatorView.xaml
    /// </summary>
    public partial class SelectUtilizatorView : Page
    {
        public SelectUtilizatorView()
        {
            InitializeComponent();
            LoadUtilizatori();
        }

        private void LoadUtilizatori()
        {
            using (var context = new MagazinEntities())
            {
                var utilizatori = context.Utilizatoris.ToList();
                cbUtilizatori.ItemsSource = utilizatori;
                cbUtilizatori.DisplayMemberPath = "nume"; // Assuming 'Nume' is a property of Utilizatori
                cbUtilizatori.SelectedValuePath = "IDutilizator"; // Assuming 'ID' is the primary key
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (cbUtilizatori.SelectedItem is Utilizatori selectedUtilizator && monthPicker.dteSelectedMonth.DisplayDate != null)
            {
                int selectedUtilizatorId = selectedUtilizator.IDutilizator; // Assuming 'ID' is the primary key
                DateTime selectedMonth = monthPicker.dteSelectedMonth.DisplayDate;
                int selectedYear = selectedMonth.Year;
                int selectedMonthValue = selectedMonth.Month;

                MessageBox.Show($"Selected Utilizator: {selectedUtilizator.nume}\nSelected Month: {selectedMonthValue}, Year: {selectedYear}");
                new IncasarePerZiView(selectedUtilizatorId, selectedMonth).ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select both a Utilizator and a Month.");
            }
        }
    }
}
