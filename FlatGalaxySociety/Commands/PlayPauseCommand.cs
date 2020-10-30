using FlatGalaxySociety.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlatGalaxySociety.Commands
{
    public class PlayPauseCommand : Command
    {
        private MainViewModel main;
        public PlayPauseCommand(MainViewModel mainViewModel)
        {
            main = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            if (main.galaxyThread != null)
            {
                main.galaxyThread.PlayPause();
            }
        }
    }
}
