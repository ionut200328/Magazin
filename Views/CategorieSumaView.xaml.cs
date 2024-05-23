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
    /// Interaction logic for CategorieSumaView.xaml
    /// </summary>
    public partial class CategorieSumaView : Page
    {
        public CategorieSumaView()
        {
            InitializeComponent();
            this.DataContext = new CategSumaVM();
        }
    }
}
