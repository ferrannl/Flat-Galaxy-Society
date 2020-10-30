using FlatGalaxySociety.Utils.DataStructures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;

namespace FlatGalaxySociety.Memento
{
    public class Caretaker
    {
        private const int STACK_CAPACITY = 15;
        private DropOutStack<IMemento<Galaxy>> mementos;

        private GalaxyThread galaxyThread;
        private Timer mementoSaver;
        public Caretaker(GalaxyThread galaxyThread)
        {
            this.galaxyThread = galaxyThread;
            mementos = new DropOutStack<IMemento<Galaxy>>(STACK_CAPACITY);
            mementoSaver = new System.Timers.Timer(5000);
            mementoSaver.Elapsed += MomentoSaver_Elapsed;
            mementoSaver.Start();
        }
        private void MomentoSaver_Elapsed(object sender, ElapsedEventArgs e)
        {
            Backup();
        }

        public void Backup()
        {
            StopStartTimer(true);
            IMemento<Galaxy> galaxyMomento = galaxyThread.galaxy.Save();
            mementos.Push(galaxyMomento);
            StopStartTimer(false);
        }

        public void Undo()
        {
            if (mementos.Count() == 0)
            {
                return;
            }

            IMemento<Galaxy> momento = mementos.Pop();
            galaxyThread.galaxy = momento.GetState();
            galaxyThread.galaxy.Draw();
        }

        public void StopStartTimer(bool isPaused)
        {
            if (isPaused)
            {
                mementoSaver.Stop();
            }
            else
            {
                mementoSaver.Start();
            }
        }
    }
}
