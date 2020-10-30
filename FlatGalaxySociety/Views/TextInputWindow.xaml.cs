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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace FlatGalaxySociety
{
    /// <summary>
    /// Interaction logic for TextInputWindow.xaml
    /// </summary>
    public partial class TextInputWindow : Window
    {
        public TextInputWindow()
        {
            InitializeComponent();
            DataContext = new TextInputViewModel(this);
        }
    }
}