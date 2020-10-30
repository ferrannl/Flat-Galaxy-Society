using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlatGalaxySociety.ViewModels
{
    public class TextInputViewModel : ViewModelBase
    {
        public ICommand AcceptCommand { get; set; }

        public string CustomInput { get; set; }

        private Window window;

        public TextInputViewModel(Window window)
        {
            AcceptCommand = new RelayCommand<TextBox>(Accept);
            this.window = window;
        }

        public void Accept(TextBox textBox)
        {
            window.DialogResult = true;
            CustomInput = textBox.Text;
            window.Close();
        }
    }
}
