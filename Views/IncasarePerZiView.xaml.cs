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
    /// Interaction logic for IncasarePerZiView.xaml
    /// </summary>
    public partial class IncasarePerZiView : Window
    {
        public IncasarePerZiView(int op, DateTime data)
        {
            InitializeComponent();
            this.DataContext = new IncasareZileVM(op, data);
        }
    }
}
