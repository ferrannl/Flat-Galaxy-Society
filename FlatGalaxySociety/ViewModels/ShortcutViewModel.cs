using FlatGalaxySociety.Commands;
using FlatGalaxySociety.Models;
using FlatGalaxySociety.Views;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlatGalaxySociety.ViewModels
{
    public class ShortcutViewModel : ViewModelBase
    {
        private ShortcutWindow window;
        private MainViewModel main;
        public ICommand SaveCommand { get; set; }

        private List<Shortcut> shortcutList;
        public ObservableCollection<Shortcut> ShortcutList { get; set; }

        public ShortcutViewModel(MainViewModel main, ShortcutWindow window)
        {
            this.window = window;
            this.main = main;
            SaveCommand = new RelayCommand(Save);
            shortcutList = main.shortcutList.ConvertAll(s => s.Clone(null));
            ShortcutList = new ObservableCollection<Shortcut>(shortcutList);
        }

        public void Save()
        {
            if (CanSave())
            {
                // convert KeyString to Key
                foreach (var s in ShortcutList)
                {
                    s.KeyChar = char.ToUpper(s.KeyChar);
                    s.Key = KeyInterop.KeyFromVirtualKey(char.ToUpper(s.KeyChar));
                }
                main.shortcutList = shortcutList;
                window.Close();
            }
            else
            {
                shortcutList = main.shortcutList;
                ShortcutList = new ObservableCollection<Shortcut>(shortcutList);
                RaisePropertyChanged("ShortcutList");
            }
        }

        private bool CanSave()
        {
            // check uniqueness
            var query = ShortcutList.GroupBy(s => char.ToUpper(s.KeyChar))
              .Where(i => i.Count() > 1)
              .Select(j => j.Key)
              .ToList();

            if (query.Count > 0)
            {
                MessageBox.Show("Sneltoetsen zijn uniek.");
                return false;
            }

            // check validity key
            string regex = "^[a-zA-Z]{1}$";
            foreach (var s in shortcutList)
            {
                if (!Regex.IsMatch(s.KeyChar.ToString(), regex))
                {
                    MessageBox.Show("Sneltoetsen bestaan uit één letter");
                    return false;
                }
            }

            return true;
        }
    }
}
