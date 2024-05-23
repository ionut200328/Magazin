using Magazin.Models.EntytyLayer;
using System.Linq;
using System.Windows;
using System.Windows.Controls;


namespace Magazin.Views
{
    public partial class LoginView : Window
    {
        public Utilizatori LoggedInUser { get; private set; }

        public LoginView()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string username = UsernameTextBox.Text;
            string password = PasswordBox.Password;

            // Replace with actual data access logic
            using (var context = new MagazinEntities()) // Your actual DbContext
            {
                var user = context.Utilizatoris
                                  .FirstOrDefault(u => u.nume == username && u.parola == password && u.active);

                if (user != null)
                {
                    LoggedInUser = user;
                    DialogResult = true;
                }
                else
                {
                    MessageBox.Show("Invalid username or password.");
                }
            }
        }
    }
}
