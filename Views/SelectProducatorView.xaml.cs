using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Magazin.Models;
using Magazin.Models.EntytyLayer;

namespace Magazin.Views
{
    /// <summary>
    /// Interaction logic for SelectProducatorView.xaml
    /// </summary>
    public partial class SelectProducatorView : Page
    {
        public SelectProducatorView()
        {
            InitializeComponent();
            LoadProducatori();
        }

        private void LoadProducatori()
        {
            using (var context = new MagazinEntities())
            {
                var producatori = context.Producatoris.ToList();
                cbProducatori.ItemsSource = producatori;
                cbProducatori.DisplayMemberPath = "nume_producator"; // Adjust this if the property name is different
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (cbProducatori.SelectedItem != null)
            {
                var selectedProducator = (Producatori)cbProducatori.SelectedItem;
                //Open the new window
                var prodCategView = new ProdCategView(selectedProducator.IDproducator);
                prodCategView.Show();
                
            }
            else
            {
                MessageBox.Show("Please select a producator.");
            }
        }
    }
}
