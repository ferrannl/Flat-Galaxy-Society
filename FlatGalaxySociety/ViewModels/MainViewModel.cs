using FlatGalaxySociety.Commands;
using FlatGalaxySociety.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace FlatGalaxySociety.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region
        public ICommand SetupGalaxyDiscCommand { get; set; }
        public ICommand SetupGalaxyHttpCommand { get; set; }
        public ICommand PlayPauseCommand { get; set; }
        public ICommand SlowDownCommand { get; set; }
        public ICommand SpeedUpCommand { get; set; }
        public ICommand PlayBackCommand { get; set; }
        public ICommand OpenShortcutsCommand { get; set; }
        public ICommand KeyDownCommand { get; set; }
        #endregion
        public ObservableCollection<Star> ObservableStars { get; set; }
        public ObservableCollection<Connection> ObservableConnections { get; set; }
        public ICommand OpenPromptCommand { get; set; }

        public List<Shortcut> shortcutList;

        public GalaxyThread galaxyThread;

        public MainViewModel()
        {
            SetupGalaxyDiscCommand = new SetupGalaxyDiscCommand(this);
            SetupGalaxyHttpCommand = new SetupGalaxyHttpCommand(this);
            PlayPauseCommand = new PlayPauseCommand(this);
            SlowDownCommand = new SlowDownCommand(this);
            SpeedUpCommand = new SpeedUpCommand(this);
            PlayBackCommand = new PlayBackCommand(this);
            OpenShortcutsCommand = new OpenShortcutsCommand();
            KeyDownCommand = new RelayCommand<Key>(OnKeyDown);
            SetDefaultShortcuts();
            ObservableStars = new ObservableCollection<Star>();
            ObservableConnections = new ObservableCollection<Connection>();
        }

        private void SetDefaultShortcuts()
        {
            shortcutList = new List<Shortcut>
            {
                new Shortcut("Open van disc", SetupGalaxyDiscCommand, Key.D),
                new Shortcut("Open van http", SetupGalaxyHttpCommand, Key.H),
                new Shortcut("Starten/Pauzeren", PlayPauseCommand, Key.P),
                new Shortcut("Vertragen", SlowDownCommand, Key.Z),
                new Shortcut("Versnellen", SpeedUpCommand, Key.X),
                new Shortcut("Terugspringen", PlayBackCommand, Key.B),
                new Shortcut("Configureer shortcuts", OpenShortcutsCommand, Key.S)
            };
        }

        private void OnKeyDown(Key key)
        {
            var shortcut = shortcutList.Where(s => s.Key == key).FirstOrDefault();
            if (shortcut != null)
            {
                shortcut.Command.Execute(null);
            }
        }

        public void SetupGalaxy(string importType)
        {
            try
            {
                this.ObservableStars.Clear();
                this.ObservableConnections.Clear();
                string filePath = Import(importType);
                List<string> content = Read(filePath);
                List<List<KeyValuePair<string, string>>> starList;
                List<KeyValuePair<string, string>> neighbourList;
                Parse(content, out starList, out neighbourList);
                Galaxy galaxy = Build(starList, neighbourList);
                StartGalaxyThread(galaxy);
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private string Import(string importType)
        {
            Importer importer = ImporterFactory.Instance.CreateImporter(importType);
            return importer.Import();
        }

        private List<string> Read(string filePath)
        {
            Reader reader = ReaderFactory.Instance.CreateReader(filePath);
            return reader.Read(filePath);
        }

        private void Parse(List<string> content, out List<List<KeyValuePair<string, string>>> starList, out List<KeyValuePair<string, string>> neighbourList)
        {
            Parser parser = ParserFactory.Instance.CreateParser(content[0]);
            parser.Parse(content, out starList, out neighbourList);
        }
        private Galaxy Build(List<List<KeyValuePair<string, string>>> starList, List<KeyValuePair<string, string>> neighbourList)
        {
            GalaxyBuilder builder = new GalaxyBuilder(new Galaxy(this));

            foreach (List<KeyValuePair<string, string>> s in starList)
            {
                builder.AddStar(s);
            }
            foreach (KeyValuePair<string, string> n in neighbourList)
            {
                builder.LinkStars(n.Key, n.Value);
            }

            return builder.Build();
        }

        private void StartGalaxyThread(Galaxy galaxy)
        {
            if (galaxyThread != null)
            {
                galaxyThread.Abort();
            }
            galaxyThread = new GalaxyThread(galaxy);

        }
    }
}

