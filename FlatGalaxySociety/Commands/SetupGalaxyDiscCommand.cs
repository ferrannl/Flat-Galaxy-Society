using FlatGalaxySociety.ViewModels;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatGalaxySociety.Commands
{
    public class SetupGalaxyDiscCommand : Command
    {
        private MainViewModel main;
        public SetupGalaxyDiscCommand(MainViewModel mainViewModel)
        {
            main = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            main.SetupGalaxy("disc");
        }
    }
}
