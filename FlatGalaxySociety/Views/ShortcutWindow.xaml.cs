using CommonServiceLocator;
using FlatGalaxySociety.ViewModels;
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

namespace FlatGalaxySociety.Views
{
    /// <summary>
    /// Interaction logic for ShortcutWindow.xaml
    /// </summary>
    public partial class ShortcutWindow : Window
    {
        public ShortcutWindow()
        {
            InitializeComponent();
            DataContext = new ShortcutViewModel(ServiceLocator.Current.GetInstance<MainViewModel>(), this);
        }
    }
}
