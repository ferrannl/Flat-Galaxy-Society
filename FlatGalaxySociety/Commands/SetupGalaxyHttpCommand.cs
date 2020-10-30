using FlatGalaxySociety.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace FlatGalaxySociety.Commands
{
    public class SetupGalaxyHttpCommand : Command
    {
        private MainViewModel main;
        public SetupGalaxyHttpCommand(MainViewModel mainViewModel)
        {
            main = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            main.SetupGalaxy("http");
        }
    }
}
