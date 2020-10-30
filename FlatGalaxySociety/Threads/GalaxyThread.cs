using FlatGalaxySociety.Memento;
using System;
using System.Diagnostics;
using System.Threading;

namespace FlatGalaxySociety
{
    public class GalaxyThread
    {
        public Caretaker caretaker;
        public Galaxy galaxy;
        private int fps;
        private bool isPaused;
        private Thread thread;

        public GalaxyThread(Galaxy galaxy)
        {
            this.caretaker = new Caretaker(this);
            this.galaxy = galaxy;
            fps = 60;
            thread = new Thread(new ThreadStart(Run));
            thread.Start();
        }

        private void Run()
        {
            while (true)
            {
                if (!isPaused)
                {
                    galaxy.Tick();
                    galaxy.Draw();
                    System.Threading.Thread.Sleep(1000 / fps);
                }
            }
        }

        public void PlayPause()
        {
            isPaused = !isPaused;
            caretaker.StopStartTimer(isPaused);
        }

        public void SlowDown()
        {
            if (fps > 5) { fps -= 5; }
        }

        public void SpeedUp()
        {
            fps += 5;
        }

        public void Abort()
        {
            thread.Abort();
        }
    }
}
