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

namespace Magazin.Views
{
    /// <summary>
    /// Interaction logic for ProdCategView.xaml
    /// </summary>
    public partial class ProdCategView : Window
    {
        public ProdCategView(int prod)
        {
            InitializeComponent();
            this.DataContext = new ProdCategVM(prod);
        }
    }
}
