using Magazin.Views;
using System.Windows;
using System.Windows.Controls;
using Magazin.Models.EntytyLayer;
using Magazin.ViewModels;

namespace Magazin
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            var loginWindow = new LoginView();
            if (loginWindow.ShowDialog() == true)
            {
                new MagazinEntities().spStocExpirat();
                InitializeUI(loginWindow.LoggedInUser);
                InitializeComponent();
            }
            else
            {
                Close();
            }
        }

        private void InitializeUI(Utilizatori loggedInUser)
        {
            if (loggedInUser.tip_utilizator)
            {
                // User is an admin
                MessageBox.Show("Welcome Admin!");
                GlobalVariables.IsAdmin = true;
                GlobalVariables.IDuser = loggedInUser.IDutilizator;
            }
            else
            {
                // User is a regular user
                MessageBox.Show("Welcome User!");
                GlobalVariables.IsAdmin = false;
                GlobalVariables.IDuser = loggedInUser.IDutilizator;
            }
        }

        private void NavigateToProdusView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProduseView());
        }

        private void NavigateToStocuriView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new StocView());
        }
        private void NavigateToBonView_Click(object sender, RoutedEventArgs e)
        {
            new GenerareBonView().ShowDialog();
        }

        private void NavigateToBonulZileiBiew_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new BonulZileiView());
        }


        private void NavigateToSelectProducator_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SelectProducatorView());
        }

        private void NavigateToValoareCategorieView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategorieSumaView());
        }

        private void NavigateToSelectUtilizatorView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new SelectUtilizatorView());
        }

        private void NavigateToProducatorView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ProducatoriView());
        }

        private void NavigateToCategorieView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new CategoriiView());
        }

        private void NavigateToUtilizatorView_Click(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new UtilizatoriView());
        }
    }
}
